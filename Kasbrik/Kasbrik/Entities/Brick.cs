using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Kasbrik.Entities
{
    public class Brick
    {
        public const int Height = 12;
        public const int Width = 25;

        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2 Position
        {
            get { return new Vector2(this.X, this.Y); }
        }

        private Level Level { get; set; }

        public Brick(Level level, float x, float y)
        {
            this.Level = level;
            this.X = x;
            this.Y = y;
        }

        internal bool CollidesWith(Ball ball)
        {
            Rectangle ballRect = new Rectangle((int)ball.X, (int)ball.Y, Ball.Width, Ball.Height);
            Rectangle myRect = new Rectangle((int)this.X, (int)this.Y, Paddle.Width, Paddle.Height);

            return ballRect.Intersects(myRect);
        }

        internal void HandleBallCollision(Ball ball)
        {
            float distX, distY;

            if (ball.X > this.X && ball.X + Ball.Width < this.X + Brick.Width)
            {
                ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
                return;
            }
            
            if (ball.Velocity.X > 0)
            {
                if (ball.Velocity.Y > 0)
                {
                    // Collision from top left
                    distX = ball.X + Ball.Width - this.X;
                    distY = ball.Y + Ball.Height - this.Y;
                }
                else
                {
                    // Collision from bottom left
                    distX = ball.X + Ball.Width - this.X;
                    distY = this.Y + Brick.Height - ball.Y;
                }
            }
            else
            {
                if (ball.Velocity.Y > 0)
                {
                    // Collision from top right
                    distX = this.X + Brick.Width - ball.X;
                    distY = ball.Y + Ball.Height - this.Y;
                }
                else
                {
                    // Collision from bottom right
                    distX = this.X + Brick.Width - ball.X;
                    distY = this.Y + Brick.Height - ball.Y;
                }
            }

            if (distX > distY)
                ball.Velocity = new Vector2(-ball.Velocity.X, ball.Velocity.Y);
            else
                ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
        }
    }
}
