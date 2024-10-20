using System.Drawing;
using Arcanoid.Contracts.Models;

namespace Arcanoid.Contracts
{
    /// <summary>
    /// Объект игры блок <see cref="IGameObject"/>
    /// </summary>
    public class Block : IGameObject
    {
        /// <inheritdoc cref="IGameObject.Bounds"/>
        public Rectangle Bounds { get; private set; }

        public Block(int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
        }

        /// <inheritdoc cref="IGameObject.Move"/>
        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }
    }
}
