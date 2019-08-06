using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presys.Calibrators.Comm.LC505.Modbus
{
    public static class Interop
    {

        [DllImport("Modbus.dll", EntryPoint = "_OpenConnection@28", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Byte OpenConnection(Byte portCom, Byte baudRate, Byte parity, Byte length, Byte stop, Int16 readTimeout, Int16 minTimeInterChar);

        [DllImport("Modbus.dll", EntryPoint = "_CloseConnection@4", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Byte CloseConnection(Byte portCom);

        [DllImport("Modbus.dll", EntryPoint = "_ModbusFuncLeRegs@24", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Byte ReadMultipleRegisters(Byte portCom, Byte isRtu, Byte modbusAdress, Int16 initialRegister, Byte numberOfRegisters, short[] registers);

        [DllImport("Modbus.dll", EntryPoint = "_ModbusFuncEscMultiRegs@24", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Byte WriteMultipleRegisters(Byte portCom, Byte isRtu, Byte modbusAdress, Int16 initialRegister, Byte numberOfRegisters, short[] registers);

       
    }
}
