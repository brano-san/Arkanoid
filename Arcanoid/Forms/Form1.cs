using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arcanoid.Contracts;
using Arcanoid.Src.Objects;

namespace Arkanoid
{
    public partial class Form1 : Form
    {
        private Ball ball;
        private Platform platform;
        private List<IGameObject> blocks;
        private GamePhysics physics;
        private GameRenderer renderer;
        private Timer gameTimer;

        private readonly int blockRowsCount = 5;
        private readonly int blockColumnsCount = 7;
        private readonly int blockWidth = 50;
        private readonly int blockHeight = 20;

        private readonly int platformWidth = 80;
        private readonly int platformHeight = 20;
        private readonly int platformSpeed = 10;

        private readonly int ballWidth = 20;
        private readonly int ballHeight = 20;
        private readonly int ballSpeed = 3;

        public Form1()
        {
            Width = 440;
            Height = 540;
            BackColor = Color.Black;

            InitializeGame();
        }

        private void InitializeGame()
        {
            platform = new Platform(Width / 2, Height - platformHeight * 4, platformWidth, platformHeight, platformSpeed);
            ball = new Ball(Width / 2, Height / 2, ballWidth, ballHeight, ballSpeed, ballSpeed);

            blocks = new List<IGameObject>();
            for (var row = 0; row < blockRowsCount; row++)
            {
                for (var col = 0; col < blockColumnsCount; col++)
                {
                    blocks.Add(new Block(25 + col * 55, 50 + row * 25, blockWidth, blockHeight));
                }
            }

            physics = new GamePhysics(ball, platform, blocks);
            renderer = new GameRenderer(this, ball, platform, blocks);

            gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            KeyDown += ArkanoidForm_KeyDown;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            physics.Update();
            renderer.Render();

            CheckGameOver();
        }

        private void ArkanoidForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && platform.Bounds.Left > 0)
            {
                platform.MoveLeft();
            }
            else if (e.KeyCode == Keys.Right && platform.Bounds.Right < ClientSize.Width)
            {
                platform.MoveRight();
            }
        }

        private void CheckGameOver()
        {
            if (ball.Bounds.Bottom >= Height)
            {
                EndGame("You lost! Try again?");
            }
            else if (blocks.Count == 0)
            {
                EndGame("Congratulations! You won! Play again?");
            }
        }

        private void EndGame(string message)
        {
            gameTimer.Stop();

            var result = MessageBox.Show(message, "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                Close();
                return;
            }

            ResetGame();
        }

        private void ResetGame()
        {
            Controls.Clear();

            InitializeGame();

            gameTimer.Start();
        }
    }
}
