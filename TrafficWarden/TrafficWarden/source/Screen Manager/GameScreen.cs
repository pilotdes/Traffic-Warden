using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficWarden.source.Screen_Manager
{
    public enum ScreenState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }

    public abstract class GameScreen
    {
        public bool IsPopup
        {
            get { return IsPopup; }
            protected set { IsPopup = value; }
        }
    }
}
