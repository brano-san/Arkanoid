using System.Drawing;
using Arcanoid.Contracts;

namespace Arcanoid.Src.Objects
{
    public class Ball : IGameObject
    {
        public Rectangle Bounds { get; private set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }

        public Ball(int x, int y, int width, int height, int speedX, int speedY)
        {
            Bounds = new Rectangle(x, y, width, height);
            SpeedX = speedX;
            SpeedY = speedY;
        }

        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }

        public void UpdatePosition()
        {
            Move(SpeedX, SpeedY);
        }

        public void ReflectX()
        {
            SpeedX = -SpeedX;
        }

        public void ReflectY()
        {
            SpeedY = -SpeedY;
        }
    }
}
