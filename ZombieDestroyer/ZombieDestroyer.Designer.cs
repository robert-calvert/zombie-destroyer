namespace ZombieDestroyer
{
    partial class ZombieDestroyer
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
            this.debug = new System.Windows.Forms.Label();
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.fallingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.zombieTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(1299, 31);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(37, 13);
            this.debug.TabIndex = 1;
            this.debug.Text = "debug";
            // 
            // playerTimer
            // 
            this.playerTimer.Enabled = true;
            this.playerTimer.Interval = 10;
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick);
            // 
            // fallingTimer
            // 
            this.fallingTimer.Enabled = true;
            this.fallingTimer.Interval = 1;
            this.fallingTimer.Tick += new System.EventHandler(this.fallingTimer_Tick);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.BackgroundImage = global::ZombieDestroyer.Properties.Resources.background;
            this.panel.Location = new System.Drawing.Point(12, 31);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1280, 720);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // zombieTimer
            // 
            this.zombieTimer.Enabled = true;
            this.zombieTimer.Interval = 25;
            this.zombieTimer.Tick += new System.EventHandler(this.zombieTimer_Tick);
            // 
            // ZombieDestroyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 791);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panel);
            this.Name = "ZombieDestroyer";
            this.Text = "Zombie Destroyer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZombieDestroyer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ZombieDestroyer_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.Timer playerTimer;
        private System.Windows.Forms.Timer fallingTimer;
        private System.Windows.Forms.Timer zombieTimer;
    }
}

