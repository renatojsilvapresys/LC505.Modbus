using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presys.Calibrators.Comm.LC505.Modbus
{
    public class DataConverters
    {
        public static int ConvertRawDataToInt32(short[] bytes)
        {
            return (int)((bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3]);
        }

        public static float ConvertInt32ToFloat(int value, int numDecimals)
        {
            return (float)(value / Math.Pow(10, numDecimals));
        }

        public static string ConvertFloatToString(float value, int numDecimals)
        {
            return value.ToString("F" + numDecimals, CultureInfo.InvariantCulture);
        }

        public static short[] ConvertByteArrayToShortArray(byte[] bytesToBeWrite)
        {
            var shortToBeWrite = new short[bytesToBeWrite.Length];
            for (int i = 0; i < bytesToBeWrite.Length; i++)
            {
                shortToBeWrite[i] = (short)bytesToBeWrite[i];
            }
            return shortToBeWrite;
        }

        public static byte[] ExtractBytesFromInt(int intValue)
        {
            return BitConverter.GetBytes((UInt32)(intValue)).Reverse().ToArray();
        }

        public static float ConvertInputTextToFloat(string text)
        {
            return Convert.ToSingle(text, CultureInfo.InvariantCulture);
        }

        public static int ConvertFloatToIntRemovingDecimalPlaces(float floatValue, int numDecimals)
        {
            return (int)(floatValue * Math.Pow(10, numDecimals));
        }
    }
}
