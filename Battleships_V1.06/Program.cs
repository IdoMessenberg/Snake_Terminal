using System;
using Battleships_V1._06.GUI;
using Battleships_V1._06.Src;

namespace Battleships_V1._06
{
    public static class Program
    {
        const int WINDOW_WIDTH = 160;
        const int WINDOW_HIGHT = 26;
        public const int BATTLESHIPS_NUMBER = 9;

        public static bool Game = true;
        public static int[,] Board { get; set; }
        public static char[,] GridBoard { get; set; }
        public static Battleship[] battleships { get; set; }

        static void Main(string[] args)
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HIGHT);
            MainMenu.print();
            SetShips();

            Console.SetWindowSize(((MainMenu.GridSizeX + 1) * 6)+20, ((MainMenu.GridSizeY + 1) * 2)+10);
            while (Game)
            {
                GetCoordinates();
                Close();
                WinMenu.End();
                Console.SetCursorPosition(Console.WindowWidth, 0);
            }
            WinMenu.print();
        }

        #region//--Get attack coordinates
        /// <summary>
        /// Gets Coordinates for GameMenu.AttackCoordinates(X, Y); and displays info on screen
        /// </summary>
        private static void GetCoordinates()
        {
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6) + 5, 5);
            Console.Write("Rounds: " + WinMenu.Rounds);

            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6) + 5, 7);
            Console.Write("Score: " + WinMenu.Score);

            Console.SetCursorPosition(34, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("                                ");

            Console.SetCursorPosition(0, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("Enter coardnation (number, char): ");
            int X = int.Parse(Console.ReadLine());

            if (X < 10) Console.SetCursorPosition(37, ((MainMenu.GridSizeY + 1) * 2) + 3);
            else Console.SetCursorPosition(38, ((MainMenu.GridSizeY + 1) * 2) + 3);

            char Y = char.Parse(Console.ReadLine());
            GameMenu.AttackCoordinates(X, Y);

            Console.SetCursorPosition(0, 0);
        }
        #endregion

        #region//--Setting up ships
        /// <summary>
        /// Setting up the battleship arry
        /// </summary>
        private static void SetShips()
        {
            battleships = new Battleship[BATTLESHIPS_NUMBER];
            for (int i = BATTLESHIPS_NUMBER - 1; i > -1; i--) 
            {
                battleships[i] = new Battleship(i + 1);
            }
        }
        #endregion

        #region//--Close Game
        /// <summary>
        /// Closes the window if you press escape
        /// </summary>
        private static void Close()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consolekey = Console.ReadKey(true);
                if (consolekey.Key.Equals(ConsoleKey.Escape))
                {
                    Game = false;
                }
            }
        }
        #endregion
    }
}
