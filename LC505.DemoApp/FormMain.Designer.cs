namespace LC505.DemoApp
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelComPort = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.labelModbusAddress = new System.Windows.Forms.Label();
            this.buttonInitiateComm = new System.Windows.Forms.Button();
            this.buttonStopComm = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonOutputUpdate = new System.Windows.Forms.Button();
            this.buttonInputUpdate = new System.Windows.Forms.Button();
            this.textBoxOutputValue = new System.Windows.Forms.TextBox();
            this.labelOutputValue = new System.Windows.Forms.Label();
            this.textBoxInputValue = new System.Windows.Forms.TextBox();
            this.labelInputValue = new System.Windows.Forms.Label();
            this.labelOutputType = new System.Windows.Forms.Label();
            this.labelInputType = new System.Windows.Forms.Label();
            this.comboBoxOutputType = new System.Windows.Forms.ComboBox();
            this.comboBoxInputType = new System.Windows.Forms.ComboBox();
            this.numericUpDownModbusAddress = new System.Windows.Forms.NumericUpDown();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModbusAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Location = new System.Drawing.Point(22, 18);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(57, 13);
            this.labelComPort.TabIndex = 11;
            this.labelComPort.Text = "COM Port";
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(25, 34);
            this.comboBoxComPort.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComPort.TabIndex = 0;
            // 
            // labelModbusAddress
            // 
            this.labelModbusAddress.AutoSize = true;
            this.labelModbusAddress.Location = new System.Drawing.Point(153, 18);
            this.labelModbusAddress.Name = "labelModbusAddress";
            this.labelModbusAddress.Size = new System.Drawing.Size(94, 13);
            this.labelModbusAddress.TabIndex = 12;
            this.labelModbusAddress.Text = "Modbus Address";
            // 
            // buttonInitiateComm
            // 
            this.buttonInitiateComm.Location = new System.Drawing.Point(288, 32);
            this.buttonInitiateComm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInitiateComm.Name = "buttonInitiateComm";
            this.buttonInitiateComm.Size = new System.Drawing.Size(100, 23);
            this.buttonInitiateComm.TabIndex = 14;
            this.buttonInitiateComm.Text = "Initiate COM";
            this.buttonInitiateComm.UseVisualStyleBackColor = true;
            this.buttonInitiateComm.Click += new System.EventHandler(this.buttonInitiateComm_Click);
            // 
            // buttonStopComm
            // 
            this.buttonStopComm.Enabled = false;
            this.buttonStopComm.Location = new System.Drawing.Point(390, 32);
            this.buttonStopComm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStopComm.Name = "buttonStopComm";
            this.buttonStopComm.Size = new System.Drawing.Size(100, 23);
            this.buttonStopComm.TabIndex = 15;
            this.buttonStopComm.Text = "Stop COM";
            this.buttonStopComm.UseVisualStyleBackColor = true;
            this.buttonStopComm.Click += new System.EventHandler(this.buttonFinishComm_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.buttonOutputUpdate);
            this.panelMain.Controls.Add(this.buttonInputUpdate);
            this.panelMain.Controls.Add(this.textBoxOutputValue);
            this.panelMain.Controls.Add(this.labelOutputValue);
            this.panelMain.Controls.Add(this.textBoxInputValue);
            this.panelMain.Controls.Add(this.labelInputValue);
            this.panelMain.Controls.Add(this.labelOutputType);
            this.panelMain.Controls.Add(this.labelInputType);
            this.panelMain.Controls.Add(this.comboBoxOutputType);
            this.panelMain.Controls.Add(this.comboBoxInputType);
            this.panelMain.Location = new System.Drawing.Point(25, 77);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(465, 128);
            this.panelMain.TabIndex = 16;
            // 
            // buttonOutputUpdate
            // 
            this.buttonOutputUpdate.Location = new System.Drawing.Point(382, 85);
            this.buttonOutputUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOutputUpdate.Name = "buttonOutputUpdate";
            this.buttonOutputUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputUpdate.TabIndex = 15;
            this.buttonOutputUpdate.Text = "Update";
            this.buttonOutputUpdate.UseVisualStyleBackColor = true;
            this.buttonOutputUpdate.Click += new System.EventHandler(this.buttonOutputUpdate_Click);
            // 
            // buttonInputUpdate
            // 
            this.buttonInputUpdate.Location = new System.Drawing.Point(141, 86);
            this.buttonInputUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInputUpdate.Name = "buttonInputUpdate";
            this.buttonInputUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonInputUpdate.TabIndex = 12;
            this.buttonInputUpdate.Text = "Update";
            this.buttonInputUpdate.UseVisualStyleBackColor = true;
            this.buttonInputUpdate.Click += new System.EventHandler(this.buttonInputUpdate_Click);
            // 
            // textBoxOutputValue
            // 
            this.textBoxOutputValue.Location = new System.Drawing.Point(255, 86);
            this.textBoxOutputValue.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxOutputValue.Name = "textBoxOutputValue";
            this.textBoxOutputValue.Size = new System.Drawing.Size(121, 22);
            this.textBoxOutputValue.TabIndex = 14;
            // 
            // labelOutputValue
            // 
            this.labelOutputValue.AutoSize = true;
            this.labelOutputValue.Location = new System.Drawing.Point(252, 70);
            this.labelOutputValue.Name = "labelOutputValue";
            this.labelOutputValue.Size = new System.Drawing.Size(76, 13);
            this.labelOutputValue.TabIndex = 16;
            this.labelOutputValue.Text = "Output Value";
            // 
            // textBoxInputValue
            // 
            this.textBoxInputValue.Enabled = false;
            this.textBoxInputValue.Location = new System.Drawing.Point(10, 86);
            this.textBoxInputValue.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxInputValue.Name = "textBoxInputValue";
            this.textBoxInputValue.Size = new System.Drawing.Size(121, 22);
            this.textBoxInputValue.TabIndex = 10;
            // 
            // labelInputValue
            // 
            this.labelInputValue.AutoSize = true;
            this.labelInputValue.Location = new System.Drawing.Point(7, 70);
            this.labelInputValue.Name = "labelInputValue";
            this.labelInputValue.Size = new System.Drawing.Size(66, 13);
            this.labelInputValue.TabIndex = 13;
            this.labelInputValue.Text = "Input Value";
            // 
            // labelOutputType
            // 
            this.labelOutputType.AutoSize = true;
            this.labelOutputType.Location = new System.Drawing.Point(252, 12);
            this.labelOutputType.Name = "labelOutputType";
            this.labelOutputType.Size = new System.Drawing.Size(70, 13);
            this.labelOutputType.TabIndex = 11;
            this.labelOutputType.Text = "Output Type";
            // 
            // labelInputType
            // 
            this.labelInputType.AutoSize = true;
            this.labelInputType.Location = new System.Drawing.Point(7, 12);
            this.labelInputType.Name = "labelInputType";
            this.labelInputType.Size = new System.Drawing.Size(60, 13);
            this.labelInputType.TabIndex = 8;
            this.labelInputType.Text = "Input Type";
            // 
            // comboBoxOutputType
            // 
            this.comboBoxOutputType.FormattingEnabled = true;
            this.comboBoxOutputType.Location = new System.Drawing.Point(255, 28);
            this.comboBoxOutputType.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxOutputType.Name = "comboBoxOutputType";
            this.comboBoxOutputType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOutputType.TabIndex = 9;
            // 
            // comboBoxInputType
            // 
            this.comboBoxInputType.FormattingEnabled = true;
            this.comboBoxInputType.Location = new System.Drawing.Point(10, 28);
            this.comboBoxInputType.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxInputType.Name = "comboBoxInputType";
            this.comboBoxInputType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInputType.TabIndex = 7;
            // 
            // numericUpDownModbusAddress
            // 
            this.numericUpDownModbusAddress.Location = new System.Drawing.Point(156, 34);
            this.numericUpDownModbusAddress.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownModbusAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownModbusAddress.Name = "numericUpDownModbusAddress";
            this.numericUpDownModbusAddress.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownModbusAddress.TabIndex = 17;
            this.numericUpDownModbusAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 221);
            this.Controls.Add(this.numericUpDownModbusAddress);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.buttonStopComm);
            this.Controls.Add(this.buttonInitiateComm);
            this.Controls.Add(this.labelModbusAddress);
            this.Controls.Add(this.labelComPort);
            this.Controls.Add(this.comboBoxComPort);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LC-505";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModbusAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Label labelModbusAddress;
        private System.Windows.Forms.Button buttonInitiateComm;
        private System.Windows.Forms.Button buttonStopComm;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonOutputUpdate;
        private System.Windows.Forms.Button buttonInputUpdate;
        private System.Windows.Forms.TextBox textBoxOutputValue;
        private System.Windows.Forms.Label labelOutputValue;
        private System.Windows.Forms.TextBox textBoxInputValue;
        private System.Windows.Forms.Label labelInputValue;
        private System.Windows.Forms.Label labelOutputType;
        private System.Windows.Forms.Label labelInputType;
        private System.Windows.Forms.ComboBox comboBoxOutputType;
        private System.Windows.Forms.ComboBox comboBoxInputType;
        private System.Windows.Forms.NumericUpDown numericUpDownModbusAddress;
    }
}

