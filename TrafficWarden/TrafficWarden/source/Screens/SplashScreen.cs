using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nuclex.UserInterface.Controls;
using TrafficWarden.source.Screen_Manager;
using TrafficWarden.source;

namespace TrafficWarden.source.Screens
{
    internal class SplashScreen : GameScreen
    {
        public SplashScreen()
        {
            Console.WriteLine("testing");
            OutputLogging.writeOutput("Starting Splashscreen");
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = ScreenManager.GraphicsDevice;


            graphics.Clear(Color.Goldenrod);
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