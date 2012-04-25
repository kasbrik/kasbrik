using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Kasbrik.Entities;
using GameLib.Events;

namespace Kasbrik.Components
{
    public class ScoreComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private int CurrentScore { get; set; }

        private SpriteFont ScoreFont { get; set; }

        private ISubscription<BrickDestroyedEvent> brickDestroyedSubscription;

        public ScoreComponent(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            this.DrawOrder = 100;

            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this.CurrentScore = 0;

            this.ScoreFont = this.Game.Content.Load<SpriteFont>("ScoreFont");

            // Subscribe to brick destroyed events
            IEventAggregator eventAggregator = this.Game.Services.GetService<IEventAggregator>();
            if (eventAggregator != null)
            {
                brickDestroyedSubscription = eventAggregator.Subscribe<BrickDestroyedEvent>(OnBrickDestroyed);
            }
        }

        private void OnBrickDestroyed(BrickDestroyedEvent brickDestroyedEvent)
        {
            this.CurrentScore += 100;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            this.spriteBatch.DrawString(this.ScoreFont, this.CurrentScore.ToString(), Vector2.Zero, Color.White);
            this.spriteBatch.End();
        }
    }
}
