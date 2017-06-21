namespace Resight_Program
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_Rcon = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.TXT_Rpack = new System.Windows.Forms.TextBox();
            this.CB_Rbaud = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Rport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Lcon = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.CB_Lbaud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_Lpack = new System.Windows.Forms.TextBox();
            this.CB_Lport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TXT_Rbat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TXT_Rmac = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TXT_Rsta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXT_Rver = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXT_Lmac = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TXT_Lbat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TXT_Lsta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXT_Lver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TabAcc = new System.Windows.Forms.TabPage();
            this.TabPressure = new System.Windows.Forms.TabPage();
            this.Left_Bottom_graph = new ZedGraph.ZedGraphControl();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Resight_6_graph = new ZedGraph.ZedGraphControl();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.Center_graph = new ZedGraph.ZedGraphControl();
            this.Left_Top_graph = new ZedGraph.ZedGraphControl();
            this.Resight_4_graph = new ZedGraph.ZedGraphControl();
            this.TAB_Select = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TabPressure.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.TAB_Select.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_Rcon);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.TXT_Rpack);
            this.groupBox1.Controls.Add(this.CB_Rbaud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_Rport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(560, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Configuration";
            // 
            // BTN_Rcon
            // 
            this.BTN_Rcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Rcon.Location = new System.Drawing.Point(237, 26);
            this.BTN_Rcon.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Rcon.Name = "BTN_Rcon";
            this.BTN_Rcon.Size = new System.Drawing.Size(66, 26);
            this.BTN_Rcon.TabIndex = 14;
            this.BTN_Rcon.Text = "Connect";
            this.BTN_Rcon.UseVisualStyleBackColor = true;
            this.BTN_Rcon.Click += new System.EventHandler(this.BTN_Rcon_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(309, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 12;
            this.label13.Text = "Packet";
            // 
            // TXT_Rpack
            // 
            this.TXT_Rpack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Rpack.Location = new System.Drawing.Point(352, 27);
            this.TXT_Rpack.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Rpack.Multiline = true;
            this.TXT_Rpack.Name = "TXT_Rpack";
            this.TXT_Rpack.Size = new System.Drawing.Size(199, 20);
            this.TXT_Rpack.TabIndex = 8;
            // 
            // CB_Rbaud
            // 
            this.CB_Rbaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Rbaud.FormattingEnabled = true;
            this.CB_Rbaud.Location = new System.Drawing.Point(162, 27);
            this.CB_Rbaud.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Rbaud.Name = "CB_Rbaud";
            this.CB_Rbaud.Size = new System.Drawing.Size(70, 23);
            this.CB_Rbaud.TabIndex = 6;
            this.CB_Rbaud.Text = "115200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Baud";
            // 
            // CB_Rport
            // 
            this.CB_Rport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Rport.FormattingEnabled = true;
            this.CB_Rport.Location = new System.Drawing.Point(66, 27);
            this.CB_Rport.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Rport.Name = "CB_Rport";
            this.CB_Rport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_Rport.Size = new System.Drawing.Size(59, 23);
            this.CB_Rport.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right Port";
            // 
            // BTN_Lcon
            // 
            this.BTN_Lcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Lcon.Location = new System.Drawing.Point(257, 439);
            this.BTN_Lcon.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Lcon.Name = "BTN_Lcon";
            this.BTN_Lcon.Size = new System.Drawing.Size(66, 25);
            this.BTN_Lcon.TabIndex = 15;
            this.BTN_Lcon.Text = "Connect";
            this.BTN_Lcon.UseVisualStyleBackColor = true;
            this.BTN_Lcon.Click += new System.EventHandler(this.BTN_Lcon_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(346, 455);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 13;
            this.label14.Text = "Packet";
            // 
            // CB_Lbaud
            // 
            this.CB_Lbaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Lbaud.FormattingEnabled = true;
            this.CB_Lbaud.Location = new System.Drawing.Point(157, 452);
            this.CB_Lbaud.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Lbaud.Name = "CB_Lbaud";
            this.CB_Lbaud.Size = new System.Drawing.Size(70, 23);
            this.CB_Lbaud.TabIndex = 11;
            this.CB_Lbaud.Text = "115200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(537, 461);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Baud";
            // 
            // TXT_Lpack
            // 
            this.TXT_Lpack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Lpack.Location = new System.Drawing.Point(725, 488);
            this.TXT_Lpack.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Lpack.Multiline = true;
            this.TXT_Lpack.Name = "TXT_Lpack";
            this.TXT_Lpack.Size = new System.Drawing.Size(516, 10);
            this.TXT_Lpack.TabIndex = 8;
            // 
            // CB_Lport
            // 
            this.CB_Lport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Lport.FormattingEnabled = true;
            this.CB_Lport.Location = new System.Drawing.Point(44, 452);
            this.CB_Lport.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Lport.Name = "CB_Lport";
            this.CB_Lport.Size = new System.Drawing.Size(59, 23);
            this.CB_Lport.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(463, 460);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Left Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TXT_Rbat);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TXT_Rmac);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TXT_Rsta);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TXT_Rver);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(579, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(468, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resight Information";
            // 
            // TXT_Rbat
            // 
            this.TXT_Rbat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Rbat.Location = new System.Drawing.Point(423, 28);
            this.TXT_Rbat.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Rbat.Name = "TXT_Rbat";
            this.TXT_Rbat.Size = new System.Drawing.Size(28, 21);
            this.TXT_Rbat.TabIndex = 21;
            this.TXT_Rbat.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(375, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Battery";
            // 
            // TXT_Rmac
            // 
            this.TXT_Rmac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Rmac.Location = new System.Drawing.Point(276, 27);
            this.TXT_Rmac.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Rmac.Name = "TXT_Rmac";
            this.TXT_Rmac.Size = new System.Drawing.Size(95, 21);
            this.TXT_Rmac.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(167, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "EDR_Mac_Address";
            // 
            // TXT_Rsta
            // 
            this.TXT_Rsta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Rsta.Location = new System.Drawing.Point(127, 27);
            this.TXT_Rsta.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Rsta.Name = "TXT_Rsta";
            this.TXT_Rsta.Size = new System.Drawing.Size(36, 21);
            this.TXT_Rsta.TabIndex = 18;
            this.TXT_Rsta.Text = "Sleep";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "State";
            // 
            // TXT_Rver
            // 
            this.TXT_Rver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Rver.Location = new System.Drawing.Point(60, 28);
            this.TXT_Rver.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Rver.Name = "TXT_Rver";
            this.TXT_Rver.Size = new System.Drawing.Size(31, 21);
            this.TXT_Rver.TabIndex = 14;
            this.TXT_Rver.Text = "3.14";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Right Ver";
            // 
            // TXT_Lmac
            // 
            this.TXT_Lmac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Lmac.Location = new System.Drawing.Point(157, 449);
            this.TXT_Lmac.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Lmac.Name = "TXT_Lmac";
            this.TXT_Lmac.Size = new System.Drawing.Size(163, 21);
            this.TXT_Lmac.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1228, 470);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "EDR_Mac_Address";
            // 
            // TXT_Lbat
            // 
            this.TXT_Lbat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Lbat.Location = new System.Drawing.Point(466, 457);
            this.TXT_Lbat.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Lbat.Name = "TXT_Lbat";
            this.TXT_Lbat.Size = new System.Drawing.Size(28, 21);
            this.TXT_Lbat.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(374, 452);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Battery";
            // 
            // TXT_Lsta
            // 
            this.TXT_Lsta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Lsta.Location = new System.Drawing.Point(395, 452);
            this.TXT_Lsta.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Lsta.Name = "TXT_Lsta";
            this.TXT_Lsta.Size = new System.Drawing.Size(36, 21);
            this.TXT_Lsta.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(576, 479);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "State";
            // 
            // TXT_Lver
            // 
            this.TXT_Lver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Lver.Location = new System.Drawing.Point(1188, 448);
            this.TXT_Lver.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_Lver.Name = "TXT_Lver";
            this.TXT_Lver.Size = new System.Drawing.Size(31, 21);
            this.TXT_Lver.TabIndex = 15;
            this.TXT_Lver.TextChanged += new System.EventHandler(this.TXT_Lver_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1104, 454);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Left Ver";
            // 
            // TabAcc
            // 
            this.TabAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabAcc.Location = new System.Drawing.Point(4, 27);
            this.TabAcc.Margin = new System.Windows.Forms.Padding(2);
            this.TabAcc.Name = "TabAcc";
            this.TabAcc.Padding = new System.Windows.Forms.Padding(2);
            this.TabAcc.Size = new System.Drawing.Size(1625, 835);
            this.TabAcc.TabIndex = 1;
            this.TabAcc.Text = "Acc";
            this.TabAcc.UseVisualStyleBackColor = true;
            this.TabAcc.Click += new System.EventHandler(this.TabAcc_Click);
            // 
            // TabPressure
            // 
            this.TabPressure.Controls.Add(this.Left_Bottom_graph);
            this.TabPressure.Controls.Add(this.label12);
            this.TabPressure.Controls.Add(this.groupBox7);
            this.TabPressure.Controls.Add(this.TXT_Lpack);
            this.TabPressure.Controls.Add(this.Resight_4_graph);
            this.TabPressure.Controls.Add(this.label5);
            this.TabPressure.Controls.Add(this.TXT_Lver);
            this.TabPressure.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TabPressure.Location = new System.Drawing.Point(4, 27);
            this.TabPressure.Margin = new System.Windows.Forms.Padding(2);
            this.TabPressure.Name = "TabPressure";
            this.TabPressure.Padding = new System.Windows.Forms.Padding(2);
            this.TabPressure.Size = new System.Drawing.Size(1625, 835);
            this.TabPressure.TabIndex = 0;
            this.TabPressure.Text = "Pressure";
            this.TabPressure.UseVisualStyleBackColor = true;
            this.TabPressure.Click += new System.EventHandler(this.TabPressure_Click);
            // 
            // Left_Bottom_graph
            // 
            this.Left_Bottom_graph.BackColor = System.Drawing.Color.Gray;
            this.Left_Bottom_graph.Location = new System.Drawing.Point(14, 462);
            this.Left_Bottom_graph.Margin = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.Left_Bottom_graph.Name = "Left_Bottom_graph";
            this.Left_Bottom_graph.ScrollGrace = 0D;
            this.Left_Bottom_graph.ScrollMaxX = 0D;
            this.Left_Bottom_graph.ScrollMaxY = 0D;
            this.Left_Bottom_graph.ScrollMaxY2 = 0D;
            this.Left_Bottom_graph.ScrollMinX = 0D;
            this.Left_Bottom_graph.ScrollMinY = 0D;
            this.Left_Bottom_graph.ScrollMinY2 = 0D;
            this.Left_Bottom_graph.Size = new System.Drawing.Size(471, 372);
            this.Left_Bottom_graph.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.TXT_Lmac);
            this.groupBox7.Controls.Add(this.BTN_Lcon);
            this.groupBox7.Controls.Add(this.Resight_6_graph);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.TXT_Lbat);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.BTN_Start);
            this.groupBox7.Controls.Add(this.Center_graph);
            this.groupBox7.Controls.Add(this.Left_Top_graph);
            this.groupBox7.Controls.Add(this.CB_Lbaud);
            this.groupBox7.Controls.Add(this.TXT_Lsta);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.CB_Lport);
            this.groupBox7.Location = new System.Drawing.Point(520, 7);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(521, 824);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            // 
            // Resight_6_graph
            // 
            this.Resight_6_graph.BackColor = System.Drawing.Color.Transparent;
            this.Resight_6_graph.EditButtons = System.Windows.Forms.MouseButtons.Middle;
            this.Resight_6_graph.Location = new System.Drawing.Point(11, 15);
            this.Resight_6_graph.Margin = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.Resight_6_graph.Name = "Resight_6_graph";
            this.Resight_6_graph.ScrollGrace = 0D;
            this.Resight_6_graph.ScrollMaxX = 0D;
            this.Resight_6_graph.ScrollMaxY = 0D;
            this.Resight_6_graph.ScrollMaxY2 = 0D;
            this.Resight_6_graph.ScrollMinX = 0D;
            this.Resight_6_graph.ScrollMinY = 0D;
            this.Resight_6_graph.ScrollMinY2 = 0D;
            this.Resight_6_graph.Size = new System.Drawing.Size(471, 372);
            this.Resight_6_graph.TabIndex = 1;
            this.Resight_6_graph.Load += new System.EventHandler(this.Resight_6_graph_Load);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Enabled = false;
            this.BTN_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Start.Location = new System.Drawing.Point(304, 392);
            this.BTN_Start.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(178, 43);
            this.BTN_Start.TabIndex = 6;
            this.BTN_Start.Text = "START";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // Center_graph
            // 
            this.Center_graph.EditButtons = System.Windows.Forms.MouseButtons.Middle;
            this.Center_graph.Location = new System.Drawing.Point(16, 523);
            this.Center_graph.Margin = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.Center_graph.Name = "Center_graph";
            this.Center_graph.ScrollGrace = 0D;
            this.Center_graph.ScrollMaxX = 0D;
            this.Center_graph.ScrollMaxY = 0D;
            this.Center_graph.ScrollMaxY2 = 0D;
            this.Center_graph.ScrollMinX = 0D;
            this.Center_graph.ScrollMinY = 0D;
            this.Center_graph.ScrollMinY2 = 0D;
            this.Center_graph.Size = new System.Drawing.Size(605, 397);
            this.Center_graph.TabIndex = 5;
            // 
            // Left_Top_graph
            // 
            this.Left_Top_graph.EditButtons = System.Windows.Forms.MouseButtons.Middle;
            this.Left_Top_graph.Location = new System.Drawing.Point(-60, 523);
            this.Left_Top_graph.Margin = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.Left_Top_graph.Name = "Left_Top_graph";
            this.Left_Top_graph.ScrollGrace = 0D;
            this.Left_Top_graph.ScrollMaxX = 0D;
            this.Left_Top_graph.ScrollMaxY = 0D;
            this.Left_Top_graph.ScrollMaxY2 = 0D;
            this.Left_Top_graph.ScrollMinX = 0D;
            this.Left_Top_graph.ScrollMinY = 0D;
            this.Left_Top_graph.ScrollMinY2 = 0D;
            this.Left_Top_graph.Size = new System.Drawing.Size(471, 292);
            this.Left_Top_graph.TabIndex = 0;
            // 
            // Resight_4_graph
            // 
            this.Resight_4_graph.Location = new System.Drawing.Point(35, 22);
            this.Resight_4_graph.Margin = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.Resight_4_graph.Name = "Resight_4_graph";
            this.Resight_4_graph.ScrollGrace = 0D;
            this.Resight_4_graph.ScrollMaxX = 0D;
            this.Resight_4_graph.ScrollMaxY = 0D;
            this.Resight_4_graph.ScrollMaxY2 = 0D;
            this.Resight_4_graph.ScrollMinX = 0D;
            this.Resight_4_graph.ScrollMinY = 0D;
            this.Resight_4_graph.ScrollMinY2 = 0D;
            this.Resight_4_graph.Size = new System.Drawing.Size(471, 372);
            this.Resight_4_graph.TabIndex = 3;
            this.Resight_4_graph.Load += new System.EventHandler(this.Resight_4_graph_Load);
            // 
            // TAB_Select
            // 
            this.TAB_Select.Controls.Add(this.TabPressure);
            this.TAB_Select.Controls.Add(this.TabAcc);
            this.TAB_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAB_Select.Location = new System.Drawing.Point(8, 95);
            this.TAB_Select.Margin = new System.Windows.Forms.Padding(2);
            this.TAB_Select.Name = "TAB_Select";
            this.TAB_Select.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TAB_Select.SelectedIndex = 0;
            this.TAB_Select.Size = new System.Drawing.Size(1633, 866);
            this.TAB_Select.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TAB_Select.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1075, 566);
            this.Controls.Add(this.TAB_Select);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TabPressure.ResumeLayout(false);
            this.TabPressure.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.TAB_Select.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_Lcon;
        private System.Windows.Forms.Button BTN_Rcon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CB_Lbaud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_Lpack;
        private System.Windows.Forms.TextBox TXT_Rpack;
        private System.Windows.Forms.ComboBox CB_Rbaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Lport;
        private System.Windows.Forms.ComboBox CB_Rport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TXT_Lmac;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TXT_Rbat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TXT_Rmac;
        private System.Windows.Forms.TextBox TXT_Lbat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXT_Lsta;
        private System.Windows.Forms.TextBox TXT_Rsta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXT_Lver;
        private System.Windows.Forms.TextBox TXT_Rver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage TabAcc;
        private System.Windows.Forms.TabPage TabPressure;
        private ZedGraph.ZedGraphControl Resight_4_graph;
        private ZedGraph.ZedGraphControl Left_Bottom_graph;
        private ZedGraph.ZedGraphControl Resight_6_graph;
        private ZedGraph.ZedGraphControl Left_Top_graph;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button BTN_Start;
        private ZedGraph.ZedGraphControl Center_graph;
        private System.Windows.Forms.TabControl TAB_Select;
    }
}

