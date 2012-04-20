using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kasbrik.Entities
{
    public class Level : DrawableGameComponent
    {
        public const int Width = 400;
        public const int Height = 400;

        public Paddle Paddle { get; private set; }
        public List<Brick> Bricks { get; private set; }
        public List<Ball> Balls { get; private set; }

        private SpriteBatch spriteBatch;

        private Texture2D PaddleTexture { get; set; }
        private Texture2D BallTexture { get; set; }
        private Texture2D BackgroundTexture { get; set; }

        public Level(Game game)
            : base(game)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();

            this.Paddle = new Paddle(this);

            this.Balls = new List<Ball>();
            this.Balls.Add(new Ball(this));

            CreateBricks();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            // Get spritebatch instance
            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);

            this.PaddleTexture = this.Game.Content.Load<Texture2D>("paddle");
            this.BallTexture = this.Game.Content.Load<Texture2D>("ball");

            this.BackgroundTexture = new Texture2D(this.Game.GraphicsDevice, 1, 1);
            this.BackgroundTexture.SetData(new Color[] { Color.White });
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update paddle & balls position
            this.Paddle.Update(gameTime);
            this.Balls.ForEach(
                b => b.Update(gameTime)
                );
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.BackgroundTexture, new Rectangle(0,0, Level.Width, Level.Height), Color.YellowGreen);
            this.spriteBatch.End();

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.PaddleTexture, this.Paddle.Position, Color.White);
            this.Balls.ForEach(
                b => this.spriteBatch.Draw(this.BallTexture, b.Position, Color.White)
                );
            this.spriteBatch.End();
        }

        private void CreateBricks()
        {
            
        }
    }
}
