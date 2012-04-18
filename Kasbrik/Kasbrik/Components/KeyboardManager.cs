using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Kasbrik.Components
{
    public class KeyboardManager : GameComponent
    {
        public KeyboardState PreviousState { get; private set; }
        public KeyboardState CurrentState { get; private set; }

        public KeyboardManager(Game game)
            : base(game)
        {
            // Register myself
            this.Game.Services.AddService(typeof(KeyboardManager), this);
        }

        public override void Update(GameTime gameTime)
        {
            // Update previous states
            this.PreviousState = this.CurrentState;

            // Update current states
            this.CurrentState = Keyboard.GetState();
        }

        /// <summary>
        /// Returns whether a key has been pressed since last update of keyboard state.
        /// </summary>
        /// <param name="key">Enumerated value that specifies the key to query.</param>
        /// <returns></returns>
        public bool IsKeyPressed(Keys key)
        {
            return (this.PreviousState.IsKeyUp(key) && this.CurrentState.IsKeyDown(key));
        }
    }
}
