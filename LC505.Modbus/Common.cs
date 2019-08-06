using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presys.Calibrators.Comm.LC505.Modbus
{
    public static class Common
    {
        public static Dictionary<byte, string> Errors = new Dictionary<byte, string>()
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
    }
}
