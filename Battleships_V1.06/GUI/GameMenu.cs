using System;
using System.Threading;

namespace Battleships_V1._06.GUI
{
    public static class GameMenu
    {
        private static string Abc = "abcdefghijklmnopqrstuvwxyz";//used to get index in AttackCoordinates
        public static void print()
        {
            SetBoards();
            Board(MainMenu.GridSizeX, MainMenu.GridSizeY);
            Console.SetWindowSize(((MainMenu.GridSizeX + 1) * 6) + 20, ((MainMenu.GridSizeY + 1) * 2) + 20);
            Line();
        }

        #region//--Game board
        /// <summary>
        /// Prints The main game board
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public static void Board(int m, int n)
        {
            if (m > 0 && n > 0 && n < 27 && m * n >= 18)
            {
                char current = 'a';
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  " + 0 + "  |");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("  " + current + "  |");
                    current++;
                }
                for (int i = 0; i < Program.GridBoard.GetLength(0); i++)
                {

                    Console.WriteLine();
                    for (int k = 0; k < Program.GridBoard.GetLength(1); k++)
                    {
                        if (i == 0 || k == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("_____|");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("_____|");
                        }
                    }
                    Console.Write("_____|");
                    Console.WriteLine();
                    if (i > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" " + (i + 1) + "  |");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  " + (i + 1) + "  |");
                        Console.ResetColor();
                    }
                    for (int j = 0; j < Program.GridBoard.GetLength(1); j++)
                    {
                        Console.Write($"  {Program.GridBoard[i, j]}  |");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid parameters");
            }
        }
        public static void Line()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, (MainMenu.GridSizeY + 1) * 2);
                Console.Write('█');
            }
        }
        #endregion

        #region//--Set game boards
        /// <summary>
        /// Sets up both Board and GridBoard
        /// </summary>
        private static void SetBoards()
        {
            Program.Board = new int[MainMenu.GridSizeX, MainMenu.GridSizeY];
            Program.GridBoard = new char[MainMenu.GridSizeX, MainMenu.GridSizeY];
            for (int i = 0; i < Program.Board.GetLength(0); i++)
            {
                for (int j = 0; j < Program.Board.GetLength(1); j++)
                {
                    Program.Board[i, j] = 0;
                    Program.GridBoard[i, j] = '?';
                }
            }
        }
        #endregion

        #region//--Attack coordinates
        public static void AttackCoordinates(int X , char Y)
        {
            GridUpdate(X - 1, Abc.IndexOf(Y));
        }
        #endregion

        #region//--Update grid
        /// <summary>
        /// Updates the grid shown on screen
        /// </summary>
        public static void GridUpdate(int x, int y)
        {
            WinMenu.Rounds++;

            if (Program.Board[x, y] != 0 && Program.GridBoard[x,y] == '?')
            {

                if (Program.Board[x, y] <= 4)
                {
                    Program.GridBoard[x, y] = '*';
                    WinMenu.Score++;
                    Hit();
                }

                else
                {
                    bool all = true;
                    Program.GridBoard[x, y] = '+';
                    for (int i = 0; i < Program.Board.GetLength(0); i++)
                    {
                        for (int j = 0; j < Program.Board.GetLength(1); j++)
                        {
                            if (Program.Board[i, j] == Program.Board[x, y] && Program.GridBoard[i, j] != '+')
                            {
                                all = false;
                            }
                        }
                    }

                    if (all)
                    {
                        Program.GridBoard[x, y] = '*';
                        WinMenu.Score++;
                        Hit();
                    }
                }
            }
            else
            {
                Program.GridBoard[x, y] = '-';
                Miss();
            }

            Console.SetCursorPosition(0, 0);
            Board(MainMenu.GridSizeX, MainMenu.GridSizeY);
        }
        #endregion

        #region//-Hit of Miss screen
        private static void Hit()
        {
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 2);
            Console.Write("╦ ╦╦╔╦╗");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("╠═╣║ ║ ");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 4);
            Console.Write("╩ ╩╩ ╩ ");

            Thread.Sleep(1000);

            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 2);
            Console.Write("            ");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("            ");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 4);
            Console.Write("            ");
        }
        private static void Miss()
        {
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 2);
            Console.Write("╔╦╗╦╔═╗╔═╗");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("║║║║╚═╗╚═╗");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 4);
            Console.Write("╩ ╩╩╚═╝╚═╝");

            Thread.Sleep(1000);

            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 2);
            Console.Write("            ");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 3);
            Console.Write("            ");
            Console.SetCursorPosition(((MainMenu.GridSizeX + 1) * 6)-10, ((MainMenu.GridSizeY + 1) * 2) + 4);
            Console.Write("           ");
        }
        #endregion
    }
}
