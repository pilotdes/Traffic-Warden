using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TrafficWarden.source.Screens;
using TrafficWarden.source.Screen_Manager;

namespace TrafficWarden.source
{
    class Control : Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;

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
            screenManager.AddScreen(new ProtoGameScreen(), null);
            
            OutputLogging.writeOutput("Finished Initializing Control Class");
        }
    }
}
