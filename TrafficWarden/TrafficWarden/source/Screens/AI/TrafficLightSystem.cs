using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficWarden.source.Screens
{
    /// <summary>
    ///     This Class ties all the TrafficLightControlSystem classes together
    ///     and helps them co-operate and synchronize, where needed
    /// </summary>
    internal class TrafficLightSystem
    {
        private Enum Difficulty;

        private Enum LightState;

        public TrafficLightSystem(Enum Difficulty)
        {
            // TODO: Complete member initialization
            this.Difficulty = Difficulty;
        }

        public void Update()
        {
        }
    }
}