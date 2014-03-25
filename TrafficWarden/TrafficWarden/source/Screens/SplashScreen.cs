using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TrafficWarden.source.Screen_Manager;
using TrafficWarden.source;

namespace TrafficWarden.source.Screens
{
    class SplashScreen : GameScreen
    {
        private Boolean isStarted = false;
        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            if (isStarted == false)
            {
                OutputLogging.writeOutput("Starting SplashScreen");
                isStarted = true;
            }
            GraphicsDevice graphics = ScreenManager.GraphicsDevice;
            graphics.Clear(Color.DarkGray);
            base.Draw(gameTime);
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
