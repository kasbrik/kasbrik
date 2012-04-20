using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Kasbrik.Components;
using Microsoft.Xna.Framework.Input;

namespace Kasbrik.Entities
{
    public class Ball
    {
        public const int Width = 8;
        public const int Height = 8;

        public float X { get; private set; }
        public float Y { get; private set; }

        public const float BallXSpeed = 150;
        public const float BallYSpeed = 150;

        public Vector2 Position
        {
            get { return new Vector2(this.X, this.Y); }
        }

        public Vector2 Velocity { get; private set; }

        private Level Level { get; set; }

        public Ball(Level level)
        {
            this.Level = level;

            this.X = (Level.Width - Ball.Width) / 2;
            this.Y = (Level.Height - 3 * Paddle.Height);
        }

        internal void Update(GameTime gameTime)
        {
            KeyboardManager kbManager = this.Level.Game.Services.GetService<KeyboardManager>();

            if (this.Velocity == Vector2.Zero && kbManager.CurrentState.IsKeyDown(Keys.Enter))
                this.Velocity = new Vector2(0.3f, -0.6f);

            UpdatePosition(gameTime);
            CheckPosition();
            CheckPaddleCollision();
        }

        private void CheckPaddleCollision()
        {
        }

        private void CheckPosition()
        {
            this.Velocity.Normalize();

            // Ensure we are in the level "box"
            // When hitting a level side, reverse the corresponding velocity
            if (this.X < 0)
            {
                this.X = 0;
                this.Velocity = new Vector2(-this.Velocity.X, this.Velocity.Y);
            }
            if (this.X > Level.Width - Ball.Width)
            {
                this.X = Level.Width - Ball.Width;
                this.Velocity = new Vector2(-this.Velocity.X, this.Velocity.Y);
            }

            if (this.Y < 0)
            {
                this.Y = 0;
                this.Velocity = new Vector2(this.Velocity.X, -this.Velocity.Y);
            }
            if (this.Y > Level.Height - Ball.Height)
            {
                this.Y = Level.Height - Ball.Height;
                this.Velocity = new Vector2(this.Velocity.X, -this.Velocity.Y);
            }
        }

        private void UpdatePosition(GameTime gameTime)
        {
            this.X += (float)gameTime.ElapsedGameTime.TotalSeconds * this.Velocity.X * BallXSpeed;
            this.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * this.Velocity.Y * BallYSpeed;
        }
    }
}
