using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieDestroyer
{
    public partial class DeathScreen : Form
    {
        /*
         * Represents the screen shown to the player when they are killed. 
         */

        public DeathScreen(HighScore score)
        {
            InitializeComponent();

            zombiesKilledLabel.Text = score.GetZombiesKilled().ToString("00");
            timeElapsedLabel.Text = score.GetTimeElapsed() + " secs";
            levelsCompletedLabel.Text = score.GetLevelsCompleted().ToString("00");
            bulletsFiredLabel.Text = score.GetBulletsFired().ToString("00");
            zombiesPerSecondLabel.Text = score.GetZombiesPerSecond().ToString("0.00");
        }

        private void DeathScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            HighScoresForm form = new HighScoresForm();
            form.ShowDialog();
        }
    }
}
