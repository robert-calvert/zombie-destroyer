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

        public Zombie(Platform platform, AnimatedImageSet animation, int x, int y) : base(animation, x, y)
        {
            this.platform = platform;
        }

        public override void Move(Level level, int distance)
        {
            if (platform.GetBottomRight().X <= GetBottomRight().X)
            {
                if (!(animation.GetDirection().Equals(Direction.LEFT))) animation.SetDirection(Direction.LEFT);
            }

            if (platform.GetTopLeft().X >= GetTopLeft().X)
            {
                if (!(animation.GetDirection().Equals(Direction.RIGHT))) animation.SetDirection(Direction.RIGHT);
            }

            SetMoving(true);
            rectangle.Location = new Point(rectangle.Location.X + (animation.GetDirection().Equals(Direction.RIGHT) ? distance : (distance * -1)), rectangle.Location.Y);
        }
    }
}
