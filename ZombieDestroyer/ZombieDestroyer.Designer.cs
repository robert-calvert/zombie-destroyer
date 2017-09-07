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
            this.bulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ammoLabel = new System.Windows.Forms.Label();
            this.reloadLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zombiesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.timingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(1309, 414);
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
            // bulletsTimer
            // 
            this.bulletsTimer.Enabled = true;
            this.bulletsTimer.Interval = 10;
            this.bulletsTimer.Tick += new System.EventHandler(this.bulletsTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1339, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "AMMO";
            // 
            // ammoLabel
            // 
            this.ammoLabel.AutoSize = true;
            this.ammoLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammoLabel.Location = new System.Drawing.Point(1350, 57);
            this.ammoLabel.Name = "ammoLabel";
            this.ammoLabel.Size = new System.Drawing.Size(49, 34);
            this.ammoLabel.TabIndex = 3;
            this.ammoLabel.Text = "50";
            // 
            // reloadLabel
            // 
            this.reloadLabel.AutoSize = true;
            this.reloadLabel.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reloadLabel.Location = new System.Drawing.Point(1328, 102);
            this.reloadLabel.Name = "reloadLabel";
            this.reloadLabel.Size = new System.Drawing.Size(97, 17);
            this.reloadLabel.TabIndex = 4;
            this.reloadLabel.Text = "RELOADING";
            this.reloadLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1329, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "ZOMBIES";
            // 
            // zombiesLabel
            // 
            this.zombiesLabel.AutoSize = true;
            this.zombiesLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zombiesLabel.Location = new System.Drawing.Point(1350, 198);
            this.zombiesLabel.Name = "zombiesLabel";
            this.zombiesLabel.Size = new System.Drawing.Size(49, 34);
            this.zombiesLabel.TabIndex = 6;
            this.zombiesLabel.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Zombie Destroyer";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.Location = new System.Drawing.Point(1218, 4);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(74, 24);
            this.levelLabel.TabIndex = 8;
            this.levelLabel.Text = "LEVEL 1";
            // 
            // timingTimer
            // 
            this.timingTimer.Enabled = true;
            this.timingTimer.Interval = 1000;
            this.timingTimer.Tick += new System.EventHandler(this.timingTimer_Tick);
            // 
            // ZombieDestroyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 791);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zombiesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reloadLabel);
            this.Controls.Add(this.ammoLabel);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Timer bulletsTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ammoLabel;
        private System.Windows.Forms.Label reloadLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label zombiesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Timer timingTimer;
    }
}

