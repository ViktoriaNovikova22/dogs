namespace dogs
{
    partial class HomeGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeGame));
            this.MakeTeam = new System.Windows.Forms.Button();
            this.GoToRace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MakeTeam
            // 
            this.MakeTeam.Location = new System.Drawing.Point(57, 331);
            this.MakeTeam.Name = "MakeTeam";
            this.MakeTeam.Size = new System.Drawing.Size(94, 29);
            this.MakeTeam.TabIndex = 0;
            this.MakeTeam.Text = "Упряжка";
            this.MakeTeam.UseVisualStyleBackColor = true;
            this.MakeTeam.Click += new System.EventHandler(this.MakeTeam_Click);
            // 
            // GoToRace
            // 
            this.GoToRace.Location = new System.Drawing.Point(57, 376);
            this.GoToRace.Name = "GoToRace";
            this.GoToRace.Size = new System.Drawing.Size(94, 29);
            this.GoToRace.TabIndex = 1;
            this.GoToRace.Text = "Гонка";
            this.GoToRace.UseVisualStyleBackColor = true;
            this.GoToRace.Click += new System.EventHandler(this.GoToRace_Click);
            // 
            // HomeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoToRace);
            this.Controls.Add(this.MakeTeam);
            this.Name = "HomeGame";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Esc);
            this.ResumeLayout(false);

        }

        #endregion

        private Button MakeTeam;
        private Button GoToRace;
    }
}