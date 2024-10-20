using System.Drawing;

namespace Arcanoid.Contracts
{
    public interface IGameObject
    {
        Rectangle Bounds { get; }
        void Move(int deltaX, int deltaY);
    }
}
