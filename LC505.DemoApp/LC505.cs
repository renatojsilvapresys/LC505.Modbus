using Presys.Calibrators.Comm.LC505.Modbus;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LC505.DemoApp
{
    public class LC505
    {
        public Dictionary<byte, string> errors = new Dictionary<byte, string>()
        {
            { 1, "Error on opening connection. Possible causes:\r\ni) Serial port is wrong or does not exist." },
            { 2, "Error on writing register. Possible causes:\r\ni) There is no device on selected COM Port\r\nii) Modbus address is wrong\r\niii) Register address is wrong\r\niv) Register value is out of range." },
            { 3, "Impossible to close the serial port. Possible causes:\r\ni) Serial port is wrong or does not exist." },            

        };

        public static string[] InputTypes = new string[]
        {
            "V",
            "mA",
            "None"
        };

        public static string[] OutputTypes = new string[]
       {
            "V",
            "mA",
            "None"
       };

        private string serialPort;
        private string modbusAddress;
        private byte baudRate;
        private byte parity;
        private byte length;
        private byte stopBits;
        private short readTimeout;
        private short minTimeInterChar;

        public LC505()
        {
        }       

        public void InitiateComm(string configuration)
        {
            try
            {
                this.serialPort = configuration.Split('|')[0];
                this.modbusAddress = configuration.Split('|')[1];
                this.baudRate = byte.Parse(configuration.Split('|')[2]);
                this.parity = byte.Parse(configuration.Split('|')[3]);
                this.length = byte.Parse(configuration.Split('|')[4]);
                this.stopBits = byte.Parse(configuration.Split('|')[5]);
                this.readTimeout = short.Parse(configuration.Split('|')[6]);
                this.minTimeInterChar = short.Parse(configuration.Split('|')[7]);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Configuration. Try to understand how the parameters work.", ex);
            }
        }

        public void FinishComm()
        {
            this.serialPort = String.Empty;
            this.modbusAddress = String.Empty;
        }        

        public void ChangeInputType(string inputType)
        {
            var resp = WriteByteToDevice(29060, GetInputCode(inputType));

            if (resp != 0 && resp != 255)
            {
                throw new Exception(errors[resp]);
            }                
        }

        public byte WriteByteToDevice(short address, byte data)
        {
            return WriteRawDataToDevice(address, new short[] { (short)data });
        }

        public byte WriteRawDataToDevice(short address, short[] rawdata)
        {
            if (String.IsNullOrEmpty(serialPort))
                return 255;

            var resp = OpenConnection();

            if (resp != 1 && resp != 2)
                return 1;

            resp = Interop.WriteMultipleRegisters(GetSerialPort(), 1, Byte.Parse(modbusAddress), address, (byte)rawdata.Length, rawdata);

            if (resp != 1)
                return 2;

            resp = Interop.CloseConnection(GetSerialPort());

            if (resp != 1)
                return 3;

            return 0;
        }

        private byte OpenConnection()
        {
            return Interop.OpenConnection(GetSerialPort(), baudRate, parity, length, stopBits, readTimeout, minTimeInterChar);
        }

        private byte GetSerialPort()
        {
            return (byte)((int)Convert.ToByte(serialPort.Replace("COM", String.Empty).Trim()) - 1);
        }

        private static byte GetInputCode(string inputType)
        {
            return (byte)InputTypes.ToList().IndexOf(inputType);
        }

        public void ChangeOutputType(string outputType)
        {
            var resp = WriteByteToDevice(29061, GetInputCode(outputType));

            if (resp != 0 && resp != 255)
            {
                throw new Exception(errors[resp]);
            }
        }

        public string GetCurrentInputType()
        {
            byte inputTypeCode;
            ReadByteFromDevice(29060, out inputTypeCode);
            return InputTypes[inputTypeCode];
        }

        private void ReadByteFromDevice(short registerAddress, out byte value)
        {
            short[] bytes = new short[1];
            var resp = ReadRawData(registerAddress, bytes);

            if (resp == 0)
            {
                value = (byte)bytes[0];
                return;
            }

            throw new Exception(errors[resp]);
        }

        private void ReadFloatFromDevice(short registerAddress, out float value)
        {
            short[] bytes = new short[4];
            var resp = ReadRawData(registerAddress, bytes);

            if (resp == 0)
            {                
                value = ConvertInt32ToFloat(ConvertRawDataToInt32(bytes), 4);
                return;
            }

            throw new Exception(errors[resp]);
        }

        private int ConvertRawDataToInt32(short[] bytes)
        {
            return (int)((bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3]);
        }

        private float ConvertInt32ToFloat(int value, int numDecimals)
        {
            return (float)(value / Math.Pow(10, numDecimals));
        }       

        private byte ReadRawData(short registerAddress, short[] rawData)
        {
            if (String.IsNullOrEmpty(serialPort))
                return 255;

            var resp = OpenConnection();           

            if (resp != 1 && resp != 2)
                return 1;

            resp = Interop.ReadMultipleRegisters(GetSerialPort(), 1, Byte.Parse(modbusAddress), registerAddress, (byte)rawData.Length, rawData);

            if (resp != 1)
                return 2;

            resp = Interop.CloseConnection(GetSerialPort());

            if (resp != 1)
                return 3;

            return 0;           
        }

        internal string GetCurrentOutputType()
        {
            byte outputTypeCode;
            ReadByteFromDevice(29061, out outputTypeCode);
            return OutputTypes[outputTypeCode];
        }        

        internal string ReadInputValue()
        {
            float readvalue;
            ReadFloatFromDevice(29050, out readvalue);
            return ConvertFloatToString(readvalue, 4);
        }

        private string ConvertFloatToString(float value, int numDecimals)
        {
            return value.ToString("F" + numDecimals, CultureInfo.InvariantCulture);
        }

        private static byte GetOutputCode(string outputType)
        {
            return (byte)OutputTypes.ToList().IndexOf(outputType);
        }

        internal string SetOutputValue(string text)
        {
            var floatValue = ConvertInputTextToFloat(text);           

            var intValue = ConvertFloatToIntRemovingDecimalPlaces(floatValue, 4);

            byte[] bytesToBeWrite = ExtractBytesFromInt(intValue);
            Array.Resize(ref bytesToBeWrite, 5);
            bytesToBeWrite[4] = 1;

            var shortToBeWrite = ConvertByteArrayToShortArray(bytesToBeWrite);

            var resp = WriteRawDataToDevice(29055, shortToBeWrite);

            if (resp == 0)
            {
                return ConvertFloatToString(floatValue, 4);
            }

            throw new Exception(errors[resp]);
        }

        private short[] ConvertByteArrayToShortArray(byte[] bytesToBeWrite)
        {
            var shortToBeWrite = new short[bytesToBeWrite.Length];
            for (int i = 0; i < bytesToBeWrite.Length; i++)
            {
                shortToBeWrite[i] = (short)bytesToBeWrite[i];
            }
            return shortToBeWrite;
        }

        private byte[] ExtractBytesFromInt(int intValue)
        {
            return BitConverter.GetBytes((UInt32)(intValue)).Reverse().ToArray();            
        }

        private float ConvertInputTextToFloat(string text)
        {
            return Convert.ToSingle(text, CultureInfo.InvariantCulture);
        }

        private int ConvertFloatToIntRemovingDecimalPlaces(float floatValue, int numDecimals)
        {
            return (int)(floatValue * Math.Pow(10, numDecimals));
        }
    }
}
