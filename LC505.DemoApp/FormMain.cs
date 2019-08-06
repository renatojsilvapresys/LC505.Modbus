using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace LC505.DemoApp
{
    public partial class FormMain : Form
    {
        private Presys.Calibrators.Comm.LC505.Modbus.LC505 device;

        public FormMain()
        {
            InitializeComponent();
            device = new Presys.Calibrators.Comm.LC505.Modbus.LC505();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxComPort.DataSource = SerialPort.GetPortNames();

            comboBoxInputType.DataSource = Presys.Calibrators.Comm.LC505.Modbus.LC505.GetInputTypes();
            comboBoxOutputType.DataSource = Presys.Calibrators.Comm.LC505.Modbus.LC505.GetOuputTypes();           

            ClearForm();

            comboBoxInputType.SelectedIndexChanged += comboBoxInputType_SelectedIndexChanged;
            comboBoxOutputType.SelectedIndexChanged += comboBoxOutputType_SelectedIndexChanged;
        }

        private void buttonInitiateComm_Click(object sender, EventArgs e)
        {
            device.InitiateComm(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                comboBoxComPort.Text, numericUpDownModbusAddress.Text, 
                "5", "0", "1", "0", "500", "50"));
            StartForm();
        }

        private void buttonFinishComm_Click(object sender, EventArgs e)
        {
            device.FinishComm();
            ClearForm();
        }

        private void comboBoxInputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                device.ChangeInputType(comboBoxInputType.Text);
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }       

        private void comboBoxOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                device.ChangeOutputType(comboBoxOutputType.Text);
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void buttonInputUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxInputValue.Text = device.ReadInputValue();
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void buttonOutputUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxOutputValue.Text = device.SetOutputValue(textBoxOutputValue.Text);
            }
            catch (FormatException ex)
            {             
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }       

        private void StartForm()
        {
            panelMain.Enabled = buttonStopComm.Enabled = true;
            comboBoxComPort.Enabled = numericUpDownModbusAddress.Enabled = buttonInitiateComm.Enabled = !panelMain.Enabled;

            try
            {
                comboBoxInputType.SelectedItem = device.GetCurrentInputType();
                comboBoxOutputType.SelectedItem = device.GetCurrentOutputType();
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void ClearForm()
        {
            panelMain.Enabled = buttonStopComm.Enabled = false;
            buttonInitiateComm.Enabled = !panelMain.Enabled;
            comboBoxComPort.Enabled = numericUpDownModbusAddress.Enabled = buttonInitiateComm.Enabled = !panelMain.Enabled;

            comboBoxInputType.SelectedItem = "None";
            comboBoxOutputType.SelectedItem = "None";

            textBoxInputValue.Text = String.Empty;
            textBoxOutputValue.Text = String.Empty;
        }
    }
}
