using Arcanoid.Contracts;
using Arcanoid.Src.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Arkanoid
{
    public class GamePhysics
    {
        private Ball ball;
        private Platform platform;
        private List<IGameObject> blocks;

        public GamePhysics(Ball ball, Platform platform, List<IGameObject> blocks)
        {
            this.ball = ball;
            this.platform = platform;
            this.blocks = blocks;
        }

        public void Update()
        {
            ball.UpdatePosition();

            if (ball.Bounds.Left <= 0 || ball.Bounds.Right >= 400)
            {
                ball.ReflectX();
            }

            if (ball.Bounds.Top <= 0)
            {
                ball.ReflectY();
            }

            if (ball.Bounds.IntersectsWith(platform.Bounds))
            {
                ball.ReflectY();
            }

            foreach (var block in blocks.ToList())
            {
                if (ball.Bounds.IntersectsWith(block.Bounds))
                {
                    blocks.Remove(block);
                    ball.ReflectY();
                    break;
                }
            }
        }
    }

}
