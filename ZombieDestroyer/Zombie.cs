using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDestroyer
{
    class Zombie : Entity
    {
        private Platform platform;
        private int health;

        public Zombie(Platform platform, AnimatedImageSet animation, int x, int y) : base(animation, x, y)
        {
            this.platform = platform;
            Random random = new Random();
            this.health = random.Next(4, 8);
        }

        public override void Move(Level level, int distance)
        {
            // If the zombie reaches the end of the platform, make it turn around.
            if (platform.GetBottomRight().X <= GetBottomRight().X)
            {
                if (!(animation.GetDirection().Equals(Direction.LEFT))) animation.SetDirection(Direction.LEFT);
            }

            // If the zombie reaches the start of the platform, make it turn around.
            if (platform.GetTopLeft().X >= GetTopLeft().X)
            {
                if (!(animation.GetDirection().Equals(Direction.RIGHT))) animation.SetDirection(Direction.RIGHT);
            }

            // the zombie is always moving, I only ever change the direction.
            SetMoving(true);
            rectangle.Location = new Point(rectangle.Location.X + (animation.GetDirection().Equals(Direction.RIGHT) ? distance : (distance * -1)), rectangle.Location.Y);
        }

        /*
         * Return this zombie's health. 
         */

        public int GetHealth()
        {
            return health;
        }

        /*
         * Return the relevant colour for this zombie's health. 
         */

        public Color GetHealthColour()
        {
            return (health > 3 ? Color.Green : Color.Red);
        }

        /*
         * Return this zombie's health as a string.
         */

        public string GetHealthString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < health; i++)
            {
                builder.Append("o").Append(" ");
            }

            return builder.ToString();
        }

        /*
         * Updates this zombie's health to the passed value.
         */

        public void SetHealth(int health)
        {
            this.health = health;
        }
    }
}
