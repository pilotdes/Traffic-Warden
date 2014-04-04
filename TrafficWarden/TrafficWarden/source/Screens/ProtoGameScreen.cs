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
        private Texture2D test;
        private TrafficFlowSystem AIflow;
        private TrafficLightSystem AISystem;
        private IntersectionInstance intersection;
        private MouseState mouseState;
        private KeyboardState keyboardState;

        public ProtoGameScreen(Enum Difficulty, Game game)
        {
            OutputLogging.writeOutput("Starting Prototypical Game Screen");
            AIflow = new TrafficFlowSystem(Difficulty);
            AISystem = new TrafficLightSystem(Difficulty);
            intersection=new IntersectionInstance(150,150,IntersectionType.Crossroads, IntersectionSurface.Ashphalt, 
            LightState.Green, true, "TEST", 2);
        }

        public override void LoadContent()
        {
            ContentManager Content = ScreenManager.Game.Content;
            test = Content.Load<Texture2D>("TrafLite");
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void HandleInput(InputState input)
        {
            mouseState = Mouse.GetState();
            if (intersection.CheckMouseInteraction(mouseState))
            {
                Console.WriteLine("clicked");
            }
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

            intersection.draw(SB, test);

            base.Draw(gameTime);
        }
    }
}