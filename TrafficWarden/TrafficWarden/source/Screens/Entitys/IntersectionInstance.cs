using System;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TrafficWarden.source.Screens.Entitys.Dictionarys;
using TrafficWarden.source.Screen_Manager;
using Artemis;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

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
    internal class IntersectionInstance
    {
        #region Fields

        private MouseState oldState;

        #region Event Handlers

        public EventHandler<EventArgs> OnClicked;
        public EventHandler<EventArgs> OnMouseOver;
        public EventHandler<EventArgs> OnLightStateChanged;
        #endregion

        #region Interface Getters and Setters

        #endregion

        #region Custom Getters and Setters

        /// <summary>
        /// The Unique identifier for the intersection instance
        /// </summary>
        public string IntersectionIdentifier;

        //{
        //    get { return IntersectionIdentifier; }
        //    set { IntersectionIdentifier = value; }
        //}

        /// <summary>
        /// Sets the intersection type
        /// </summary>
        public IntersectionType IntersectionType;

        //{
        //    get { return IntersectionType; }
        //    set { IntersectionType = value; }
        //}

        /// <summary>
        /// Sets how many lanes the intersection
        /// has running through it
        /// </summary>
        public int NumberOfLanes;

        //{
        //    get { return (NumberOfLanes); }
        //    set { NumberOfLanes = value; }
        //}

        /// <summary>
        /// Sets whether or not the intersection is controlled by
        /// lights, and if it isn't, will then bypass all the players
        /// input
        /// </summary>
        public Boolean IsControlled;

        //{
        //    get { return (IsControlled); }
        //    set { IsControlled = value; }
        //}

        /// <summary>
        /// Sets the Intersection Surface
        /// </summary>
        public IntersectionSurface IntersectionSurface;

        //{
        //    /// <summary>
        //    /// this has a range of values, which are:
        //    /// dirt, gravel, concrete, ashphalt, grass and mud
        //    /// </summary>
        //    get { return (IntersectionSurface); }
        //    set { IntersectionSurface = value; }
        //}

        /// <summary>
        /// Sets the current State of the lights
        /// </summary>
        public LightState CurrentLightState;

        //{
        //    get { return (CurrentLightState); }
        //    set { CurrentLightState = value; }
        //}

        /// <summary>
        /// Sets the sprite to use as the intersection
        /// </summary>
        public Texture2D IntersectionSprite
        {
            get { return (IntersectionSprite); }
            set { IntersectionSprite = value; }
        }

        /// <summary>
        /// Sets the Position of the intersection along the X axis
        /// </summary>
        public int PositionX;

        //{
        //    get { return (PositionX); }
        //    set { PositionX = value; }
        //}

        /// <summary>
        /// Sets the position of the intersection along the Y axis
        /// </summary>
        public int PositionY;

        //{
        //    get { return (PositionY); }
        //    set { PositionY = value; }
        //}

        #endregion

        #endregion

        #region Event Handlers

        #endregion

        #region Initialization

        public IntersectionInstance(int X, int Y, IntersectionType type, IntersectionSurface surface,
            LightState initialLightState, Boolean isControlledL, string ID, int numLanes)
        {
            #region Setters

            PositionX = X;
            PositionY = Y;
            IntersectionType = type;
            IntersectionSurface = surface;
            CurrentLightState = initialLightState;
            IsControlled = isControlledL;
            IntersectionIdentifier = ID;
            NumberOfLanes = numLanes;

            #endregion

            #region Events
            OnClicked+=OnIntersectionClicked;
            OnMouseOver+=OnIntersectionMouseOver;
            OnLightStateChanged += OnOnLightStateChanged;
            #endregion

            EntityDict.AddEnity(this);
        }

        #endregion

        #region Methods

        #region Decision Methods

        protected void GetSprite()
        {
            //TODO add decision code to load what sprite should be used
        }

        #endregion

        #region Input Methods

        public Boolean CheckMouseInteraction(MouseState state)
        {
            Boolean val = false;
            if ((state.X > PositionX && state.X < PositionX + 50)
                && state.Y > PositionY && state.Y < PositionY + 50)
            {
                if (state.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    //TODO add code to extend functionality
                    val =true;
                }
            }
            else
            {
                val= false;
            }
            oldState = state;
            return val;
        }

        #endregion

        #region Draw and Update Methods

        /// <summary>
        /// Draws the Intersection Instance onto the screen
        /// </summary>
        /// <param name="Spritebatch"></param>
        /// <param name="Sprite"></param>
        public void draw(SpriteBatch Spritebatch, Texture2D Sprite)
        {
            Spritebatch.Begin();
            Spritebatch.Draw(Sprite, new Rectangle(this.PositionX,this.PositionY,50,50),Color.White );
            Spritebatch.End();
        }

        #endregion

        #region EventHandler Methods

        private void OnOnLightStateChanged(object sender, EventArgs eventArgs)
        {
            //TODO change the CurrentLightState field to the light state
            //TODO add a timing thread to set when the lights change from yellow to red
            //in a 50kph zone, the lights should take 4 seconds to change from yellow to red
            throw new NotImplementedException();
        }


        private void OnIntersectionMouseOver(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        private void OnIntersectionClicked(object sender, EventArgs eventArgs)
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