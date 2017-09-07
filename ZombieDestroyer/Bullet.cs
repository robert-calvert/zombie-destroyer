using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDestroyer
{
    class Bullet
    {
        private Rectangle rectangle;
        private Direction direction;

        public Bullet(Point point, Direction direction)
        {
            this.rectangle = new Rectangle(point.X, point.Y, 3, 3);
            this.direction = direction;
        }

        /*
         * Draw this bullet on the game panel's graphics. 
         */

        public void Draw(Graphics g)
        {
            if (g != null)
            {
                g.FillRectangle(new SolidBrush(Color.Yellow), rectangle);
            }
        }

        /*
         * Moves the bullet in the appropriate direction. 
         */

        public void Move(int diff)
        {
            rectangle.Location = new Point(rectangle.Location.X + (direction.Equals(Direction.RIGHT) ? diff : (diff * -1)), rectangle.Location.Y);
        }

        /*
         * Check if this bullet has made contact with the passed rectangle. 
         */

        public bool IntersectsWith(Rectangle rec)
        {
            return rec.IntersectsWith(rectangle);
        }

        /*
         * Returns the location of this bullet. 
         */

        public Point GetLocation()
        {
            return rectangle.Location;
        }
    }
}
