using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TrafficWarden.source.Screen_Manager;

namespace TrafficWarden.source.Screens
{
    class ProtoGameScreen : GameScreen
    {
        public ProtoGameScreen()
        {
            OutputLogging.writeOutput("Starting Prototypical Game Screen");
        }
        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice GD = ScreenManager.GraphicsDevice;
            SpriteBatch SB = ScreenManager.SpriteBatch;
            GD.Clear(Color.Gold);
            base.Draw(gameTime);
        }
    }
}
