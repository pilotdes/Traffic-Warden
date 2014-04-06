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

    public enum TrafficFlowDirection
    {
        Horizontal,
        Vertical,
    }

    #endregion

    /// <summary>
    /// This class is the control class for an individual intersection with traffic lights
    /// it identifies to its respective intersection via the IntersectionIdentifier variable
    /// </summary>
    internal class IntersectionInstance
    {
        #region Fields

        #region Non-Getters-and-Setters

        private MouseState oldState;
        private Texture2D Base;
        private Texture2D Sidewalk;
        private Texture2D Surface;
        private Texture2D DirectionArrowH;
        private Texture2D DirectionArrowV;

        private const int tilesize = 64;

        private Boolean MouseOver;

        #endregion

        #region Event Handlers

        //public EventHandler<EventArgs> OnClicked;
        //public EventHandler<MouseOver> OnMouseOver;
        //public EventHandler<EventArgs> OnLightStateChanged;

        #endregion

        #region Interface Getters and Setters

        #endregion

        #region Custom Getters and Setters

        #region Background Fields

        private string id;
        private IntersectionType type;
        private int numlane;
        private Boolean controlled;
        private IntersectionSurface Isurface;
        private LightState state;
        private TrafficFlowDirection d;


        #endregion

        /// <summary>
        /// The Unique identifier for the intersection instance
        /// </summary>
        public string IntersectionIdentifier
        {
            //this complicated getter and setter gets around an error where
            //the getter would just keep calling itself and causing a stackoverflow exception
            get
            {
                if (id == null)
                {
                    return "";
                }
                return id;
            }
            set { id = value; }
        }


        /// <summary>
        /// Sets the intersection type
        /// </summary>
        public IntersectionType IntersectionType
        {
            get
            {
                if (type == null)
                {
                    return IntersectionType.Crossroads;
                }
                return type;
            }
            set { type = value; }
        }


        /// <summary>
        /// Sets how many lanes the intersection
        /// has running through it
        /// </summary>
        public int NumberOfLanes
        {
            get
            {
                if (numlane == null)
                {
                    return 0;
                }
                return numlane;
            }
            set { numlane = value; }
        }


        /// <summary>
        /// Sets whether or not the intersection is controlled by
        /// lights, and if it isn't, will then bypass all the players
        /// input
        /// </summary>
        public Boolean IsControlled
        {
            get
            {
                if (controlled == null)
                {
                    return false;
                }
                return controlled;
            }
            set { controlled = value; }
        }


        /// <summary>
        /// Sets the Intersection Surface
        /// </summary>
        public IntersectionSurface IntersectionSurface
        {
            get
            {
                if (Isurface == null)
                {
                    return IntersectionSurface.Steel;
                }
                return Isurface;
            }
            set { Isurface = value; }
        }

        /// <summary>
        /// Sets the current State of the lights
        /// </summary>
        public LightState CurrentLightState
        {
            get
            {
                if (state == null)
                {
                    return LightState.Off;
                }
                return state;
            }
            set { state = value; }
        }

        /// <summary>
        /// Sets the Position of the intersection along the X axis
        /// </summary>
        public int PositionX;

        /// <summary>
        /// Sets the position of the intersection along the Y axis
        /// </summary>
        public int PositionY;

        public TrafficFlowDirection Direction
        {
            get
            {
                if (d == null)
                {
                    return TrafficFlowDirection.Horizontal;
                }
                return d;
            }
            set { d = value; }
        }

        public Boolean HasSideWalk;

        #endregion

        #endregion

        #region Initialization

        public IntersectionInstance(int X, int Y, IntersectionType type, IntersectionSurface surface,
            LightState initialLightState, Boolean isControlledL, string ID, int numLanes, Boolean haspavement, TrafficFlowDirection direction)
        {
            OutputLogging.writeOutput("Starting new Intersection Instance. ID = " + ID);
            OutputLogging.writeOutput(ID + " position(x,y): (" + X + ", " + Y + ")");

            #region Setters

            PositionX = X;
            PositionY = Y;
            IntersectionType = type;
            IntersectionSurface = surface;
            CurrentLightState = initialLightState;
            IsControlled = isControlledL;
            IntersectionIdentifier = ID;
            NumberOfLanes = numLanes;
            HasSideWalk = haspavement;
            Direction = direction;


            #endregion

            #region Events

            //OnClicked += OnIntersectionClicked;
            //OnMouseOver += OnIntersectionMouseOver;
            //OnLightStateChanged += OnOnLightStateChanged;

            #endregion

            EntityDict.AddEnity(this);
        }

        #endregion

        #region Methods

        #region Content

        public void LoadContent(ContentManager content)
        {
            string fold = "roadparts/";

            Base = content.Load<Texture2D>(fold + "Bases/intersection");
            if (HasSideWalk)
            {
                Sidewalk = content.Load<Texture2D>(fold + "pavement");
            }
            Surface = content.Load<Texture2D>(fold + "road");
            DirectionArrowH = content.Load<Texture2D>("ArrowH");
            DirectionArrowV = content.Load<Texture2D>("ArrowV");
        }

        #endregion

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
            if ((state.X > PositionX && state.X < PositionX + tilesize)
                && state.Y > PositionY && state.Y < PositionY + tilesize)
            {
                MouseOver = true;
                if (state.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
                {
                    //TODO add code to extend functionality
                    val = true;
                    Console.WriteLine(IntersectionIdentifier+" Clicked");
                    ToggleDirection();
                    OutputLogging.writeOutput(IntersectionIdentifier + " Clicked");
                }
            }
            else
            {
                val = false;
                MouseOver = false;
            }
            oldState = state;
            return val;
        }

        private void ToggleDirection()
        {
            if (Direction == TrafficFlowDirection.Horizontal)
            {
                Direction = TrafficFlowDirection.Vertical;
            }else if (Direction==TrafficFlowDirection.Vertical)
            {
                Direction = TrafficFlowDirection.Horizontal;
            }
        }

        #endregion

        #region Draw and Update Methods

        /// <summary>
        /// Draws the Intersection Instance onto the screen
        /// </summary>
        /// <param name="Spritebatch"></param>
        /// <param name="Sprite"></param>
        public void draw(SpriteBatch Spritebatch)
        {
            Spritebatch.Begin();
            Spritebatch.Draw(Base, new Rectangle(this.PositionX, this.PositionY, tilesize, tilesize), Color.White);
            if (HasSideWalk)
            {
                Spritebatch.Draw(Sidewalk, new Rectangle(this.PositionX, this.PositionY, tilesize, tilesize),
                    Color.White);
            }
            Spritebatch.Draw(Surface, new Rectangle(this.PositionX, this.PositionY, tilesize, tilesize), Color.White);
            if (MouseOver)
            {
                if (Direction == TrafficFlowDirection.Horizontal)
                {
                    Spritebatch.Draw(DirectionArrowH, new Rectangle(PositionX, PositionY, tilesize, tilesize),
                        Color.White);
                }
                else
                {
                    Spritebatch.Draw(DirectionArrowV, new Rectangle(PositionX, PositionY, tilesize,tilesize),
                        Color.White);
                }
                //TODO add code that displays a large set of arrows and crosses to determine what way the traffic is flowing
            }
            Spritebatch.End();
        }

        public void update(GameTime time)
        {
            
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