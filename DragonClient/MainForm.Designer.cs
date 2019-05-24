using System.Drawing;
namespace DragonClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.button_SendPacket = new System.Windows.Forms.Button();
            this.textBox_SendPacket = new System.Windows.Forms.TextBox();
            this.textBox_LogArea = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBox_World = new System.Windows.Forms.ComboBox();
            this.textBox_CharacterName = new System.Windows.Forms.TextBox();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.textBox_AcctName = new System.Windows.Forms.TextBox();
            this.groupBox_AdditionalOptions = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_NoticeMsg = new System.Windows.Forms.TextBox();
            this.button_Notice = new System.Windows.Forms.Button();
            this.checkBox_Notice_Hour = new System.Windows.Forms.CheckBox();
            this.checkBox_CollectMail = new System.Windows.Forms.CheckBox();
            this.checkBox_CollectGold = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoRestart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox_AdditionalOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 120);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(76, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // button_SendPacket
            // 
            this.button_SendPacket.Location = new System.Drawing.Point(232, 202);
            this.button_SendPacket.Name = "button_SendPacket";
            this.button_SendPacket.Size = new System.Drawing.Size(49, 23);
            this.button_SendPacket.TabIndex = 2;
            this.button_SendPacket.Text = "Send";
            this.button_SendPacket.UseVisualStyleBackColor = true;
            this.button_SendPacket.Click += new System.EventHandler(this.button_SendPacket_Click);
            // 
            // textBox_SendPacket
            // 
            this.textBox_SendPacket.Location = new System.Drawing.Point(11, 203);
            this.textBox_SendPacket.Name = "textBox_SendPacket";
            this.textBox_SendPacket.Size = new System.Drawing.Size(215, 20);
            this.textBox_SendPacket.TabIndex = 3;
            // 
            // textBox_LogArea
            // 
            this.textBox_LogArea.ForeColor = System.Drawing.Color.Gray;
            this.textBox_LogArea.Location = new System.Drawing.Point(11, 12);
            this.textBox_LogArea.Multiline = true;
            this.textBox_LogArea.Name = "textBox_LogArea";
            this.textBox_LogArea.Size = new System.Drawing.Size(270, 183);
            this.textBox_LogArea.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.comboBox_World);
            this.groupBox1.Controls.Add(this.textBox_CharacterName);
            this.groupBox1.Controls.Add(this.textBox_Pass);
            this.groupBox1.Controls.Add(this.textBox_AcctName);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(287, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 183);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(6, 149);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(77, 23);
            this.buttonDisconnect.TabIndex = 7;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBox_World
            // 
            this.comboBox_World.FormattingEnabled = true;
            this.comboBox_World.Items.AddRange(new object[] {
            "SEA",
            "TH"});
            this.comboBox_World.Location = new System.Drawing.Point(7, 93);
            this.comboBox_World.Name = "comboBox_World";
            this.comboBox_World.Size = new System.Drawing.Size(76, 21);
            this.comboBox_World.TabIndex = 6;
            this.comboBox_World.Text = "SEA";
            // 
            // textBox_CharacterName
            // 
            this.textBox_CharacterName.Location = new System.Drawing.Point(7, 68);
            this.textBox_CharacterName.Name = "textBox_CharacterName";
            this.textBox_CharacterName.Size = new System.Drawing.Size(76, 20);
            this.textBox_CharacterName.TabIndex = 3;
            this.textBox_CharacterName.Text = "Char Name";
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.Location = new System.Drawing.Point(7, 45);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.Size = new System.Drawing.Size(76, 20);
            this.textBox_Pass.TabIndex = 1;
            this.textBox_Pass.Text = "cleeclo";
            // 
            // textBox_AcctName
            // 
            this.textBox_AcctName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_AcctName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBox_AcctName.Location = new System.Drawing.Point(7, 19);
            this.textBox_AcctName.Name = "textBox_AcctName";
            this.textBox_AcctName.Size = new System.Drawing.Size(76, 20);
            this.textBox_AcctName.TabIndex = 0;
            this.textBox_AcctName.Text = "Name";
            // 
            // groupBox_AdditionalOptions
            // 
            this.groupBox_AdditionalOptions.Controls.Add(this.button1);
            this.groupBox_AdditionalOptions.Controls.Add(this.textBox_NoticeMsg);
            this.groupBox_AdditionalOptions.Controls.Add(this.button_Notice);
            this.groupBox_AdditionalOptions.Controls.Add(this.checkBox_Notice_Hour);
            this.groupBox_AdditionalOptions.Location = new System.Drawing.Point(386, 12);
            this.groupBox_AdditionalOptions.Name = "groupBox_AdditionalOptions";
            this.groupBox_AdditionalOptions.Size = new System.Drawing.Size(165, 213);
            this.groupBox_AdditionalOptions.TabIndex = 6;
            this.groupBox_AdditionalOptions.TabStop = false;
            this.groupBox_AdditionalOptions.Text = "Additional Options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // textBox_NoticeMsg
            // 
            this.textBox_NoticeMsg.Location = new System.Drawing.Point(6, 19);
            this.textBox_NoticeMsg.Name = "textBox_NoticeMsg";
            this.textBox_NoticeMsg.Size = new System.Drawing.Size(153, 20);
            this.textBox_NoticeMsg.TabIndex = 2;
            this.textBox_NoticeMsg.Text = "Enter Notice Msg...";
            // 
            // button_Notice
            // 
            this.button_Notice.Location = new System.Drawing.Point(6, 68);
            this.button_Notice.Name = "button_Notice";
            this.button_Notice.Size = new System.Drawing.Size(153, 23);
            this.button_Notice.TabIndex = 1;
            this.button_Notice.Text = "Notice (Instant)";
            this.button_Notice.UseVisualStyleBackColor = true;
            this.button_Notice.Click += new System.EventHandler(this.button_Notice_Click);
            // 
            // checkBox_Notice_Hour
            // 
            this.checkBox_Notice_Hour.AutoSize = true;
            this.checkBox_Notice_Hour.Location = new System.Drawing.Point(6, 45);
            this.checkBox_Notice_Hour.Name = "checkBox_Notice_Hour";
            this.checkBox_Notice_Hour.Size = new System.Drawing.Size(114, 17);
            this.checkBox_Notice_Hour.TabIndex = 0;
            this.checkBox_Notice_Hour.Text = "Notice (1 per hour)";
            this.checkBox_Notice_Hour.UseVisualStyleBackColor = true;
            // 
            // checkBox_CollectMail
            // 
            this.checkBox_CollectMail.AutoSize = true;
            this.checkBox_CollectMail.Location = new System.Drawing.Point(12, 229);
            this.checkBox_CollectMail.Name = "checkBox_CollectMail";
            this.checkBox_CollectMail.Size = new System.Drawing.Size(80, 17);
            this.checkBox_CollectMail.TabIndex = 7;
            this.checkBox_CollectMail.Text = "Collect Mail";
            this.checkBox_CollectMail.UseVisualStyleBackColor = true;
            this.checkBox_CollectMail.CheckedChanged += new System.EventHandler(this.checkBox_CollectMail_CheckedChanged);
            // 
            // checkBox_CollectGold
            // 
            this.checkBox_CollectGold.AutoSize = true;
            this.checkBox_CollectGold.Location = new System.Drawing.Point(94, 229);
            this.checkBox_CollectGold.Name = "checkBox_CollectGold";
            this.checkBox_CollectGold.Size = new System.Drawing.Size(103, 17);
            this.checkBox_CollectGold.TabIndex = 8;
            this.checkBox_CollectGold.Text = "Collect Pouches";
            this.checkBox_CollectGold.UseVisualStyleBackColor = true;
            this.checkBox_CollectGold.CheckedChanged += new System.EventHandler(this.checkBox_CollectGold_CheckedChanged);
            // 
            // checkBox_AutoRestart
            // 
            this.checkBox_AutoRestart.AutoSize = true;
            this.checkBox_AutoRestart.Location = new System.Drawing.Point(194, 229);
            this.checkBox_AutoRestart.Name = "checkBox_AutoRestart";
            this.checkBox_AutoRestart.Size = new System.Drawing.Size(85, 17);
            this.checkBox_AutoRestart.TabIndex = 9;
            this.checkBox_AutoRestart.Text = "Auto-Restart";
            this.checkBox_AutoRestart.UseVisualStyleBackColor = true;
            this.checkBox_AutoRestart.CheckedChanged += new System.EventHandler(this.checkBox_AutoRestart_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 254);
            this.Controls.Add(this.checkBox_AutoRestart);
            this.Controls.Add(this.checkBox_CollectGold);
            this.Controls.Add(this.checkBox_CollectMail);
            this.Controls.Add(this.groupBox_AdditionalOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_LogArea);
            this.Controls.Add(this.textBox_SendPacket);
            this.Controls.Add(this.button_SendPacket);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DragonClient - By XIAN";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_AdditionalOptions.ResumeLayout(false);
            this.groupBox_AdditionalOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button_SendPacket;
        private System.Windows.Forms.TextBox textBox_SendPacket;
        private System.Windows.Forms.TextBox textBox_LogArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_World;
        private System.Windows.Forms.TextBox textBox_CharacterName;
        private System.Windows.Forms.TextBox textBox_Pass;
        private System.Windows.Forms.TextBox textBox_AcctName;
        private System.Windows.Forms.GroupBox groupBox_AdditionalOptions;
        private System.Windows.Forms.Button button_Notice;
        private System.Windows.Forms.CheckBox checkBox_Notice_Hour;
        private System.Windows.Forms.TextBox textBox_NoticeMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.CheckBox checkBox_CollectMail;
        private System.Windows.Forms.CheckBox checkBox_CollectGold;
        private System.Windows.Forms.CheckBox checkBox_AutoRestart;
    }
}

