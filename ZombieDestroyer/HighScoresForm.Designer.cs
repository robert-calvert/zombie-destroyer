namespace ZombieDestroyer
{
    partial class HighScoresForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OVERALL = new System.Windows.Forms.Button();
            this.ZOMBIES_KILLED = new System.Windows.Forms.Button();
            this.TIME_ELAPSED = new System.Windows.Forms.Button();
            this.LEVELS_COMPLETED = new System.Windows.Forms.Button();
            this.BULLETS_FIRED = new System.Windows.Forms.Button();
            this.ZOMBIES_PER_SECOND = new System.Windows.Forms.Button();
            this.scoresView = new System.Windows.Forms.ListView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(57, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "ZOMBIE DESTROYER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "HIGH SCORES";
            // 
            // OVERALL
            // 
            this.OVERALL.BackColor = System.Drawing.Color.Red;
            this.OVERALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OVERALL.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OVERALL.ForeColor = System.Drawing.Color.White;
            this.OVERALL.Location = new System.Drawing.Point(26, 104);
            this.OVERALL.Name = "OVERALL";
            this.OVERALL.Size = new System.Drawing.Size(109, 33);
            this.OVERALL.TabIndex = 7;
            this.OVERALL.Text = "OVERALL";
            this.toolTip.SetToolTip(this.OVERALL, "A statistic calculated using your other statistics. A larger value is better.");
            this.OVERALL.UseVisualStyleBackColor = false;
            this.OVERALL.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // ZOMBIES_KILLED
            // 
            this.ZOMBIES_KILLED.BackColor = System.Drawing.Color.Red;
            this.ZOMBIES_KILLED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZOMBIES_KILLED.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZOMBIES_KILLED.ForeColor = System.Drawing.Color.White;
            this.ZOMBIES_KILLED.Location = new System.Drawing.Point(141, 104);
            this.ZOMBIES_KILLED.Name = "ZOMBIES_KILLED";
            this.ZOMBIES_KILLED.Size = new System.Drawing.Size(185, 33);
            this.ZOMBIES_KILLED.TabIndex = 8;
            this.ZOMBIES_KILLED.Text = "ZOMBIES KILLED";
            this.toolTip.SetToolTip(this.ZOMBIES_KILLED, "The number of zombies you have killed.");
            this.ZOMBIES_KILLED.UseVisualStyleBackColor = false;
            this.ZOMBIES_KILLED.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // TIME_ELAPSED
            // 
            this.TIME_ELAPSED.BackColor = System.Drawing.Color.Red;
            this.TIME_ELAPSED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TIME_ELAPSED.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIME_ELAPSED.ForeColor = System.Drawing.Color.White;
            this.TIME_ELAPSED.Location = new System.Drawing.Point(332, 104);
            this.TIME_ELAPSED.Name = "TIME_ELAPSED";
            this.TIME_ELAPSED.Size = new System.Drawing.Size(150, 33);
            this.TIME_ELAPSED.TabIndex = 9;
            this.TIME_ELAPSED.Text = "TIME ELAPSED";
            this.toolTip.SetToolTip(this.TIME_ELAPSED, "The time, in seconds, that you survived the zombie horde.");
            this.TIME_ELAPSED.UseVisualStyleBackColor = false;
            this.TIME_ELAPSED.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // LEVELS_COMPLETED
            // 
            this.LEVELS_COMPLETED.BackColor = System.Drawing.Color.Red;
            this.LEVELS_COMPLETED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LEVELS_COMPLETED.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEVELS_COMPLETED.ForeColor = System.Drawing.Color.White;
            this.LEVELS_COMPLETED.Location = new System.Drawing.Point(26, 143);
            this.LEVELS_COMPLETED.Name = "LEVELS_COMPLETED";
            this.LEVELS_COMPLETED.Size = new System.Drawing.Size(190, 33);
            this.LEVELS_COMPLETED.TabIndex = 10;
            this.LEVELS_COMPLETED.Text = "LEVELS COMPLETED";
            this.toolTip.SetToolTip(this.LEVELS_COMPLETED, "The number of levels you successfully completed.");
            this.LEVELS_COMPLETED.UseVisualStyleBackColor = false;
            this.LEVELS_COMPLETED.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // BULLETS_FIRED
            // 
            this.BULLETS_FIRED.BackColor = System.Drawing.Color.Red;
            this.BULLETS_FIRED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BULLETS_FIRED.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BULLETS_FIRED.ForeColor = System.Drawing.Color.White;
            this.BULLETS_FIRED.Location = new System.Drawing.Point(222, 143);
            this.BULLETS_FIRED.Name = "BULLETS_FIRED";
            this.BULLETS_FIRED.Size = new System.Drawing.Size(150, 33);
            this.BULLETS_FIRED.TabIndex = 11;
            this.BULLETS_FIRED.Text = "BULLETS FIRED";
            this.toolTip.SetToolTip(this.BULLETS_FIRED, "The number of bullets you fired.");
            this.BULLETS_FIRED.UseVisualStyleBackColor = false;
            this.BULLETS_FIRED.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // ZOMBIES_PER_SECOND
            // 
            this.ZOMBIES_PER_SECOND.BackColor = System.Drawing.Color.Red;
            this.ZOMBIES_PER_SECOND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZOMBIES_PER_SECOND.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZOMBIES_PER_SECOND.ForeColor = System.Drawing.Color.White;
            this.ZOMBIES_PER_SECOND.Location = new System.Drawing.Point(378, 143);
            this.ZOMBIES_PER_SECOND.Name = "ZOMBIES_PER_SECOND";
            this.ZOMBIES_PER_SECOND.Size = new System.Drawing.Size(104, 33);
            this.ZOMBIES_PER_SECOND.TabIndex = 12;
            this.ZOMBIES_PER_SECOND.Text = "Z.P.S";
            this.toolTip.SetToolTip(this.ZOMBIES_PER_SECOND, "The number of zombies you killed, divided by the time you survived.");
            this.ZOMBIES_PER_SECOND.UseVisualStyleBackColor = false;
            this.ZOMBIES_PER_SECOND.Click += new System.EventHandler(this.onStatisticsButton_Click);
            // 
            // scoresView
            // 
            this.scoresView.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoresView.Location = new System.Drawing.Point(26, 198);
            this.scoresView.Name = "scoresView";
            this.scoresView.Size = new System.Drawing.Size(456, 327);
            this.scoresView.TabIndex = 14;
            this.scoresView.UseCompatibleStateImageBehavior = false;
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 597);
            this.Controls.Add(this.scoresView);
            this.Controls.Add(this.ZOMBIES_PER_SECOND);
            this.Controls.Add(this.BULLETS_FIRED);
            this.Controls.Add(this.LEVELS_COMPLETED);
            this.Controls.Add(this.TIME_ELAPSED);
            this.Controls.Add(this.ZOMBIES_KILLED);
            this.Controls.Add(this.OVERALL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HighScoresForm";
            this.Text = "High Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OVERALL;
        private System.Windows.Forms.Button ZOMBIES_KILLED;
        private System.Windows.Forms.Button TIME_ELAPSED;
        private System.Windows.Forms.Button LEVELS_COMPLETED;
        private System.Windows.Forms.Button BULLETS_FIRED;
        private System.Windows.Forms.Button ZOMBIES_PER_SECOND;
        private System.Windows.Forms.ListView scoresView;
        private System.Windows.Forms.ToolTip toolTip;
    }
}