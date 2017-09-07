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
        private List<Bullet> bullets = new List<Bullet>();
        private Level level;

        private string name;
        private int currentLevel = 0;
        private int bulletsFired = 0;
        private int timeElapsed = 0;
        private int zombiesKilled = 0;

        private List<HighScore> highScores = new List<HighScore>();

        public ZombieDestroyer(string name)
        {
            InitializeComponent();

            // Assign the name of the person playing.
            this.name = name;

            // Load all existing high scores.
            highScores = LoadHighScores();

            // Load a level, spawn/teleport the player, and generate zombies.
            LoadLevel();

            // Enables double buffering on the panel which prevents it flickering.
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }

        /*
         * Load/regenerate the current level. 
         */

        private void LoadLevel()
        {
            // generate a new level.
            level = new Level(panel);
            Point spawnPoint = level.GetPlayerSpawn();

            // if we already have a player, just teleport them up to the new starting platform.
            // if not, create a new player instance and spawn them at the starting position.
            if (player != null)
            {
                player.SetLocation(spawnPoint);
            }
            else
            {
                AnimatedImageSet playerAnimation = new AnimatedImageSet(new string[] { "player", "player1", "player2" }, Properties.Resources.player1, 8);
                player = new Player(playerAnimation, spawnPoint.X, spawnPoint.Y);
            }

            zombies.Clear();

            // for each platform, spawn a zombie.
            for (int i = 1; i < level.GetPlatforms().Count; i++)
            {
                Platform platform = level.GetPlatforms()[i];
                // If the platform is really small, don't bother spawning a zombie.
                if (platform.GetBottomRight().X - platform.GetTopLeft().X < 250)
                    continue;

                AnimatedImageSet zombieAnimation = new AnimatedImageSet(new string[] { "zombie", "zombie2", "zombie" }, Properties.Resources.zombie, 6);
                zombies.Add(new Zombie(platform, zombieAnimation, platform.GetTopLeft().X, platform.GetTopLeft().Y - 65));
            }

            // update zombie count label
            zombiesLabel.Text = (zombies.Count < 10 ? "0" : "") + zombies.Count.ToString();

            // update level label
            currentLevel++;
            levelLabel.Text = "LEVEL " + currentLevel;
        }

        public static List<HighScore> LoadHighScores()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var reader = new StreamReader(File.OpenRead(Path.Combine(path, "scores.txt")));
            List<HighScore> scores = new List<HighScore>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                scores.Add(new HighScore(line));
            }

            return scores;
        }

        public void SaveHighScores(List<HighScore> scores)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // clear the existing contents of the file.
            File.WriteAllText(Path.Combine(path, "scores.txt"), string.Empty);
            // create a new string array of all high scores serialized.
            string[] lines = new string[scores.Count];
            for (int i = 0; i < scores.Count; i++)
            {
                lines[i] = scores[i].Serialize();
            }
            // write these lines to the file.
            File.WriteAllLines(Path.Combine(path, "scores.txt"), lines);
        }

        /*
         *  The paint event for the game panel. 
         */

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            level.Spawn(graphics);
            player.Draw(graphics);

            // display each zombie's health above their head.
            zombies.ForEach(zombie =>
            {
                Point point = zombie.GetTopLeft();
                point.Offset(-15, -10);
                graphics.DrawString(zombie.GetHealthString(), panel.Font, new SolidBrush(zombie.GetHealthColour()), point);
                zombie.Draw(graphics);
            });

            bullets.ForEach(bullet => bullet.Draw(graphics));
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
                    player.Move(level, 4);
                    break;
                case Keys.A:
                    player.Move(level, -4);
                    break;
                case Keys.Space:
                    if (player.GetAmmo() > 0)
                    {
                        // change the x coord based upon the direction the player is facing.
                        int x = player.GetDirection().Equals(Direction.RIGHT) ? (player.GetBottomRight().X) : (player.GetTopLeft().X);
                        Point point = new Point(x, player.GetBottomRight().Y - 28);

                        // "fire" the bullet from the player's gun.
                        bullets.Add(new Bullet(point, player.GetDirection()));

                        bulletsFired++;

                        // update player's ammo and label.
                        player.SetAmmo(player.GetAmmo() - 1);
                        ammoLabel.Text = (player.GetAmmo() < 10 ? "0" : "") + player.GetAmmo().ToString();

                        // if they run out of ammo, reload their "magazine" after 2 seconds.
                        if (player.GetAmmo() <= 0)
                        {
                            reloadLabel.Visible = true;

                            // wait two seconds...
                            Task.Delay(2000).ContinueWith(t => {
                                player.SetAmmo(50);

                                // the task creates a new thread, so we must use a method invoker to execute the label text changes on the UI thread.
                                MethodInvoker inv = delegate
                                {
                                    ammoLabel.Text = player.GetAmmo().ToString();
                                    reloadLabel.Visible = false;
                                };

                                Invoke(inv);
                            });
                        }
                    }

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

                    HighScore score = new HighScore(name, zombiesKilled, timeElapsed, (currentLevel - 1), bulletsFired, ((double) zombiesKilled / (double) timeElapsed));
                    highScores.Add(score);
                    SaveHighScores(highScores);

                    DeathScreen screen = new DeathScreen(score);
                    screen.ShowDialog();
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

                int newY = player.GetTopLeft().Y + 2;
                if (newY > (panel.Height - 50))
                {
                    LoadLevel();
                }
                else
                {
                    player.SetLocation(new Point(player.GetTopLeft().X, newY));
                }
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
            zombies.ForEach(zombie => zombie.Move(level, 2 * currentLevel));
        }

        /*
         * Move any existing bullets, and check for zombie interactions. 
         */

        private void bulletsTimer_Tick(object sender, EventArgs e)
        {
            // I'm using a for i loop to avoid concurrent modification exceptions.
            for (int b = bullets.Count - 1; b >= 0; b--)
            {
                Bullet bullet = bullets[b];
                bullet.Move(25);

                // if the bullet reaches the end of the panel, remove it.
                if (bullet.GetLocation().X > panel.Width || bullet.GetLocation().X < 0)
                    bullets.Remove(bullet);

                for (int i = zombies.Count - 1; i >= 0; i--)
                {
                    Zombie zombie = zombies[i];

                    // if the bullet hits a zombie, kill the zombie and remove the bullet.
                    if (bullet.IntersectsWith(zombie.GetRectangle()))
                    {
                        int health = zombie.GetHealth();
                        if ((health - 1) > 0)
                        {
                            zombie.SetHealth(health - 1);
                        }
                        else
                        {
                            zombies.Remove(zombie);
                            zombiesLabel.Text = (zombies.Count < 10 ? "0" : "") + zombies.Count.ToString();
                            zombiesKilled++;
                        }

                        bullets.Remove(bullet);
                    }
                }
            }
        }

        private void timingTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
        }
    }
}
