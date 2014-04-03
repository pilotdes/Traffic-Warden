using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TrafficWarden.source.Screens;
using TrafficWarden.source.Screen_Manager;

namespace TrafficWarden.source
{
    class Control : Game
    {
        private enum Difficulty
        {
            Easy,
            Medium,
            Hard,
        }
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;
        SpriteBatch spriteBatch;
        ContentManager contentManager;
        private GameComponent component;

        public Control()
        {
            OutputLogging.initOutputting();
            OutputLogging.writeOutput("Initializing Control Class");
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);

            // use the config file to change settings within the program
            graphics.PreferredBackBufferWidth = Config.Default.WinWidth;
            graphics.PreferredBackBufferHeight = Config.Default.WinHeight;
            graphics.IsFullScreen = Config.Default.isFullScreen;

            // Create the screen manager component.
            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            screenManager.AddScreen(new ProtoGameScreen(Difficulty.Easy, this), null);
            
            OutputLogging.writeOutput("Finished Initializing Control Class");
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
