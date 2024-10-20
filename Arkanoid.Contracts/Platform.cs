using System.Drawing;
using Arcanoid.Contracts.Models;

namespace Arcanoid.Contracts
{
    /// <summary>
    /// Объект игры платформа <see cref="IGameObject"/>
    /// </summary>
    public class Platform : IGameObject
    {
        /// <inheritdoc cref="IGameObject.Bounds"/>
        public Rectangle Bounds { get; private set; }

        private readonly int speed;

        public Platform(int x, int y, int width, int height, int speed)
        {
            Bounds = new Rectangle(x, y, width, height);
            this.speed = speed;
        }

        /// <inheritdoc cref="IGameObject.Move"/>
        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }

        /// <summary>
        /// Передвинуть платформу влево <see cref="Bounds"/>
        /// </summary>
        public void MoveLeft()
        {
            Move(-speed, 0);
        }

        /// <summary>
        /// Передвинуть платформу вправо <see cref="Bounds"/>
        /// </summary>
        public void MoveRight()
        {
            Move(speed, 0);
        }
    }

}
