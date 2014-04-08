using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using TrafficWarden.source.Screens.AI;
using TrafficWarden.source.Screens.Entitys;
using TrafficWarden.source.Screens.Entitys.Dictionarys;
using TrafficWarden.source.Screen_Manager;

namespace TrafficWarden.source.Screens
{
    internal class ProtoGameScreen : GameScreen
    {

        #region fields
        #region fields
        private Texture2D test;
        private TrafficFlowSystem AIflow;
        private TrafficLightSystem AISystem;
        private IntersectionInstance intersection;
        private IntersectionInstance intersection2;
        private MouseState mouseState;
        private KeyboardState keyboardState;
        private Boolean firsttime = true;
        #endregion
        #region Background Fields

        private ContentManager man;
        #endregion
        #region Getters and Setters

        public ContentManager Content
        {
            get
            {
                if (man == null)
                {
                    throw new ArgumentNullException();
                }
                return man;
            }
            set { man = value; }
        }


        #endregion
        #endregion

        public ProtoGameScreen(Enum Difficulty, Game game)
        {
            OutputLogging.writeOutput("Starting Prototypical Game Screen");
            AIflow = new TrafficFlowSystem(Difficulty);
            AISystem = new TrafficLightSystem(Difficulty);
            intersection=new IntersectionInstance(150,150,IntersectionType.Crossroads, IntersectionSurface.Ashphalt, 
            LightState.Green, true, "TEST", 2,true, TrafficFlowDirection.Horizontal);
            intersection2=new IntersectionInstance(250,250,IntersectionType.Crossroads, IntersectionSurface.Tarmac,
                LightState.Red, true, "Test2", 2, false, TrafficFlowDirection.Horizontal);
        }

        public override void LoadContent()
        {
            Content = ScreenManager.Game.Content;
            Content.RootDirectory = "Content";
            intersection.LoadContent(Content);
            intersection2.LoadContent(Content);
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void HandleInput(InputState input)
        {
            mouseState = Mouse.GetState();
            intersection.CheckMouseInteraction(mouseState);
            intersection2.CheckMouseInteraction(mouseState);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            AIflow.Update();
            AISystem.Update();
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice GD = ScreenManager.GraphicsDevice;
            SpriteBatch SB = ScreenManager.SpriteBatch;
            intersection.draw(SB);
            intersection2.draw(SB);

            base.Draw(gameTime);
        }
    }
}