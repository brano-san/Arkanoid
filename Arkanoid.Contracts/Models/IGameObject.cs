using System.Drawing;

namespace Arcanoid.Contracts.Models
{
    /// <summary>
    /// Объект игры
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        /// Коллизия объекта игры <see cref="IGameObject"/>
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Передвинуть объект игры по смещению
        /// </summary>
        void Move(int deltaX, int deltaY);
    }
}
