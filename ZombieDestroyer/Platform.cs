using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZombieDestroyer
{
    class Platform
    {
        private Point topLeft;
        private int width, height;
        private Rectangle rectangle;

        private Color PLATFORM_COLOUR = Color.FromArgb(49, 59, 76);

        public Platform(int x, int y, int width, int height)
        {
            this.topLeft = new Point(x, y);
            this.width = width;
            this.height = height;
            this.rectangle = new Rectangle(x, y, width, height);
        }

        /*
         * Return the location of the top left corner as a Point. 
         */

        public Point GetTopLeft()
        {
            return topLeft;
        }

        /*
         * Return the location of the bottom right corner as a Point. 
         */

        public Point GetBottomRight()
        {
            return new Point(topLeft.X + width, topLeft.Y + height);
        }

        /*
         *  Given a graphics object, draw the rectangle of this platform. 
         */

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(PLATFORM_COLOUR), rectangle);
        }
    }
}
