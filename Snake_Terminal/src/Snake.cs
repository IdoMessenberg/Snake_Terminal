using System.Drawing;

namespace Snake_Terminal.src{
    public static class Snake{
        //--Vars----------------------------------------------------
        private const char Clear = ' ';
        private static readonly char[] SnakeIcons = { 'ᗒ', 'ᗕ', 'ᗐ', 'ᗑ', '║', '═', '╗', '╔', '╝', '╚' };

        private static Point HeadLoc;
        private static List<TailInfo> Tail = new List<TailInfo>();
        private static char Direction = 'n';

        private static readonly ConsoleColor HeadColor = ConsoleColor.DarkGreen;
        private static readonly ConsoleColor TailColor = ConsoleColor.Green;
        private class TailInfo
        {
            public Point Loc;
            public char Direction;
            public TailInfo(Point Loc, char Direction)
            {
                this.Loc = Loc;
                this.Direction = Direction;
            }
        }

        //--public_Func&Var-----------------------------------------
        public static UInt16 Length { get; private set; }

        #region//--Set Snake Before the Game Starts
        public static void Set(UInt16 StarterLength, Point StartLoc)
        {
            Length = StarterLength;

            HeadLoc = StartLoc;
            Print();
        }
        #endregion

        #region//--Updates Snakes location and updates on screen
        public static void Update()
        {
            Move();
            if (Direction != 'n')
            {
                Hit();
                Print();
            }
        }
        #endregion

        //--Private_Func--------------------------------------------

        #region//--Movement
        private static void Move()
        {
            Direction = Event.ControllerInput.Get();

            switch (Direction)
            {
                case 'u':
                    HeadLoc.Y--;
                    break;

                case 'd':
                    HeadLoc.Y++;
                    break;

                case 'l':
                    HeadLoc.X--;
                    break;

                case 'r':
                    HeadLoc.X++;
                    break;

            }
        }
        #endregion

        #region//--Hit
        private static void Hit()
        {
            if (HitWall() || HitHimSelf())
                Main_Class.Game = false;
        }

        private static bool HitWall()
        {
            return (HeadLoc.X == 0 || HeadLoc.X == Console.WindowWidth || HeadLoc.Y == 0 || HeadLoc.Y == Console.WindowHeight);
        }
        private static bool HitHimSelf()
        {
            for (int i = 0; i < Tail.Count; i++)
            {
                if (Tail[i].Loc == HeadLoc)//Tail[i].Loc.X == HeadLoc.X && Tail[i].Loc.Y == HeadLoc.Y)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region//--Print
        private static void Print()
        {
            PrintTail();
            PrintHead();
        }

        private static void PrintHead()
        {
            Console.ForegroundColor = HeadColor;
            Console.SetCursorPosition(HeadLoc.X, HeadLoc.Y);
            switch (Direction)
            {
                case 'u':
                    Console.Write(SnakeIcons[3]);
                    break;
                case 'd':
                    Console.Write(SnakeIcons[2]);
                    break;
                case 'l':
                    Console.Write(SnakeIcons[1]);
                    break;
                case 'r':
                    Console.Write(SnakeIcons[0]);
                    break;
            }
        }

        private static void PrintTail()
        {
            Console.ForegroundColor = TailColor;
            Tail.Add(new TailInfo(HeadLoc, Direction));
            for (int i = 0; i < Tail.Count - 1; i++)
            {
                Console.SetCursorPosition(Tail[i].Loc.X, Tail[i].Loc.Y);
                switch (Tail[i].Direction)
                {
                    case 'u':
                        if (Tail[i + 1].Direction == Tail[i].Direction) { Console.Write(SnakeIcons[4].ToString()); break; }
                        if (Tail[i + 1].Direction == 'l') { Console.Write(SnakeIcons[6].ToString()); break; }
                        if (Tail[i + 1].Direction == 'r') { Console.Write(SnakeIcons[7].ToString()); break; }
                        break;

                    case 'd':
                        if (Tail[i + 1].Direction == Tail[i].Direction) { Console.Write(SnakeIcons[4].ToString()); break; }
                        if (Tail[i + 1].Direction == 'l') { Console.Write(SnakeIcons[8].ToString()); break; }
                        if (Tail[i + 1].Direction == 'r') { Console.Write(SnakeIcons[9].ToString()); break; }
                        break;


                    case 'l':
                        if (Tail[i + 1].Direction == Tail[i].Direction) { Console.Write(SnakeIcons[5].ToString()); break; }
                        if (Tail[i + 1].Direction == 'u') { Console.Write(SnakeIcons[9].ToString()); break; }
                        if (Tail[i + 1].Direction == 'd') { Console.Write(SnakeIcons[7].ToString()); break; }
                        break;

                    case 'r':
                        if (Tail[i + 1].Direction == Tail[i].Direction) { Console.Write(SnakeIcons[5].ToString()); break; }
                        if (Tail[i + 1].Direction == 'u') { Console.Write(SnakeIcons[8].ToString()); break; }
                        if (Tail[i + 1].Direction == 'd') { Console.Write(SnakeIcons[6].ToString()); break; }
                        break;

                }

            }
            Console.SetCursorPosition(Tail[0].Loc.X, Tail[0].Loc.Y);
            Console.Write(Clear);
            if (Tail.Count() >= Length)
            {
                Tail.RemoveAt(0);
            }
        }
        #endregion
        /*
        #region//--[Variables]------------

        #region//>_[Const]--------------

        private static readonly char _Clear = ' ';
        private static readonly char[] _SnakeChars = new char[] { '■', '║', '═', '╗', '╔', '╝', '╚' };
        #endregion
        #region//>_[Mutable]------------

        private static bool _Alive = true;
        //>_[Head]-----
        private static Point _HeadLocation;
        private static char  _Direction = 'n';// n = none 

        //>_[Tail]------
        private static List<Tail_Info> _TailLications = new List<Tail_Info>();
        private static UInt16 _Length;
        #region//>_[Tail_Info]-----------
        private class Tail_Info{
            public Point Location;
            public char Direction;

            public Tail_Info(Point location, char direction){
                Location = location;
                Direction = direction;
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
            _HeadLocation = HeadLocation;
            _Length = Length;
            Print();
        }
        
        //>_Update------------
        public static void Update(){
            if(!_Alive) return;
            MoveSnake();
            if (_Direction != 'n')
            {
                Damage();
                Print();
            }
        }
        #endregion

        #region//--Movement
        private static void MoveSnake(){
            switch (_Direction = Event.ControllerInput.Get()){
                default: return;

                case 'u'://UP
                    _HeadLocation.Y--; return;

                case 'd'://DOWN
                    _HeadLocation.Y--; return;

                case 'l'://LEFT
                    _HeadLocation.X--; return;

                case 'r'://RIGHT
                    _HeadLocation.X++; return;
            }
        }
        #endregion

        #region//--Damage
        private static void Damage(){
            _Alive = !HitWall(0, (UInt16)Console.WindowHeight, 0, (UInt16)Console.WindowWidth);//&& !HitHimself();
        }
        
        private static bool HitWall(UInt16 TopWall, UInt16 BottomWall, UInt16 LeftWall, UInt16 RightWall) {
            return (TopWall == _HeadLocation.Y || BottomWall == _HeadLocation.Y || LeftWall== _HeadLocation.X || RightWall == _HeadLocation.X);
        }

        private static bool HitHimself(){
            for (int i = 0; i < _Length; i++){
                if (_TailLications[i].Location== _HeadLocation) return true;
            }
            return false;
        }
        #endregion

        #region//--Print_On_Screen
        private static void Print(){
            Console.SetCursorPosition(_HeadLocation.X, _HeadLocation.Y);
            Console.Write(_SnakeChars[0]);
            _TailLications.Add(new Tail_Info(_HeadLocation, _Direction));
            for (int i = 0; i < _Length; i++){
                Console.SetCursorPosition(_TailLications[i].Location.X, _TailLications[i].Location.Y);
                switch (_TailLications[i].Direction){
                    case 'u':
                        if (_TailLications[i + 1].Direction == _TailLications[i].Direction) { Console.Write(_SnakeChars[1].ToString(), _TailColour); break; }
                        if (_TailLications[i + 1].Direction == 'l') { Console.Write(_SnakeChars[3].ToString(), _TailColour); break; }
                        if (_TailLications[i + 1].Direction == 'r') { Console.Write(_SnakeChars[4].ToString(), _TailColour); break; }
                        break;

                    case 'd':
                        if (_TailLications[i + 1].Direction == _TailLications[i].Direction) { Console.Write(_SnakeChars[1].ToString(), _TailColour); break;}
                        if (_TailLications[i + 1].Direction == 'l') { Console.Write(_SnakeChars[5].ToString(), _TailColour); break;}
                        if (_TailLications[i + 1].Direction == 'r') { Console.Write(_SnakeChars[6].ToString(), _TailColour); break;}
                        break;


                    case 'l':
                        if (_TailLications[i + 1].Direction == _TailLications[i].Direction) { Console.Write(_SnakeChars[2].ToString(), _TailColour); break;}
                        if (_TailLications[i + 1].Direction == 'u') { Console.Write(_SnakeChars[6].ToString(), _TailColour); break;}
                        if (_TailLications[i + 1].Direction == 'd') { Console.Write(_SnakeChars[4].ToString(), _TailColour); break;}
                        break;

                    case 'r':
                        if (_TailLications[i + 1].Direction == _TailLications[i].Direction) { Console.Write(_SnakeChars[2].ToString(), _TailColour); break; }
                        if (_TailLications[i + 1].Direction == 'u') { Console.Write(_SnakeChars[5].ToString(), _TailColour); break; }
                        if (_TailLications[i + 1].Direction == 'd') { Console.Write(_SnakeChars[3].ToString(), _TailColour); break; }
                        break;
                }
                Console.SetCursorPosition(_TailLications[0].Location.X, _TailLications[0].Location.Y);
                Console.Write(_Clear);
                if (_TailLications.Count >= _Length) _TailLications.RemoveAt(0);
            }
        }
        #endregion
        */

    }
}
