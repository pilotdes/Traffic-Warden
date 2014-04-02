using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TrafficWarden.source.Screens.AI;
using TrafficWarden.source.Screens.Entitys;
using TrafficWarden.source.Screen_Manager;

namespace TrafficWarden.source.Screens
{
    class ProtoGameScreen : GameScreen
    {
        private Texture2D test;
        private TrafficFlowSystem AIflow;
        private TrafficLightSystem AISystem;
        private IntersectionInstance intersection;
        private Boolean firsttime;
        public ProtoGameScreen(Enum Difficulty)
        {
            OutputLogging.writeOutput("Starting Prototypical Game Screen");
            AIflow = new TrafficFlowSystem(Difficulty);
            AISystem=new TrafficLightSystem(Difficulty);
            firsttime = true;
        }
        public override void LoadContent()
        {
            ContentManager Content = ScreenManager.Game.Content;
            test = Content.Load<Texture2D>("TrafLite");
            init();
            base.LoadContent();
        }

        private void init()
        {
            SpriteBatch SB = ScreenManager.SpriteBatch;
            intersection = new IntersectionInstance(test, SB);
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
            //IntersectionInstance system = new IntersectionInstance();
     
            AIflow.Update();
            AISystem.Update();
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice GD = ScreenManager.GraphicsDevice;
            SpriteBatch SB = ScreenManager.SpriteBatch;
            //GD.Clear(Color.Gold);
                firsttime = false;
            //intersection.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
