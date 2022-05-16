namespace dogs
{
    partial class RaceGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceGame));
            this.TimerLet = new System.Windows.Forms.Timer(this.components);
            this.TimerTeam = new System.Windows.Forms.Timer(this.components);
            this.CollideButton = new System.Windows.Forms.Button();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.ResultBox = new System.Windows.Forms.PictureBox();
            this.TryAgain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerLet
            // 
            this.TimerLet.Tick += new System.EventHandler(this.updateLet);
            // 
            // CollideButton
            // 
            this.CollideButton.BackColor = System.Drawing.Color.SandyBrown;
            this.CollideButton.Location = new System.Drawing.Point(292, 194);
            this.CollideButton.Name = "CollideButton";
            this.CollideButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CollideButton.Size = new System.Drawing.Size(197, 55);
            this.CollideButton.TabIndex = 0;
            this.CollideButton.Text = "Препятствие! Нажмите, чтобы продолжить!";
            this.CollideButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CollideButton.UseVisualStyleBackColor = false;
            this.CollideButton.Visible = false;
            this.CollideButton.Click += new System.EventHandler(this.CollideButton_Click);
            // 
            // TimeBox
            // 
            this.TimeBox.Enabled = false;
            this.TimeBox.Location = new System.Drawing.Point(632, 12);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.ReadOnly = true;
            this.TimeBox.Size = new System.Drawing.Size(156, 27);
            this.TimeBox.TabIndex = 1;
            this.TimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResultBox
            // 
            this.ResultBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResultBox.BackgroundImage")));
            this.ResultBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResultBox.InitialImage = null;
            this.ResultBox.Location = new System.Drawing.Point(216, 98);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(379, 269);
            this.ResultBox.TabIndex = 2;
            this.ResultBox.TabStop = false;
            this.ResultBox.Visible = false;
            // 
            // TryAgain
            // 
            this.TryAgain.Location = new System.Drawing.Point(467, 373);
            this.TryAgain.Name = "TryAgain";
            this.TryAgain.Size = new System.Drawing.Size(94, 29);
            this.TryAgain.TabIndex = 3;
            this.TryAgain.Text = "Заново";
            this.TryAgain.UseVisualStyleBackColor = true;
            this.TryAgain.Visible = false;
            this.TryAgain.Click += new System.EventHandler(this.TryAgain_Click);
            // 
            // RaceGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TryAgain);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.CollideButton);
            this.DoubleBuffered = true;
            this.Name = "RaceGame";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnePaint);
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerLet;
        private System.Windows.Forms.Timer TimerTeam;
        private Button CollideButton;
        private TextBox TimeBox;
        private PictureBox ResultBox;
        private Button TryAgain;
    }
}