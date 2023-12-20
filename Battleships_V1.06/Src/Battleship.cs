using System;
using System.Collections.Generic;

namespace Battleships_V1._06.Src
{
    public class Battleship
    {
        public int ID { get; set; }
        public int Size { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
        public Random Random { get; set; }


        public Battleship(int ID)
        {
            this.ID = ID;
            this.Size = SetSize(ID);
            Random = new Random();
            this.Direction = SetDirec();
            SetLoc();
            PrintOnGrid();
        }
        #region//--Print ship on the main grid
        /// <summary>
        /// Prints ships location on the main grid (Program.Board)
        /// </summary>
        public void PrintOnGrid()
        {
            if (Direction == 'v')
            {
                for (int i = 0; i < Size + 1; i++)
                {
                    Program.Board[X, Y + i] = ID;
                }
            }
            if (Direction == 'h')
            {
                for (int i = 0; i < Size + 1; i++)
                {
                    Program.Board[X + i, Y] = ID;
                }
            }
        }
        #endregion

        #region//--Sets ships size
        /// <summary>
        /// Sets ships size acording to its ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private int SetSize(int ID)
        {
            if (ID <= 4) return 0;
            if (ID <= 7) return 1;
            return 3;
        }
        #endregion

        #region//--Set ships location
        /// <summary>
        /// Sets ships X and Y location
        /// </summary>
        private void SetLoc()
        {
            if (Direction == 'v')
            {
                this.X = Random.Next(0, Program.Board.GetLength(0));
                this.Y = Random.Next(0, Program.Board.GetLength(1) - Size - 1);
            }
            if (Direction == 'h')
            {
                this.X = Random.Next(0, Program.Board.GetLength(0) - Size);
                this.Y = Random.Next(0, Program.Board.GetLength(1));
            }
            IsEmpty(X, Y);
        }
        #endregion

        #region//--Checks surrounding points around the ship
        /// <summary>
        /// makes sure that ships would not be placed on or next to other ships
        /// </summary>
        private void IsEmpty(int X, int Y)
        {
            if (Program.Board[X, Y] != 0) { SetLoc(); return; }

            List<int[]> Checks = new List<int[]>();
            if (Direction == 'v')
            {
                Checks.Add(new int[] { X, Y });
                if (Y > 0)
                {
                    Checks.Add(new int[] { X, Y - 1 });
                }
                if (Y + Size < Program.Board.GetLength(1) - 1)
                {
                    Checks.Add(new int[] { X, Y + Size + 1 });
                }
                if (Size != 0)
                {
                    Checks.Add(new int[] { X, Y + 1 });
                    if (Size == 3)
                    {

                        Checks.Add(new int[] { X, Y + 2 });
                        Checks.Add(new int[] { X, Y + 3 });
                    }
                }
                if (X > 0)
                {
                    Checks.Add(new int[] { X - 1, Y });
                    if (Size != 0) Checks.Add(new int[] { X - 1, Y + 1 });
                    if (Size == 3)
                    {
                        Checks.Add(new int[] { X - 1, Y + 2 });
                        Checks.Add(new int[] { X - 1, Y + 3 });
                    }
                }
                if (X < Program.Board.GetLength(0) - 1)
                {
                    Checks.Add(new int[] { X + 1, Y });
                    if (Size != 0) { Checks.Add(new int[] { X + 1, Y + 1 }); }
                    if (Size == 3)
                    {
                        Checks.Add(new int[] { X + 1, Y + Size - 1 });
                        Checks.Add(new int[] { X + 1, Y + Size });
                    }
                }
            }
            if (Direction == 'h')
            {
                Checks.Add(new int[] { X, Y });
                if (X > 0)
                {
                    Checks.Add(new int[] { X - 1, Y });
                }
                if (X + Size < Program.Board.GetLength(0) - 1)
                {
                    Checks.Add(new int[] { X + Size + 1, Y });
                }
                if (Size != 0)
                {
                    Checks.Add(new int[] { X + 1, Y });
                    if (Size == 3)
                    {
                        Checks.Add(new int[] { X + 2, Y });
                        Checks.Add(new int[] { X + 3, Y });
                    }
                }
                if (Y > 0)
                {
                    Checks.Add(new int[] { X, Y - 1 });
                    if (Size != 0) Checks.Add(new int[] { X + 1, Y - 1 });
                    if (Size == 3)
                    {
                        Checks.Add(new int[] { X + 2, Y - 1 });
                        Checks.Add(new int[] { X + 3, Y - 1 });
                    }
                }
                if (Y < Program.Board.GetLength(1) - 1)
                {
                    Checks.Add(new int[] { X, Y + 1 });
                    if (Size != 0) Checks.Add(new int[] { X + 1, Y + 1 });
                    if (Size == 3)
                    {
                        Checks.Add(new int[] { X + 2, Y + 1 });
                        Checks.Add(new int[] { X + 3, Y + 1 });
                    }
                }
            }
            foreach (int[] point in Checks)
            {
                if (Program.Board[point[0], point[1]] != 0)
                {
                    SetLoc();
                }
            }
        }
        #endregion

        #region//-Randomly sets ships direction
        /// <summary>
        /// Sets ships direction
        /// </summary>
        private char SetDirec()
        {
            if (Size == 0) return 'v';
            Random = new Random();
            int rnd = Random.Next(0, 2);
            if (rnd == 0) return 'v';
            return 'h';
        }
        #endregion
    }
}
