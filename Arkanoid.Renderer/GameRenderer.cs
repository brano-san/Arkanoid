using System.Drawing;
using Arcanoid.Contracts;
using System.Windows.Forms;
using Arcanoid.Contracts.Models;
using System.Collections.Generic;
using Arkanoid.Renderer.Properties;

namespace Arkanoid
{
    public class GameRenderer
    {
        private Control form;
        private Ball ball;
        private Platform platform;
        private List<IGameObject> blocks;

        private PictureBox ballPictureBox;
        private PictureBox platformPictureBox;
        private List<PictureBox> blockPictureBoxes;

        public GameRenderer(Control form, Ball ball, Platform platform, List<IGameObject> blocks)
        {
            this.form = form;
            this.ball = ball;
            this.platform = platform;
            this.blocks = blocks;

            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            ballPictureBox = new PictureBox
            {
                Width = ball.Bounds.Width,
                Height = ball.Bounds.Height,
                Image = Resources.ball,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            form.Controls.Add(ballPictureBox);

            platformPictureBox = new PictureBox
            {
                Width = platform.Bounds.Width,
                Height = platform.Bounds.Height,
                Image = Resources.platform,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            form.Controls.Add(platformPictureBox);

            blockPictureBoxes = new List<PictureBox>();
            foreach (var block in blocks)
            {
                var blockPictureBox = new PictureBox
                {
                    Width = block.Bounds.Width,
                    Height = block.Bounds.Height,
                    Image = Resources.block_1,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                };
                form.Controls.Add(blockPictureBox);
                blockPictureBoxes.Add(blockPictureBox);
            }
        }

        public void Render()
        {
            ballPictureBox.Left = ball.Bounds.Left;
            ballPictureBox.Top = ball.Bounds.Top;

            platformPictureBox.Left = platform.Bounds.Left;
            platformPictureBox.Top = platform.Bounds.Top;

            for (var i = 0; i < blocks.Count; i++)
            {
                blockPictureBoxes[i].Left = blocks[i].Bounds.Left;
                blockPictureBoxes[i].Top = blocks[i].Bounds.Top;
            }
        }
    }
}
