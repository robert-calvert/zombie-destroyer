using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 
using System.Windows.Forms;

namespace ZombieDestroyer
{
    abstract class Entity
    {
        /*
         * Represents a game entity which is animated and can move.
         */

        protected Rectangle rectangle;
        protected AnimatedImageSet animation;
        protected Point origin;
        protected bool moving;

        public Entity(AnimatedImageSet animation, int x, int y)
        {
            this.rectangle = new Rectangle(x, y, 50, 65);
            this.animation = animation;
            this.origin = new Point(x, y);
            this.moving = false;
        }

        /*
         * Returns the location of this entity as a Point.
         * This point is the top left corner of the rectangle.
         */

        public Point GetTopLeft()
        {
            return rectangle.Location;
        }

        /*
         * Returns the location of this entity as a Point.
         * This point is the bottom right corner of the rectangle. 
         */

        public Point GetBottomRight()
        {
            return new Point(rectangle.Location.X + rectangle.Width, rectangle.Location.Y + rectangle.Height);
        }

        /*
         * Draw this entity on the provided graphics object (the game panel). 
         */

        public void Draw(Graphics g)
        {
            if (g != null)
            {
                g.DrawImage((IsMoving() ? animation.Next() : animation.Default()), rectangle);
            }
        }

        /*
         * A move method which must be overridden in extending classes, as entities do not share movement behaviour. 
         */

        public abstract void Move(Level level, int distance);

        /*
         * Returns true if this entity is currently moving. 
         */

        public bool IsMoving()
        {
            return moving;
        }

        /*
         *  Updates the boolean which determines if the player is moving or not.
         */

        public void SetMoving(bool move)
        {
            this.moving = move;
        }

        /*
         * Returns the rectangle which makes up this entity. 
         */

        public Rectangle GetRectangle()
        {
            return rectangle;
        }

        /*
         * Returns true if this entity is intersecting another entity. 
         */

        public bool IntersectsWith(Entity entity)
        {
            return rectangle.IntersectsWith(entity.GetRectangle());
        }
    }
}
