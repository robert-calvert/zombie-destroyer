using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ZombieDestroyer
{
    class Level
    {
        private List<Platform> platforms;
        private List<Point> zombieSpawns;
        private Random random;
        private int PLATFORM_HEIGHT = 20;

        public Level(Panel panel)
        {
            platforms = new List<Platform>();
            zombieSpawns = new List<Point>();
            random = new Random();

            // Calculate the number of platforms based upon the height of the panel and the height of the platforms.
            int n = (int) Math.Floor((double) ((panel.Height / 5) / PLATFORM_HEIGHT));
            // Calculate the required space between all of the platforms.
            int buffer = (int) Math.Floor((double) ((panel.Height - 20) / n));
            // The current distance from the top of the panel used to determine where new platforms will spawn.
            int diff = 0;
            for (int i = 0; i < n; i++)
            {
                int gapStart = random.Next(((int) (panel.Width / 10)), (panel.Width - 50));
                platforms.Add(new Platform(0, (diff + 70), (gapStart - 50), PLATFORM_HEIGHT));
                platforms.Add(new Platform((gapStart + 100), (diff + 70), (panel.Width - (gapStart + 100)), PLATFORM_HEIGHT));
                diff += buffer;
            }
        }

        /*
         * Returns the platforms which make up this level. 
         */

        public List<Platform> GetPlatforms()
        {
            return platforms;
        }

        /*
         * Returns true if the provided player is on any of the platforms in this level. 
         */

        public bool IsOnPlatform(Player player)
        {
            foreach (Platform platform in platforms)
            {
                if (player.GetBottomRight().Y == platform.GetTopLeft().Y)
                {
                    if (player.GetBottomRight().X > platform.GetTopLeft().X && player.GetTopLeft().X < platform.GetBottomRight().X)
                        return true;
                }
            }

            return false;
        }

        /*
         *  Generate the elements of this level on the panel with the provided graphics. 
         */

        public void Spawn(Graphics g)
        {
            platforms.ForEach(p => p.Draw(g));
        }

        /*
         *  Return the starting position of the player based upon the generated platforms. 
         */

        public Point GetPlayerSpawn()
        {
            if (platforms.Count != 0)
            {
                Point topLeft = platforms[0].GetTopLeft();
                return new Point(topLeft.X, topLeft.Y - 65);
            }
            else
            {
                throw new Exception("There are no platforms generated for this level!");
            }
        }
    }
}
