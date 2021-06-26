
namespace NotificationListenerThrower
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PresentLabel = new System.Windows.Forms.Label();
            this.AccessStatusLabel = new System.Windows.Forms.Label();
            this.WatchTimer = new System.Windows.Forms.Timer(this.components);
            this.DetectedListBox = new System.Windows.Forms.ListBox();
            this.DetectedLabel = new System.Windows.Forms.Label();
            this.ConnectedLabel = new System.Windows.Forms.Label();
            this.PingTimer = new System.Windows.Forms.Timer(this.components);
            this.PresentTextBox = new System.Windows.Forms.TextBox();
            this.AccessStatusTextBox = new System.Windows.Forms.TextBox();
            this.ConnectedTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.LocalOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.SendLabel = new System.Windows.Forms.Label();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.ViewerCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PresentLabel
            // 
            this.PresentLabel.AutoSize = true;
            this.PresentLabel.Location = new System.Drawing.Point(13, 13);
            this.PresentLabel.Name = "PresentLabel";
            this.PresentLabel.Size = new System.Drawing.Size(57, 20);
            this.PresentLabel.TabIndex = 0;
            this.PresentLabel.Text = "Present";
            // 
            // AccessStatusLabel
            // 
            this.AccessStatusLabel.AutoSize = true;
            this.AccessStatusLabel.Location = new System.Drawing.Point(128, 13);
            this.AccessStatusLabel.Name = "AccessStatusLabel";
            this.AccessStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.AccessStatusLabel.TabIndex = 2;
            this.AccessStatusLabel.Text = "Status";
            // 
            // WatchTimer
            // 
            this.WatchTimer.Enabled = true;
            this.WatchTimer.Tick += new System.EventHandler(this.WatchTimer_Tick);
            // 
            // DetectedListBox
            // 
            this.DetectedListBox.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetectedListBox.FormattingEnabled = true;
            this.DetectedListBox.ItemHeight = 12;
            this.DetectedListBox.Location = new System.Drawing.Point(13, 82);
            this.DetectedListBox.Name = "DetectedListBox";
            this.DetectedListBox.Size = new System.Drawing.Size(494, 76);
            this.DetectedListBox.TabIndex = 6;
            // 
            // DetectedLabel
            // 
            this.DetectedLabel.AutoSize = true;
            this.DetectedLabel.Location = new System.Drawing.Point(14, 59);
            this.DetectedLabel.Name = "DetectedLabel";
            this.DetectedLabel.Size = new System.Drawing.Size(70, 20);
            this.DetectedLabel.TabIndex = 7;
            this.DetectedLabel.Text = "Detected";
            // 
            // ConnectedLabel
            // 
            this.ConnectedLabel.AutoSize = true;
            this.ConnectedLabel.Location = new System.Drawing.Point(265, 13);
            this.ConnectedLabel.Name = "ConnectedLabel";
            this.ConnectedLabel.Size = new System.Drawing.Size(80, 20);
            this.ConnectedLabel.TabIndex = 8;
            this.ConnectedLabel.Text = "Connected";
            // 
            // PingTimer
            // 
            this.PingTimer.Enabled = true;
            this.PingTimer.Interval = 1000;
            this.PingTimer.Tick += new System.EventHandler(this.PingTimer_Tick);
            // 
            // PresentTextBox
            // 
            this.PresentTextBox.ForeColor = System.Drawing.Color.White;
            this.PresentTextBox.Location = new System.Drawing.Point(76, 10);
            this.PresentTextBox.Name = "PresentTextBox";
            this.PresentTextBox.ReadOnly = true;
            this.PresentTextBox.Size = new System.Drawing.Size(46, 27);
            this.PresentTextBox.TabIndex = 10;
            this.PresentTextBox.Text = "-";
            // 
            // AccessStatusTextBox
            // 
            this.AccessStatusTextBox.ForeColor = System.Drawing.Color.White;
            this.AccessStatusTextBox.Location = new System.Drawing.Point(183, 10);
            this.AccessStatusTextBox.Name = "AccessStatusTextBox";
            this.AccessStatusTextBox.ReadOnly = true;
            this.AccessStatusTextBox.Size = new System.Drawing.Size(76, 27);
            this.AccessStatusTextBox.TabIndex = 11;
            this.AccessStatusTextBox.Text = "-";
            // 
            // ConnectedTextBox
            // 
            this.ConnectedTextBox.BackColor = System.Drawing.Color.Black;
            this.ConnectedTextBox.ForeColor = System.Drawing.Color.White;
            this.ConnectedTextBox.Location = new System.Drawing.Point(351, 10);
            this.ConnectedTextBox.Name = "ConnectedTextBox";
            this.ConnectedTextBox.ReadOnly = true;
            this.ConnectedTextBox.Size = new System.Drawing.Size(37, 27);
            this.ConnectedTextBox.TabIndex = 12;
            this.ConnectedTextBox.Text = "-";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(442, 47);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(59, 29);
            this.ApplyButton.TabIndex = 15;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // LocalOnlyCheckBox
            // 
            this.LocalOnlyCheckBox.AutoSize = true;
            this.LocalOnlyCheckBox.Checked = true;
            this.LocalOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LocalOnlyCheckBox.Location = new System.Drawing.Point(323, 49);
            this.LocalOnlyCheckBox.Name = "LocalOnlyCheckBox";
            this.LocalOnlyCheckBox.Size = new System.Drawing.Size(100, 24);
            this.LocalOnlyCheckBox.TabIndex = 16;
            this.LocalOnlyCheckBox.Text = "Local Only";
            this.LocalOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // SendLabel
            // 
            this.SendLabel.AutoSize = true;
            this.SendLabel.Location = new System.Drawing.Point(394, 13);
            this.SendLabel.Name = "SendLabel";
            this.SendLabel.Size = new System.Drawing.Size(42, 20);
            this.SendLabel.TabIndex = 18;
            this.SendLabel.Text = "Send";
            // 
            // SendTextBox
            // 
            this.SendTextBox.Enabled = false;
            this.SendTextBox.Location = new System.Drawing.Point(442, 10);
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.ReadOnly = true;
            this.SendTextBox.Size = new System.Drawing.Size(59, 27);
            this.SendTextBox.TabIndex = 19;
            this.SendTextBox.Text = "-";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(128, 50);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(36, 20);
            this.PortLabel.TabIndex = 20;
            this.PortLabel.Text = "Port";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(177, 48);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(58, 27);
            this.PortTextBox.TabIndex = 21;
            this.PortTextBox.Text = "8000";
            // 
            // ViewerCheckBox
            // 
            this.ViewerCheckBox.AutoSize = true;
            this.ViewerCheckBox.Checked = true;
            this.ViewerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewerCheckBox.Location = new System.Drawing.Point(241, 49);
            this.ViewerCheckBox.Name = "ViewerCheckBox";
            this.ViewerCheckBox.Size = new System.Drawing.Size(76, 24);
            this.ViewerCheckBox.TabIndex = 22;
            this.ViewerCheckBox.Text = "Viewer";
            this.ViewerCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 168);
            this.Controls.Add(this.ViewerCheckBox);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.SendLabel);
            this.Controls.Add(this.LocalOnlyCheckBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ConnectedTextBox);
            this.Controls.Add(this.AccessStatusTextBox);
            this.Controls.Add(this.PresentTextBox);
            this.Controls.Add(this.ConnectedLabel);
            this.Controls.Add(this.DetectedLabel);
            this.Controls.Add(this.DetectedListBox);
            this.Controls.Add(this.AccessStatusLabel);
            this.Controls.Add(this.PresentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Notification Listener Thrower";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PresentLabel;
        private System.Windows.Forms.Label AccessStatusLabel;
        private System.Windows.Forms.Timer WatchTimer;
        private System.Windows.Forms.ListBox DetectedListBox;
        private System.Windows.Forms.Label DetectedLabel;
        private System.Windows.Forms.Label ConnectedLabel;
        private System.Windows.Forms.Timer PingTimer;
        private System.Windows.Forms.TextBox PresentTextBox;
        private System.Windows.Forms.TextBox AccessStatusTextBox;
        private System.Windows.Forms.TextBox ConnectedTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.CheckBox LocalOnlyCheckBox;
        private System.Windows.Forms.Label SendLabel;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.CheckBox ViewerCheckBox;
    }
}

