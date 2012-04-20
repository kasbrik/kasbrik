using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Kasbrik.Components;
using Microsoft.Xna.Framework.Input;

namespace Kasbrik.Entities
{
    public class Paddle
    {
        public const int Width = 50;
        public const int Height = 14;

        private const float PaddleXSpeed = 200;

        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2 Position
        {
            get { return new Vector2(this.X, this.Y); }
        }

        public Vector2 Velocity { get; private set; }

        private Level Level { get; set; }

        public Paddle(Level level)
        {
            this.Level = level;

            this.X = (Level.Width - Paddle.Width) / 2;
            this.Y = (Level.Height - 2 * Paddle.Height);
        }

        internal void Update(GameTime gameTime)
        {
            UpdateVelocity();
            UpdatePosition(gameTime);
            CheckPosition();
        }

        private void CheckPosition()
        {
            // Ensure paddle is still in the level area
            if (this.X < 0)
                this.X = 0;
            if (this.X > (Level.Width - Paddle.Width))
                this.X = Level.Width - Paddle.Width;
        }

        private void UpdatePosition(GameTime gameTime)
        {
            // Update X position of paddle based on time elapsed and velocity
            this.X += (float)gameTime.ElapsedGameTime.TotalSeconds * PaddleXSpeed * this.Velocity.X;
        }

        private void UpdateVelocity()
        {
            KeyboardManager kbManager = this.Level.Game.Services.GetService<KeyboardManager>();

            Vector2 newVelocity = Vector2.Zero;

            if (kbManager.CurrentState.IsKeyDown(Keys.Left))
                newVelocity -= Vector2.UnitX;
            if (kbManager.CurrentState.IsKeyDown(Keys.Right))
                newVelocity += Vector2.UnitX;

            this.Velocity = newVelocity;
        }
    }
}
