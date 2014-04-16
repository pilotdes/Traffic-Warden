using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficWarden.source.Screens.AI
{

    #region Enumerations

    internal enum TrafficDirection
    {
        Horizontal,
        Vertical,
    }

    #endregion

    internal class TrafficFlowSystem
    {
        #region Fields

        #region Constants

        /// <summary>
        ///     The Chances of a Semi being generated
        /// </summary>
        private const float ChanceOfTruck = 0.2f;

        #endregion

        #region Non Getters and Setters

        private Enum Difficulty;

        #endregion

        #region Background Fields

        #endregion

        #region Getters and Setters

        #endregion

        #endregion

        #region Initialization

        public TrafficFlowSystem(Enum Difficulty)
        {
            // TODO: Complete member initialization
            this.Difficulty = Difficulty;
        }

        #endregion

        public void Update()
        {
        }
    }
}