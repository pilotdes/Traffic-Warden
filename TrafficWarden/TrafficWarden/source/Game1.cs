using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nuclex.Input;
using Nuclex.UserInterface;
using Nuclex.UserInterface.Controls;
using Nuclex.UserInterface.Controls.Desktop;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Screen = Nuclex.UserInterface.Screen;

namespace TrafficWarden.source
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GuiManager guiManager;
        private InputManager inputManager;
        private MouseState mouseState;
        private LabelControl message;
        private Texture2D menuBackTEX;
        private UnhandledExceptionEventHandler handler;
        TextWriter outWriter = new StreamWriter("OutputLog.txt");
        #endregion

        public Game1()
        {            
            handler =
    new UnhandledExceptionEventHandler(Target);
            try
            {
                outWriter.WriteLine(DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString());
                PrintToOutput("Starting Program");
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                guiManager = new GuiManager(Services);
                inputManager = new InputManager(Services, Window.Handle);
                Components.Add(this.inputManager);
                Components.Add(this.guiManager);
                this.guiManager.DrawOrder = 1000;
                IsMouseVisible = true;

                PrintToOutput("Finished Starting Program");
            }
            catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                PrintToOutput("Initializing Program");
                base.Initialize();
                Viewport viewport = GraphicsDevice.Viewport;
                Nuclex.UserInterface.Screen mainScreen = new Nuclex.UserInterface.Screen(viewport.Width, viewport.Height);
                this.guiManager.Screen = mainScreen;
                mainScreen.Desktop.Bounds = new UniRectangle(
                    new UniScalar(0.0f, 0.0f), new UniScalar(0.0f, 0.0f), // x and y = 10%
                    new UniScalar(0.0f, 0.0f), new UniScalar(0.0f, 0.0f) // width and height = 80%
                    );
                message = new LabelControl();
                message.Bounds = new UniRectangle(new UniVector(100, -50), new UniVector(50, 50));
                this.guiManager.Screen.Desktop.Children.Add(message);
                createMenu(mainScreen);
                PrintToOutput("Finished Initializing Program");
            }
            catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            PrintToOutput("Loading Content");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //catch any errors that might arise while loading content
            try
            {
                menuBackTEX = Content.Load<Texture2D>("TrafLite");
            }
            catch (ContentLoadException e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));

            }
            // TODO: use this.Content to load your game content here
            PrintToOutput("Finished Loading Content");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            try
            {
                PrintToOutput("Unloading Content");
                // TODO: Unload any non ContentManager content here
                PrintToOutput("Finished Unloading Content");
                outWriter.Close();
            }
            catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            try
            {
                // Allows the game to exit
                if (Microsoft.Xna.Framework.Input.GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
                mouseState = Mouse.GetState();
                // TODO: Add your update logic here

                base.Update(gameTime);
            } catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            try
            {
                GraphicsDevice.Clear(Color.DarkGray);
                spriteBatch.Begin();
                spriteBatch.Draw(menuBackTEX, GraphicsDevice.Viewport.Bounds, Color.White);
                spriteBatch.End();
                message.Text = ("X: " + mouseState.X.ToString() + ", Y: " + mouseState.Y.ToString());
                base.Draw(gameTime);
            }
            catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            PrintToOutput("Exiting Program...");
            base.OnExiting(sender, args);
        }

        #region Button Clicks
        private void settingsClickEvent(object sender, EventArgs args)
        {
            PrintToOutput("Settings_Button Clicked");
        }
        private void playClickEvent(object sender, EventArgs args)
        {
            PrintToOutput("Play_Button Clicked");
        }

        #endregion

        private void createMenu(Screen mainScreen)
        {
            PrintToOutput("Creating Menu");
            try
            {
                float centerW = mainScreen.Width / 2f;
                ButtonControl playGameControl = new ButtonControl();
                playGameControl.Bounds = new UniRectangle(mainScreen.Width / 2 - 50, 10, 100, 32
               );
                playGameControl.Text = "Play Game";
                playGameControl.Pressed += delegate(object sender, EventArgs args)
                {
                    playClickEvent(sender, args);
                };
                mainScreen.Desktop.Children.Add(playGameControl);

                ButtonControl settingsControl = new ButtonControl();
                settingsControl.Bounds = new UniRectangle(centerW - 50,
                    playGameControl.Bounds.Location.Y + playGameControl.Bounds.Size.Y + 10, 100, 32);
                settingsControl.Text = "Settings";
                settingsControl.Pressed += delegate(object sender, EventArgs args)
                {
                    settingsClickEvent(sender, args);
                };
                mainScreen.Desktop.Children.Add(settingsControl);

                ButtonControl quitButton = new ButtonControl();
                quitButton.Text = "Quit";
                quitButton.Bounds = new UniRectangle(centerW - 50,
                    settingsControl.Bounds.Location.Y + settingsControl.Bounds.Size.Y + 10, 100, 32
                );
                quitButton.Pressed += delegate(object sender, EventArgs arguments)
                {
                    PrintToOutput("Exit_Button Clicked");
                    Exit();
                };
                mainScreen.Desktop.Children.Add(quitButton);

            }
            catch (Exception e)
            {
                handler.Invoke(e, new UnhandledExceptionEventArgs(e, true));
            }
            PrintToOutput("Finished Creating Menu");
            #region Reference

            //             // Button to open another "New Game" dialog
//             ButtonControl newGameButton = new ButtonControl();
//             newGameButton.Text = "New Game";
//             newGameButton.Bounds = new UniRectangle(
//               new UniScalar(1.0f, -190.0f), new UniScalar(1.0f, -32.0f), 100, 32
//             );
//             newGameButton.Pressed += delegate(object sender, EventArgs arguments)
//             {
//                 // Insert at index 0 to make it the firstmost window
//                 this.gui.Screen.Desktop.Children.Insert(0, new DemoDialog());
//             };
//             mainScreen.Desktop.Children.Add(newGameButton);
// 
//             // Button through which the user can quit the application
//             ButtonControl quitButton = new ButtonControl();
//             quitButton.Text = "Quit";
//             quitButton.Bounds = new UniRectangle(
//               new UniScalar(1.0f, -80.0f), new UniScalar(1.0f, -32.0f), 80, 32
//             );
//             quitButton.Pressed += delegate(object sender, EventArgs arguments) { Exit(); };
//             mainScreen.Desktop.Children.Add(quitButton);

            #endregion
        }

        #region Error Handling

        private void Target(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine("Tracing Error");
            Console.WriteLine((sender as Exception));
            Console.WriteLine(unhandledExceptionEventArgs.ExceptionObject);
            Console.WriteLine("Is Terminating = " + unhandledExceptionEventArgs.IsTerminating);
            printToLog((sender as Exception), unhandledExceptionEventArgs);
            outWriter.WriteLine();
            PrintToOutput("**********EXCEPTION**********");
            PrintToOutput("See ErrorLog For Details");
            outWriter.WriteLine();
            Exit();
        }
        private Boolean printToLog(Exception e, UnhandledExceptionEventArgs args)
        {
            string error = "ErrorLog" + DateTime.Now.ToFileTime() + ".txt";
            TextWriter tw = new StreamWriter(error);
            tw.WriteLine(DateTime.Now);
            tw.WriteLine(e);
            tw.WriteLine("Is Terminating: " + args.IsTerminating);
            tw.WriteLine();
            tw.WriteLine("Please email a copy of this errorlog and the Outputlog to Bomberdes@live.com, along with a description of what you were doing at the time, and the developer will get right on to fixing the problem");
            tw.Close();
            return true;
        }
        #endregion

        #region Output Handling

        private void PrintToOutput(string output)
        {
            outWriter.WriteLine(DateTime.Now.ToLongTimeString() + " " + output);
        }
        #endregion
    }
}