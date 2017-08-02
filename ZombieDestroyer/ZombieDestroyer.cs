using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieDestroyer
{
    public partial class ZombieDestroyer : Form
    {
        private Graphics graphics;
        private Player player;
        private List<Zombie> zombies = new List<Zombie>();
        private Level level;

        public ZombieDestroyer()
        {
            InitializeComponent();

            level = new Level(panel);
            Point spawnPoint = level.GetPlayerSpawn();
            
            // Instantiate the player.
            AnimatedImageSet playerAnimation = new AnimatedImageSet(new string[]{ "player", "player1", "player2" }, Properties.Resources.player1, 5);
            player = new Player(playerAnimation, spawnPoint.X, spawnPoint.Y);

            for (int i = 1; i < level.GetPlatforms().Count; i++)
            {
                Platform platform = level.GetPlatforms()[i];
                // If the platform is really small, don't bother spawning a zombie.
                if (platform.GetBottomRight().X - platform.GetTopLeft().X < 100)
                    continue;

                AnimatedImageSet zombieAnimation = new AnimatedImageSet(new string[] { "zombie", "zombie2", "zombie" }, Properties.Resources.zombie, 6);
                zombies.Add(new Zombie(platform, zombieAnimation, platform.GetTopLeft().X, platform.GetTopLeft().Y - 65));
            }

            // Enables double buffering on the panel which prevents it flickering.
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }

        /*
         *  The paint event for the game panel. 
         */

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            level.Spawn(graphics);
            player.Draw(graphics);

            zombies.ForEach(zombie => zombie.Draw(graphics));
        }

        /*
         *  The key-down method for the form.
         *  This is called when any key is pressed, so we filter to listen for the D and A keys.
         */

        private void ZombieDestroyer_KeyDown(object sender, KeyEventArgs e)
        {
            bool fallingBefore = player.IsFalling();
            switch (e.KeyData)
            {
                case Keys.D:
                    player.Move(level, 3);
                    break;
                case Keys.A:
                    player.Move(level, -3);
                    break;
            }

            if (fallingTimer.Enabled && !player.IsFalling())
                fallingTimer.Stop();

            if (!fallingTimer.Enabled && player.IsFalling())
                fallingTimer.Start();
        }

        /*
         *  Update the panel when the player timer ticks. 
         */

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            foreach (Zombie zombie in zombies)
            {
                if (zombie.IntersectsWith(player))
                {
                    playerTimer.Stop();
                    zombieTimer.Stop();
                    fallingTimer.Stop();

                    MessageBox.Show("You were caught by a zombie!", "Game Over!");
                }
            }

            panel.Invalidate();
        }

        /*
         *  When a key is released, stop the player moving. 
         */

        private void ZombieDestroyer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D || e.KeyData == Keys.A)
                player.SetMoving(false);
        }

        /*
         *  If a player is falling, check that there is no platform underneath them.
         *  If they aren't falling, stop them falling. 
         */

        private void fallingTimer_Tick(object sender, EventArgs e)
        {
            if (player.IsFalling())
            {
                if (level.IsOnPlatform(player))
                {
                    player.SetFalling(false);
                    fallingTimer.Stop();
                    return;
                }

                player.SetLocation(new Point(player.GetTopLeft().X, player.GetTopLeft().Y + 2));
            }
            else
            {
                player.SetFalling(false);
                fallingTimer.Stop();
            }
        }

        /*
         * Update the zombies' movements on every timer tick. 
         */

        private void zombieTimer_Tick(object sender, EventArgs e)
        {
            zombies.ForEach(zombie => zombie.Move(level, 3));
        }
    }
}
