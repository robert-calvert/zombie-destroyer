using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDestroyer
{
    class AnimatedImageSet
    {
        /*
         * Represents an set of images used in animating a game object. 
         */

        private Bitmap[] images;
        private Bitmap defaultImage;
        private Direction direction;
        private int index;

        public AnimatedImageSet(string[] names, Bitmap defaultImage, int repeat)
        {
            Bitmap[] images = new Bitmap[names.Count() * repeat];

            int index = 0;
            for (int i = 0; i < names.Count(); i++)
            {
                for (int x = 0; x < repeat; x++)
                {
                    images[index] = GetByName(names[i]);
                    index++;
                }
            }
            this.images = images;
            this.defaultImage = defaultImage;
            this.direction = Direction.RIGHT;
            this.index = 0;
        }

        /*
         * Returns the default bitmap used when the animation is not active.
         */

        public Bitmap Default()
        {
            return defaultImage;
        }

        /*
         * Return the next image in the animation. 
         */

        public Bitmap Next()
        {
            index = (index == (images.Count() - 1) ? 0 : index + 1);
            return images[index];
        }

        /*
         *  Return the current direction of this image set. 
         */

        public Direction GetDirection()
        {
            return direction;
        }

        /*
         *  Defines the direction of this image set that bitmaps can be rotated appropriately.
         */

        public void SetDirection(Direction dir)
        {
            this.direction = dir;
            defaultImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            for (int i = 0; i < images.Count(); i++)
            {
                images[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }

        /*
         * Returns a bitmap from the given name of a resource, or null if the resource is missing or not an image.
         */

        private Bitmap GetByName(string name)
        {
            object resource = Properties.Resources.ResourceManager.GetObject(name);
            return ((resource != null && resource is Bitmap) ? (Bitmap) resource : null);
        }
    }
}
