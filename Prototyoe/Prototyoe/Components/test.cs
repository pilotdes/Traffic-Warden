using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TrafficWarden.source.Screens.Entitys
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class test : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private GraphicsDeviceManager GDM;
        private Texture2D traffic;

        #region Properties

        /// <summary>
        /// Identifies the individual intersection for easier Identification
        /// Also is stored in a dictionary
        /// </summary>
        public string IntersectionIdentifier
        {
            get { return (IntersectionIdentifier); }
            set { IntersectionIdentifier = value; }}

        /// <summary>
        /// Sets the Position of the Intersection, Along the X axis
        /// </summary>
        public int X
        {
            get { return (X); }
            set { X = value; }
        }

        /// <summary>
        /// Sets the position of the Intersection, along the Y axis
        /// </summary>
        public int Y
        {
            get { return (Y); }
            set { Y = value; }
        }

        #endregion

        #region Initialization
        public test(Game game)
            : base(game)
        {
            
            // TODO: Construct any child components here

            //TODO add the current instance of Intersection to
            //a class that holds a dictionary of all currently active intersections
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }

        #endregion

        #region Content
        protected override void LoadContent()
        {
            ContentManager contentManager = Game.Services.GetService(typeof(ContentManager)) as ContentManager;
            traffic=contentManager.Load<Texture2D>("TrafLite");
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        #endregion

        #region Draw and Update
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(
    typeof(SpriteBatch)) as SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(traffic, new Rectangle(50,50,100,100), Color.White );
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        #endregion
    }
}
