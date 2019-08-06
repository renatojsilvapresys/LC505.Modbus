# LC505 Modbus

#### LC505 Modbus is a library that help to connect to LC-505 calibrator.

#### Add Presys.LC505.Modbus.dll and Modbus.dll into the project. The library uses .NET Framework 4.6.1. If necessary download and install it from https://www.microsoft.com/en-us/download/details.aspx?id=49981

#### See the code below to use the library. Supposing that COM port is COM1 and modbus address is 1 (first and second arguments. The others arguments ("5", "0", "1", "0", "500", "50") should not be changed). The device must be in EXEC mode:

```
private Presys.Calibrators.Comm.LC505.Modbus.LC505 device = new Presys.Calibrators.Comm.LC505.Modbus.LC505();

device.InitiateComm(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                                "COM1", "1", "5", "0", "1", "0", "500", "50"));

device.ChangeInputType("V"); \\ change input to read volt 
string result = device.ReadInputValue(); \\ Read input in volts

device.ChangeInputType("mA"); \\ change input to read mA
result = device.ReadInputValue(); \\ Read input in mA

device.ChangeInputType("None"); \\ disable input

device.ChangeOutputType("V"); \\  change output to generate volt
device.SetOutputValue("1.0000"); \\ set output to 1.0000 V 
device.SetOutputValue("1"); \\ set output to 1.0000 V 

device.ChangeOutputType("mA"); \\ change input to read mA
device.ChangeOutputType("None"); \\ disable input

device.FinishComm(); \\ finish the communication. To connect again, it is necessary to call device.InitiateComm again.

```



