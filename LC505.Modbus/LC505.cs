using System;
using System.Linq;

namespace Presys.Calibrators.Comm.LC505.Modbus
{
    public class LC505
    {
        private ModbusHelper modbus;

        public LC505()
        {
        }       

        public static string[] GetInputTypes()
        {
            return Common.InputTypes;
        }

        public static string[] GetOuputTypes()
        {
            return Common.OutputTypes;
        }

        public void InitiateComm(string configuration)
        {
            try
            {
                var serialPort = configuration.Split('|')[0];
                var modbusAddress = configuration.Split('|')[1];
                var baudRate = byte.Parse(configuration.Split('|')[2]);
                var parity = byte.Parse(configuration.Split('|')[3]);
                var length = byte.Parse(configuration.Split('|')[4]);
                var stopBits = byte.Parse(configuration.Split('|')[5]);
                var readTimeout = short.Parse(configuration.Split('|')[6]);
                var minTimeInterChar = short.Parse(configuration.Split('|')[7]);

                modbus = new ModbusHelper(serialPort, modbusAddress, baudRate, parity, length, stopBits, readTimeout, minTimeInterChar);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Configuration. Try to understand how the parameters work.", ex);
            }
        }

        public void FinishComm()
        {
            modbus.ResetData();            
        }        

        public void ChangeInputType(string inputType)
        {
            var resp = WriteByteToDevice(29060, GetInputCode(inputType));

            if (resp != 0 && resp != 255)
            {
                throw new Exception(Common.Errors[resp]);
            }                
        }

        public string GetCurrentInputType()
        {
            byte inputTypeCode;
            ReadByteFromDevice(29060, out inputTypeCode);
            return Common.InputTypes[inputTypeCode];
        }

        public void ChangeOutputType(string outputType)
        {
            var resp = WriteByteToDevice(29061, GetInputCode(outputType));

            if (resp != 0 && resp != 255)
            {
                throw new Exception(Common.Errors[resp]);
            }
        }

        public string GetCurrentOutputType()
        {
            byte outputTypeCode;
            ReadByteFromDevice(29061, out outputTypeCode);
            return Common.OutputTypes[outputTypeCode];
        }

        public string ReadInputValue()
        {
            float readvalue;
            ReadFloatFromDevice(29050, out readvalue);
            return DataConverters.ConvertFloatToString(readvalue, 4);
        }

        public string SetOutputValue(string text)
        {
            var floatValue = DataConverters.ConvertInputTextToFloat(text);

            var intValue = DataConverters.ConvertFloatToIntRemovingDecimalPlaces(floatValue, 4);

            byte[] bytesToBeWrite = DataConverters.ExtractBytesFromInt(intValue);
            Array.Resize(ref bytesToBeWrite, 5);
            bytesToBeWrite[4] = 1;

            var shortToBeWrite = DataConverters.ConvertByteArrayToShortArray(bytesToBeWrite);

            var resp = modbus.WriteRawDataToDevice(29055, shortToBeWrite);

            if (resp == 0)
            {
                return DataConverters.ConvertFloatToString(floatValue, 4);
            }

            throw new Exception(Common.Errors[resp]);
        }

        private static byte GetInputCode(string inputType)
        {
            return (byte)Common.InputTypes.ToList().IndexOf(inputType);
        }

        private static byte GetOutputCode(string outputType)
        {
            return (byte)Common.OutputTypes.ToList().IndexOf(outputType);
        }

        private byte WriteByteToDevice(short address, byte data)
        {
            return modbus.WriteRawDataToDevice(address, new short[] { (short)data });
        }

        private void ReadByteFromDevice(short registerAddress, out byte value)
        {
            short[] bytes = new short[1];
            var resp = modbus.ReadRawData(registerAddress, bytes);

            if (resp == 0)
            {
                value = (byte)bytes[0];
                return;
            }

            throw new Exception(Common.Errors[resp]);
        }

        private void ReadFloatFromDevice(short registerAddress, out float value)
        {
            short[] bytes = new short[4];
            var resp = modbus.ReadRawData(registerAddress, bytes);

            if (resp == 0)
            {
                value = DataConverters.ConvertInt32ToFloat(DataConverters.ConvertRawDataToInt32(bytes), 4);
                return;
            }

            throw new Exception(Common.Errors[resp]);
        }       
    }
}
