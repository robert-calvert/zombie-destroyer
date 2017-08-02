using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDestroyer
{
    class Player : Entity
    {
        private bool falling;

        public Player(AnimatedImageSet animation, int x, int y) : base(animation, x, y)
        {
            
        }

        /*
         *  Handle the movement of the player. 
         */

        public override void Move(Level level, int distance)
        {
            if (!level.IsOnPlatform(this))
            {
                SetFalling(true);
            }
            else
            {
                SetFalling(false);
            }
                
            rectangle.Location = new Point(rectangle.Location.X + distance, rectangle.Location.Y);

            SetMoving(true);

            Direction requiredDir = (distance > 0 ? Direction.RIGHT : Direction.LEFT);
            if (!(animation.GetDirection().Equals(requiredDir))) animation.SetDirection(requiredDir);
        }

        /*
         * 
         */

        public void SetLocation(Point point)
        {
            rectangle.Location = point;
        }

        public bool IsFalling()
        {
            return falling;
        }

        public void SetFalling(bool falling)
        {
            this.falling = falling;
        }
    }
}
