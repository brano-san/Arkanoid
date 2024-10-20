using System.Drawing;
using Arcanoid.Contracts.Models;

namespace Arcanoid.Contracts
{
    /// <summary>
    /// Объект игры мяч <see cref="IGameObject"/>
    /// </summary>
    public class Ball : IGameObject
    {
        /// <inheritdoc cref="IGameObject.Bounds"/>
        public Rectangle Bounds { get; private set; }

        private int speedX;
        private int speedY;

        public Ball(int x, int y, int width, int height, int speedX, int speedY)
        {
            Bounds = new Rectangle(x, y, width, height);
            this.speedX = speedX;
            this.speedY = speedY;
        }

        /// <inheritdoc cref="IGameObject.Move"/>
        public void Move(int deltaX, int deltaY)
        {
            Bounds = new Rectangle(Bounds.X + deltaX, Bounds.Y + deltaY, Bounds.Width, Bounds.Height);
        }

        /// <summary>
        /// Обновить позицию мяча <see cref="Bounds"/>
        /// </summary>
        public void UpdatePosition()
        {
            Move(speedX, speedY);
        }

        /// <summary>
        /// Отразить движение по оси X <see cref="Bounds"/>
        /// </summary>
        public void ReflectX()
        {
            speedX = -speedX;
        }

        /// <summary>
        /// Отразить движение по оси Y <see cref="Bounds"/>
        /// </summary>
        public void ReflectY()
        {
            speedY = -speedY;
        }
    }
}
