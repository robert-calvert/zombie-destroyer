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
        private int ammo;

        public Player(AnimatedImageSet animation, int x, int y) : base(animation, x, y)
        {
            this.falling = false;
            this.ammo = 50;
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
         * Update the location of the player. 
         */

        public void SetLocation(Point point)
        {
            rectangle.Location = point;
        }

        /*
         * Returns true if the player is falling. 
         */

        public bool IsFalling()
        {
            return falling;
        }

        /*
         * Update the falling status of the player. 
         */

        public void SetFalling(bool falling)
        {
            this.falling = falling;
        }

        /*
         * Return the direction the player is currently moving. 
         */

        public Direction GetDirection()
        {
            return animation.GetDirection();
        }

        /*
         * Returns the number of bullets the player has remaining in their weapon. 
         */

        public int GetAmmo()
        {
            return ammo;
        }

        /*
         * Updates the bullet count for this players weapon. 
         */

        public void SetAmmo(int ammo)
        {
            this.ammo = ammo;
        }
    }
}
