namespace Tuner
{
    partial class Tuner
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
            butStop_Click(null, null);
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butStop = new DevExpress.XtraEditors.SimpleButton();
            this.butStart = new DevExpress.XtraEditors.SimpleButton();
            this.devicesListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.lblFreq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butStop);
            this.panelControl1.Controls.Add(this.lblFreq);
            this.panelControl1.Controls.Add(this.butStart);
            this.panelControl1.Controls.Add(this.devicesListBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 278);
            this.panelControl1.TabIndex = 0;
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(501, 54);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(75, 23);
            this.butStop.TabIndex = 3;
            this.butStop.Text = "Stop";
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(420, 54);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 2;
            this.butStart.Text = "Start";
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // devicesListBox
            // 
            this.devicesListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.devicesListBox.Location = new System.Drawing.Point(34, 57);
            this.devicesListBox.Name = "devicesListBox";
            this.devicesListBox.Size = new System.Drawing.Size(256, 114);
            this.devicesListBox.TabIndex = 0;
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Font = new System.Drawing.Font("Lucida Calligraphy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFreq.Location = new System.Drawing.Point(440, 117);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(101, 36);
            this.lblFreq.TabIndex = 1;
            this.lblFreq.Text = "label1";
            // 
            // Tuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 278);
            this.Controls.Add(this.panelControl1);
            this.Name = "Tuner";
            this.Text = "Tuner";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesListBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ListBoxControl devicesListBox;
        private DevExpress.XtraEditors.SimpleButton butStart;
        private DevExpress.XtraEditors.SimpleButton butStop;
        private System.Windows.Forms.Label lblFreq;
    }
}

