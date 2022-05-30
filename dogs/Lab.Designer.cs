namespace dogs
{
    partial class Lab
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
            this.LabPanel = new System.Windows.Forms.Panel();
            this.TextButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabPanel
            // 
            this.LabPanel.Location = new System.Drawing.Point(58, 12);
            this.LabPanel.Name = "LabPanel";
            this.LabPanel.Size = new System.Drawing.Size(680, 360);
            this.LabPanel.TabIndex = 0;
            this.LabPanel.Click += new System.EventHandler(this.Click);
            this.LabPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LabPaint);
            // 
            // TextButt
            // 
            this.TextButt.BackColor = System.Drawing.Color.White;
            this.TextButt.Enabled = false;
            this.TextButt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextButt.Location = new System.Drawing.Point(176, 387);
            this.TextButt.Name = "TextButt";
            this.TextButt.Size = new System.Drawing.Size(476, 51);
            this.TextButt.TabIndex = 0;
            this.TextButt.Text = "Нужно догнать Юнца, пока он не убежал";
            this.TextButt.UseVisualStyleBackColor = false;
            this.TextButt.Click += new System.EventHandler(this.TextButt_Click);
            // 
            // Lab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextButt);
            this.Controls.Add(this.LabPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Lab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainLoad);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LabPanel;
        private Button TextButt;
    }
}