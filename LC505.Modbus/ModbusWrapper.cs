using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presys.Calibrators.Comm.LC505.Modbus
{
    public class ModbusHelper
    {
        private string serialPort;
        private string modbusAddress;
        private byte baudRate;
        private byte parity;
        private byte length;
        private byte stopBits;
        private short readTimeout;
        private short minTimeInterChar;

        public ModbusHelper(string serialPort, string modbusAddress, byte baudRate, byte parity,
            byte length, byte stopBits, short readTimeout, short minTimeInterChar)
        {
            this.serialPort = serialPort;
            this.modbusAddress = modbusAddress;
            this.baudRate = baudRate;
            this.parity = parity;
            this.length = length;
            this.stopBits = stopBits;
            this.readTimeout = readTimeout;
            this.minTimeInterChar = minTimeInterChar;
        }

        public void ResetData()
        {
            this.serialPort = String.Empty;
            this.modbusAddress = String.Empty;
        }

        public byte OpenConnection()
        {
            return Interop.OpenConnection(GetSerialPort(), baudRate, parity, length, stopBits, readTimeout, minTimeInterChar);
        }

        public byte GetSerialPort()
        {
            return (byte)((int)Convert.ToByte(serialPort.Replace("COM", String.Empty).Trim()) - 1);
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

        public byte ReadRawData(short registerAddress, short[] rawData)
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
    }
}
