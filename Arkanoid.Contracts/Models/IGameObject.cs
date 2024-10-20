using System.Drawing;

namespace Arcanoid.Contracts.Models
{
    public interface IGameObject
    {
        Rectangle Bounds { get; }
        void Move(int deltaX, int deltaY);
    }
}
