using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrafficWarden.source.Screens.Entitys
{
    #region Enumerations
    public enum IntersectionType
    {
        Crossroads,
        TeeIntersection,
        FortyFiveIntersection,
    }

    public enum LightState
    {
        Green,
        FlashingYellow,
        Yellow,
        Red,
        Off,
    }

    public enum IntersectionSurface
    {
        Dirt,
        Gravel,
        Concrete,
        Ashphalt,
        Tarmac,
        Steel,
    }
    #endregion

    /// <summary>
    /// This class is the control class for an individual intersection with traffic lights
    /// it identifies to its respective intersection via the IntersectionIdentifier variable
    /// </summary>
    internal class IntersectionInstance : IDrawable, IUpdateable
    {
        private GraphicsDeviceManager graphics;
        #region Fields

        //Custom Getters and Setters
        public string IntersectionIdentifier
        {
            get { return IntersectionIdentifier; }
            set { IntersectionIdentifier = value; }
        }

        /// <summary>
        /// Sets the intersection type
        /// </summary>
        public IntersectionType IntersectionType
        {
            get { return IntersectionType; }
            set { IntersectionType = value; }
        }

        /// <summary>
        /// Sets how many lanes the intersection
        /// has running through it
        /// </summary>
        public int NumberOfLanes
        {
            get { return (NumberOfLanes); }
            set { NumberOfLanes = value; }
        }

        /// <summary>
        /// Sets whether or not the intersection is controlled by
        /// lights, and if it isn't, will then bypass all the players
        /// input
        /// </summary>
        public Boolean HasLights
        {
            get { return (HasLights); }
            set { HasLights = value; }
        }

        /// <summary>
        /// Sets the Intersection Surface
        /// </summary>
        public IntersectionSurface IntersectionSurface
        {
            /// <summary>
            /// this has a range of values, which are:
            /// dirt, gravel, concrete, ashphalt, grass and mud
            /// </summary>
            get { return (IntersectionSurface); }
            set { IntersectionSurface = value; }
        }

        public LightState CurrentLightState
        {
            get { return (CurrentLightState); }
            set { CurrentLightState = value; }
        }

        public Texture2D IntersectionSprite;
        //{
        //    get { return (IntersectionSprite); }
        //    set { IntersectionSprite = value; }
        //}

        public int PositionX 
        {
            get { return (PositionX); }
            set { PositionX = value; }
        }

        public int PositionY
        {
            get { return (PositionY); }
            set { PositionY = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return (SpriteBatch); }
            set { SpriteBatch = value; }
        }

        #region Fields for interfaces

        //Getters and Setters for IDrawable
        public bool Visible { get; private set; }

        public int DrawOrder { get; private set; }
        //

        //Getters and setters for IUpdateable
        public bool Enabled { get; private set; }
        public int UpdateOrder { get; private set; }
        //

        #endregion

        #endregion

        #region Event Handlers

        public event EventHandler<EventArgs> OnLightStateChanged;
        public event EventHandler<EventArgs> OnIntersectionSurfaceChanged;

        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Initialization 

        public IntersectionInstance(Texture2D sprite, SpriteBatch spriteBatch)
        {
            this.IntersectionSprite = sprite;
            this.SpriteBatch = spriteBatch;
            this.Visible = true;
            this.Enabled = true;
        }

        #endregion

        #region Methods

        public void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.Draw(IntersectionSprite, new Rectangle(50,50, 200,200), Color.White);
            this.SpriteBatch.End();
            //throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            //TODO check mouse input

            //TODO implement an OnLightStateChanged method/EventHandler
            OnLightStateChanged += OnOnLightStateChanged;
            //TODO implement an OnIntersectionSurfaceChanged method/EventHandler
            OnIntersectionSurfaceChanged += OnOnIntersectionSurfaceChanged;

            throw new NotImplementedException();
        }

        #region EventHandler Methods
        private void OnOnLightStateChanged(object sender, EventArgs eventArgs)
        {
            //TODO change the CurrentLightState field to the light state
            //TODO add a timing thread to set when the lights change from yellow to red
            //in a 50kph zone, the lights should take 4 seconds to change from yellow to red
            throw new NotImplementedException();
        }

        private void OnOnIntersectionSurfaceChanged(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Alternate Thread Methods

        public void LightTimer()
        {

        }
        #endregion
        #endregion
    }
}