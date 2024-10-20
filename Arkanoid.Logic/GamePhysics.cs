using System.Linq;
using Arcanoid.Contracts;
using Arcanoid.Contracts.Models;
using System.Collections.Generic;

namespace Arkanoid
{
    /// <summary>
    /// Физика управления игрой. <see cref="Ball"/>. <see cref="Platform"/>. <see cref="Block"/>.
    /// </summary>
    public class GamePhysics
    {
        private readonly Ball ball;
        private readonly Platform platform;
        private readonly List<IGameObject> blocks;

        public GamePhysics(Ball ball, Platform platform, List<IGameObject> blocks)
        {
            this.ball = ball;
            this.platform = platform;
            this.blocks = blocks;
        }

        /// <summary>
        /// Обновление <see cref="IGameObject.Bounds"/> для объектов игры <see cref="IGameObject"/>
        /// </summary>
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
