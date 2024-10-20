using Arcanoid.Contracts;
using System.Drawing;

namespace Arcanoid.Src.Objects
{
    public class Block : IGameObject
    {
        public Rectangle Bounds { get; private set; }

        public Block(int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
        }

        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }
    }
}
