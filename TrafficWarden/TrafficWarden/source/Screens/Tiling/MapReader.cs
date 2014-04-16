using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficWarden.source.Screens.Tiling
{
    class MapReader
    {
        #region Properties

        #region FileName Constants

        private const string tilesDIR = "Tiles";

        #region Corners

        #endregion

        #region Straights

        #endregion

        #region intersections

        #endregion

        #endregion

        #region Background Fields

        protected int Level;

        #endregion

        #region Properties

        public int LevelMapId
        {
            get { return Level; }
            set { Level=value; }
        }

        #endregion

        #endregion

        #region Methods

        #region Main Methods

        public static void ReadMain()
        {
            //TODO add reading methods
        }

        private static void TileType(string args)
        {
            string temp = args.Substring(0, 3);
            switch (temp)
            {
                case "PLA":
                    PlainArgs(args);
                    break;
                case "INT":
                    IntersectionArgs(args);
                    break;
                case "STR":
                    StraightArgs(args);
                    break;
                case "COR":
                    CornerArgs(args);
                    break;
            }
        }

        #endregion

        #region Loading Methods

        #endregion

        #region Tile Methods

        private static void IntersectionArgs(string args)
        {
            
        }

        private static void StraightArgs(string args)
        {
            
        }

        private static void PlainArgs(string args)
        {
            string temp = args.Substring(args.Length - 3);
            switch (temp)
            {
                case "TAR":
                    //TODO add tarmac tile
                    break;
                case "DIR":
                    //TODO add dirt tile
                    break;
                case "ASH":
                    //TODO add asphalt tile
                    break;
                case "GRA":
                    //TODO add grass tile
                    break;
            }
        }

        private static void CornerArgs(string args)
        {
            
        }

        #endregion

        #endregion
    }
}
