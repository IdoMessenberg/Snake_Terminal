using System.Drawing;

namespace Snake_Terminal.src{
    public static class Snake{
        #region//--[Variables]------------

        #region//>_[Const]--------------

        private static readonly char _Clear = ' ';
        private static readonly char[] _SnakeChars = new char[] { '■', '║', '═', '╗', '╔', '╝', '╚' };
        #endregion
        #region//>_[Mutable]------------

        //>_[Head]-----
        private static Point _HeadLocation;
        private static char  _Direction = 'n';// n = none 

        //>_[Tail]------
        private static List<Tail_Info> _TailLications = new List<Tail_Info>();
        private static UInt16 _Length;
        #region//>_[Tail_Info]-----------
        private class Tail_Info{
            public Point _Location;
            public char _Direction;

            public Tail_Info(Point location, char direction){
                _Location = location;
                _Direction = direction;
            }
        }
        #endregion


        //>_[Colours]---
        private static ConsoleColor _HeadColour;
        private static ConsoleColor _TailColour;
        #endregion
        #endregion
        #region//--[Public_Functions]-----

        //>_Initialize---------
        public static void Initialize(Point HeadLocation, UInt16 Length){

        }
        
        //>_Update------------
        public static void Update(){

        }
        #endregion

        #region//--Movement
        private static void MoveSnake()
        {
            switch (_Direction = Event.Input.Get())
            {
                default: return;

                case 'u':
                    _HeadLocation.Y--; return;

                case 'd':
                    _HeadLocation.Y--; return;

                case 'l':
                    _HeadLocation.X--; return;

                case 'r':
                    _HeadLocation.X++; return;
            }
        }
        #endregion

    }
}
