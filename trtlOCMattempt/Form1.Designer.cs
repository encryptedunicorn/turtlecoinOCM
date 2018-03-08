namespace trtlOCMattempt
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.difficultyLbl = new System.Windows.Forms.Label();
            this.connectedServerLbl = new System.Windows.Forms.Label();
            this.bestShareLbl = new System.Windows.Forms.Label();
            this.shareCountLbl = new System.Windows.Forms.Label();
            this.hashrateLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.hardwareCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addressTb = new System.Windows.Forms.TextBox();
            this.raindanceRb = new System.Windows.Forms.RadioButton();
            this.addressRb = new System.Windows.Forms.RadioButton();
            this.gpuMiningCheck = new System.Windows.Forms.CheckBox();
            this.advancedCheck = new System.Windows.Forms.CheckBox();
            this.cpuMiningCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.startBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.autoConfigCheck = new System.Windows.Forms.CheckBox();
            this.showCLICheck = new System.Windows.Forms.CheckBox();
            this.writeLogFileTb = new System.Windows.Forms.TextBox();
            this.cpuLowPowerCheck = new System.Windows.Forms.CheckBox();
            this.aesCb = new System.Windows.Forms.ComboBox();
            this.gpuBsleepNum = new System.Windows.Forms.NumericUpDown();
            this.gpuBfactNum = new System.Windows.Forms.NumericUpDown();
            this.gpuBlocksNum = new System.Windows.Forms.NumericUpDown();
            this.gpuThreadsNum = new System.Windows.Forms.NumericUpDown();
            this.cpuThreadNum = new System.Windows.Forms.NumericUpDown();
            this.writeLogCheck = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBsleepNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBfactNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBlocksNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuThreadsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThreadNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.25F);
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turtlecoin (TRTL) Miner";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(540, 100);
            this.panel1.TabIndex = 1;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(477, 70);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(50, 20);
            this.linkLabel3.TabIndex = 2;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "About";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(396, 40);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(131, 20);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Settings explained";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(428, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(99, 20);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Read this first";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10);
            this.label2.Size = new System.Drawing.Size(237, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Based on xmr-stak by fireice-uk";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.difficultyLbl);
            this.panel2.Controls.Add(this.connectedServerLbl);
            this.panel2.Controls.Add(this.bestShareLbl);
            this.panel2.Controls.Add(this.shareCountLbl);
            this.panel2.Controls.Add(this.hashrateLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(540, 135);
            this.panel2.TabIndex = 2;
            // 
            // difficultyLbl
            // 
            this.difficultyLbl.AutoSize = true;
            this.difficultyLbl.Location = new System.Drawing.Point(188, 81);
            this.difficultyLbl.Name = "difficultyLbl";
            this.difficultyLbl.Padding = new System.Windows.Forms.Padding(10);
            this.difficultyLbl.Size = new System.Drawing.Size(92, 40);
            this.difficultyLbl.TabIndex = 2;
            this.difficultyLbl.Text = "Difficulty:";
            // 
            // connectedServerLbl
            // 
            this.connectedServerLbl.AutoSize = true;
            this.connectedServerLbl.Location = new System.Drawing.Point(188, 41);
            this.connectedServerLbl.Name = "connectedServerLbl";
            this.connectedServerLbl.Padding = new System.Windows.Forms.Padding(10);
            this.connectedServerLbl.Size = new System.Drawing.Size(125, 40);
            this.connectedServerLbl.TabIndex = 3;
            this.connectedServerLbl.Text = "Connected to: ";
            // 
            // bestShareLbl
            // 
            this.bestShareLbl.AutoSize = true;
            this.bestShareLbl.Location = new System.Drawing.Point(10, 81);
            this.bestShareLbl.Name = "bestShareLbl";
            this.bestShareLbl.Padding = new System.Windows.Forms.Padding(10);
            this.bestShareLbl.Size = new System.Drawing.Size(60, 40);
            this.bestShareLbl.TabIndex = 1;
            this.bestShareLbl.Text = "Best:";
            // 
            // shareCountLbl
            // 
            this.shareCountLbl.AutoSize = true;
            this.shareCountLbl.Location = new System.Drawing.Point(10, 41);
            this.shareCountLbl.Name = "shareCountLbl";
            this.shareCountLbl.Padding = new System.Windows.Forms.Padding(10);
            this.shareCountLbl.Size = new System.Drawing.Size(79, 40);
            this.shareCountLbl.TabIndex = 1;
            this.shareCountLbl.Text = "Shares: ";
            // 
            // hashrateLbl
            // 
            this.hashrateLbl.AutoSize = true;
            this.hashrateLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.hashrateLbl.Font = new System.Drawing.Font("Segoe UI", 17.25F);
            this.hashrateLbl.ForeColor = System.Drawing.Color.ForestGreen;
            this.hashrateLbl.Location = new System.Drawing.Point(10, 10);
            this.hashrateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hashrateLbl.Name = "hashrateLbl";
            this.hashrateLbl.Size = new System.Drawing.Size(236, 31);
            this.hashrateLbl.TabIndex = 0;
            this.hashrateLbl.Text = "Stats - Hashrate: - H/s";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.hardwareCb);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.addressTb);
            this.panel3.Controls.Add(this.raindanceRb);
            this.panel3.Controls.Add(this.addressRb);
            this.panel3.Controls.Add(this.gpuMiningCheck);
            this.panel3.Controls.Add(this.advancedCheck);
            this.panel3.Controls.Add(this.cpuMiningCheck);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 235);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(540, 218);
            this.panel3.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(446, 173);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 27);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Refresh stats every                    s";
            // 
            // hardwareCb
            // 
            this.hardwareCb.FormattingEnabled = true;
            this.hardwareCb.Items.AddRange(new object[] {
            "Low end",
            "Mid range",
            "High end"});
            this.hardwareCb.Location = new System.Drawing.Point(416, 49);
            this.hardwareCb.Name = "hardwareCb";
            this.hardwareCb.Size = new System.Drawing.Size(102, 28);
            this.hardwareCb.TabIndex = 6;
            this.hardwareCb.Text = "Low end";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Your hardware is:";
            // 
            // addressTb
            // 
            this.addressTb.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.addressTb.Location = new System.Drawing.Point(27, 112);
            this.addressTb.Name = "addressTb";
            this.addressTb.Size = new System.Drawing.Size(491, 27);
            this.addressTb.TabIndex = 4;
            this.addressTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // raindanceRb
            // 
            this.raindanceRb.AutoSize = true;
            this.raindanceRb.Checked = true;
            this.raindanceRb.Location = new System.Drawing.Point(27, 146);
            this.raindanceRb.Name = "raindanceRb";
            this.raindanceRb.Size = new System.Drawing.Size(147, 24);
            this.raindanceRb.TabIndex = 3;
            this.raindanceRb.TabStop = true;
            this.raindanceRb.Text = "Mine to raindance";
            this.raindanceRb.UseVisualStyleBackColor = true;
            // 
            // addressRb
            // 
            this.addressRb.AutoSize = true;
            this.addressRb.Location = new System.Drawing.Point(27, 82);
            this.addressRb.Name = "addressRb";
            this.addressRb.Size = new System.Drawing.Size(190, 24);
            this.addressRb.TabIndex = 3;
            this.addressRb.Text = "Mine to address (TRTL...):";
            this.addressRb.UseVisualStyleBackColor = true;
            // 
            // gpuMiningCheck
            // 
            this.gpuMiningCheck.AutoSize = true;
            this.gpuMiningCheck.Checked = true;
            this.gpuMiningCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gpuMiningCheck.Location = new System.Drawing.Point(88, 51);
            this.gpuMiningCheck.Name = "gpuMiningCheck";
            this.gpuMiningCheck.Size = new System.Drawing.Size(143, 24);
            this.gpuMiningCheck.TabIndex = 2;
            this.gpuMiningCheck.Text = "GPU (if available)";
            this.gpuMiningCheck.UseVisualStyleBackColor = true;
            // 
            // advancedCheck
            // 
            this.advancedCheck.AutoSize = true;
            this.advancedCheck.Location = new System.Drawing.Point(27, 175);
            this.advancedCheck.Name = "advancedCheck";
            this.advancedCheck.Size = new System.Drawing.Size(186, 24);
            this.advancedCheck.TabIndex = 2;
            this.advancedCheck.Text = "Show advanced options";
            this.advancedCheck.UseVisualStyleBackColor = true;
            this.advancedCheck.CheckedChanged += new System.EventHandler(this.advancedCheck_CheckedChanged);
            // 
            // cpuMiningCheck
            // 
            this.cpuMiningCheck.AutoSize = true;
            this.cpuMiningCheck.Checked = true;
            this.cpuMiningCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cpuMiningCheck.Location = new System.Drawing.Point(27, 51);
            this.cpuMiningCheck.Name = "cpuMiningCheck";
            this.cpuMiningCheck.Size = new System.Drawing.Size(55, 24);
            this.cpuMiningCheck.TabIndex = 2;
            this.cpuMiningCheck.Text = "CPU";
            this.cpuMiningCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 17.25F);
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = "Settings";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabel5);
            this.panel4.Controls.Add(this.linkLabel4);
            this.panel4.Controls.Add(this.startBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 453);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(540, 56);
            this.panel4.TabIndex = 4;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(395, 17);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(123, 20);
            this.linkLabel5.TabIndex = 2;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Write config only";
            this.linkLabel5.Visible = false;
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(34, 17);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(79, 20);
            this.linkLabel4.TabIndex = 1;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Ping pools";
            this.linkLabel4.Visible = false;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(192, 10);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(156, 34);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start mining!";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.autoConfigCheck);
            this.panel5.Controls.Add(this.showCLICheck);
            this.panel5.Controls.Add(this.writeLogFileTb);
            this.panel5.Controls.Add(this.cpuLowPowerCheck);
            this.panel5.Controls.Add(this.aesCb);
            this.panel5.Controls.Add(this.gpuBsleepNum);
            this.panel5.Controls.Add(this.gpuBfactNum);
            this.panel5.Controls.Add(this.gpuBlocksNum);
            this.panel5.Controls.Add(this.gpuThreadsNum);
            this.panel5.Controls.Add(this.cpuThreadNum);
            this.panel5.Controls.Add(this.writeLogCheck);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 509);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(540, 218);
            this.panel5.TabIndex = 5;
            // 
            // autoConfigCheck
            // 
            this.autoConfigCheck.AutoSize = true;
            this.autoConfigCheck.Checked = true;
            this.autoConfigCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoConfigCheck.Location = new System.Drawing.Point(133, 15);
            this.autoConfigCheck.Name = "autoConfigCheck";
            this.autoConfigCheck.Size = new System.Drawing.Size(269, 24);
            this.autoConfigCheck.TabIndex = 11;
            this.autoConfigCheck.Text = "Let xmr-stak decide (recommended)";
            this.autoConfigCheck.UseVisualStyleBackColor = true;
            this.autoConfigCheck.CheckedChanged += new System.EventHandler(this.autoConfigCheck_CheckedChanged);
            // 
            // showCLICheck
            // 
            this.showCLICheck.AutoSize = true;
            this.showCLICheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.showCLICheck.Location = new System.Drawing.Point(10, 165);
            this.showCLICheck.Name = "showCLICheck";
            this.showCLICheck.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.showCLICheck.Size = new System.Drawing.Size(520, 34);
            this.showCLICheck.TabIndex = 10;
            this.showCLICheck.Text = "Show CLI";
            this.showCLICheck.UseVisualStyleBackColor = true;
            // 
            // writeLogFileTb
            // 
            this.writeLogFileTb.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.writeLogFileTb.Location = new System.Drawing.Point(115, 143);
            this.writeLogFileTb.Name = "writeLogFileTb";
            this.writeLogFileTb.Size = new System.Drawing.Size(239, 22);
            this.writeLogFileTb.TabIndex = 9;
            this.writeLogFileTb.Text = "trtlminer.log";
            // 
            // cpuLowPowerCheck
            // 
            this.cpuLowPowerCheck.AutoSize = true;
            this.cpuLowPowerCheck.Enabled = false;
            this.cpuLowPowerCheck.Location = new System.Drawing.Point(183, 51);
            this.cpuLowPowerCheck.Name = "cpuLowPowerCheck";
            this.cpuLowPowerCheck.Size = new System.Drawing.Size(144, 24);
            this.cpuLowPowerCheck.TabIndex = 8;
            this.cpuLowPowerCheck.Text = "Low power mode";
            this.cpuLowPowerCheck.UseVisualStyleBackColor = true;
            // 
            // aesCb
            // 
            this.aesCb.Enabled = false;
            this.aesCb.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.aesCb.FormattingEnabled = true;
            this.aesCb.Items.AddRange(new object[] {
            "null",
            "true",
            "false"});
            this.aesCb.Location = new System.Drawing.Point(122, 81);
            this.aesCb.Name = "aesCb";
            this.aesCb.Size = new System.Drawing.Size(121, 21);
            this.aesCb.TabIndex = 7;
            this.aesCb.Text = "null";
            // 
            // gpuBsleepNum
            // 
            this.gpuBsleepNum.Enabled = false;
            this.gpuBsleepNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gpuBsleepNum.Location = new System.Drawing.Point(484, 111);
            this.gpuBsleepNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.gpuBsleepNum.Name = "gpuBsleepNum";
            this.gpuBsleepNum.Size = new System.Drawing.Size(43, 22);
            this.gpuBsleepNum.TabIndex = 6;
            this.gpuBsleepNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gpuBsleepNum.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // gpuBfactNum
            // 
            this.gpuBfactNum.Enabled = false;
            this.gpuBfactNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gpuBfactNum.Location = new System.Drawing.Point(376, 111);
            this.gpuBfactNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.gpuBfactNum.Name = "gpuBfactNum";
            this.gpuBfactNum.Size = new System.Drawing.Size(43, 22);
            this.gpuBfactNum.TabIndex = 6;
            this.gpuBfactNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gpuBfactNum.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // gpuBlocksNum
            // 
            this.gpuBlocksNum.Enabled = false;
            this.gpuBlocksNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gpuBlocksNum.Location = new System.Drawing.Point(278, 111);
            this.gpuBlocksNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.gpuBlocksNum.Name = "gpuBlocksNum";
            this.gpuBlocksNum.Size = new System.Drawing.Size(43, 22);
            this.gpuBlocksNum.TabIndex = 6;
            this.gpuBlocksNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gpuThreadsNum
            // 
            this.gpuThreadsNum.Enabled = false;
            this.gpuThreadsNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gpuThreadsNum.Location = new System.Drawing.Point(174, 111);
            this.gpuThreadsNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.gpuThreadsNum.Name = "gpuThreadsNum";
            this.gpuThreadsNum.Size = new System.Drawing.Size(43, 22);
            this.gpuThreadsNum.TabIndex = 6;
            this.gpuThreadsNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cpuThreadNum
            // 
            this.cpuThreadNum.Enabled = false;
            this.cpuThreadNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cpuThreadNum.Location = new System.Drawing.Point(117, 52);
            this.cpuThreadNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.cpuThreadNum.Name = "cpuThreadNum";
            this.cpuThreadNum.Size = new System.Drawing.Size(60, 22);
            this.cpuThreadNum.TabIndex = 6;
            this.cpuThreadNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // writeLogCheck
            // 
            this.writeLogCheck.AutoSize = true;
            this.writeLogCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.writeLogCheck.Location = new System.Drawing.Point(10, 131);
            this.writeLogCheck.Name = "writeLogCheck";
            this.writeLogCheck.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.writeLogCheck.Size = new System.Drawing.Size(520, 34);
            this.writeLogCheck.TabIndex = 2;
            this.writeLogCheck.Text = "Write log:";
            this.writeLogCheck.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(10, 101);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label11.Size = new System.Drawing.Size(482, 30);
            this.label11.TabIndex = 5;
            this.label11.Text = "GPU options: Threads:               Blocks:               Bfact:               Bs" +
    "leep:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(10, 71);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label8.Size = new System.Drawing.Size(117, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "AES override:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(10, 41);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label9.Size = new System.Drawing.Size(116, 30);
            this.label9.TabIndex = 3;
            this.label9.Text = "CPU threads: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 17.25F);
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Advanced";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 743);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Turtlecoin OneClickMiner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBsleepNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBfactNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuBlocksNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuThreadsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThreadNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label bestShareLbl;
        private System.Windows.Forms.Label shareCountLbl;
        private System.Windows.Forms.Label hashrateLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox addressTb;
        private System.Windows.Forms.RadioButton raindanceRb;
        private System.Windows.Forms.RadioButton addressRb;
        private System.Windows.Forms.CheckBox gpuMiningCheck;
        private System.Windows.Forms.CheckBox advancedCheck;
        private System.Windows.Forms.CheckBox cpuMiningCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox aesCb;
        private System.Windows.Forms.NumericUpDown cpuThreadNum;
        private System.Windows.Forms.CheckBox writeLogCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cpuLowPowerCheck;
        private System.Windows.Forms.NumericUpDown gpuBfactNum;
        private System.Windows.Forms.NumericUpDown gpuBlocksNum;
        private System.Windows.Forms.NumericUpDown gpuThreadsNum;
        private System.Windows.Forms.Label difficultyLbl;
        private System.Windows.Forms.Label connectedServerLbl;
        private System.Windows.Forms.CheckBox showCLICheck;
        private System.Windows.Forms.TextBox writeLogFileTb;
        private System.Windows.Forms.NumericUpDown gpuBsleepNum;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ComboBox hardwareCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox autoConfigCheck;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
    }
}

