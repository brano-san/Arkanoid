using Arcanoid.Contracts;
using System.Drawing;

namespace Arcanoid.Src.Objects
{
    public class Platform : IGameObject
    {
        public Rectangle Bounds { get; private set; }
        public int Speed { get; set; }

        public Platform(int x, int y, int width, int height, int speed)
        {
            Bounds = new Rectangle(x, y, width, height);
            Speed = speed;
        }

        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }

        public void MoveLeft()
        {
            Move(-Speed, 0);
        }

        public void MoveRight()
        {
            Move(Speed, 0);
        }
    }

}
