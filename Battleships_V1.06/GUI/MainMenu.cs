using System;
using System.Threading;
using Battleships_V1._06.Audio;

namespace Battleships_V1._06.GUI
{
    public static class MainMenu
    {
        const int WINDOW_WIDTH = 160;
        const int WINDOW_HIGHT = 26;

        const int DELAY = 500;
        const int SHIP_SIZE_X = 68;
        const int SHIP_SIZE_Y = 26;
        const int TITLE_X = 69;
        const int TITLE_Y = 3;

        private static string[] ShipArry = new string[2];
        public static bool Menu = true;
        private static bool setGrid = false;
        private static int i = 0;
        public static int GridSizeX = 27;
        public static int GridSizeY = 27;

        public static void print()
        {
            setShipArry();
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HIGHT);
            MainMenuAudio.Play();
            Text();
            while (Menu || setGrid)
            {
                UpdateShips();
                Close();
                GetGridSize();
            }
            Console.Clear();
            GameMenu.print();
            MainMenuAudio.Stop();
            return;
        }

        private static void Close()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consolekey = Console.ReadKey(true);
                if (consolekey.Key.Equals(ConsoleKey.Enter))
                {
                    Menu = false;
                    setGrid = true;
                }
            }
        }

        #region//--Set grid
        /// <summary>
        /// Gets grid X and Y size 
        /// </summary>
        private static void GetGridSize()
        {
            if (setGrid)
            {
                while (GridSizeX > 26)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                    Console.Write("Enter Board Size:");
                    GridSizeX = int.Parse(Console.ReadLine());
                    if (GridSizeX > 26)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                        Console.Write("Error Enter A Smaller Number!");


                        Thread.Sleep(1500);//Dealy to read


                        Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                        Console.Write("                             ");
                    }
                    else if (GridSizeY > 5 && GridSizeX < 26)
                    {
                        setGrid = false;
                    }
                }
                Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                Console.Write("                                ");
                while (GridSizeY > 26)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                    Console.Write("Enter Board Size:");
                    GridSizeY = int.Parse(Console.ReadLine());
                    if (GridSizeY > 26)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                        Console.Write("Error Enter A Smaller Number!");


                        Thread.Sleep(1500);//Dealy to read


                        Console.SetCursorPosition(TITLE_X, TITLE_Y + 12);
                        Console.Write("                             ");
                    }
                    else
                    {
                        setGrid = false;
                    }
                }
            }


        }
        #endregion

        #region//--Prints text
        /// <summary>
        /// Prints the title and the secondery text on screen
        /// </summary>
        private static void Text()
        {
            Console.Title="Battleships";


            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(TITLE_X, TITLE_Y);
            Console.Write("██████╗  █████╗ ████████╗████████╗██╗     ███████╗███████╗██╗  ██╗██╗██████╗ ███████╗");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 1);
            Console.Write("██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝██╔════╝██║  ██║██║██╔══██╗██╔════╝");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 2);
            Console.Write("██████╔╝███████║   ██║      ██║   ██║     █████╗  ███████╗███████║██║██████╔╝███████╗");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 3);
            Console.Write("██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝  ╚════██║██╔══██║██║██╔═══╝ ╚════██║");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 4);
            Console.Write("██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗███████║██║  ██║██║██║     ███████║");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 5);
            Console.Write("╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝╚═╝╚═╝     ╚══════╝");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 8);
            Console.Write("╔═╗┬─┐┌─┐┌─┐┌─┐  ╔═╗┌┐┌┌┬┐┌─┐┬─┐  ╔╦╗┌─┐  ╔═╗┬  ┌─┐┬ ┬");
            Console.SetCursorPosition(TITLE_X - 1, TITLE_Y + 9);
            Console.Write(">╠═╝├┬┘├┤ └─┐└─┐  ║╣ │││ │ ├┤ ├┬┘   ║ │ │  ╠═╝│  ├─┤└┬┘");
            Console.SetCursorPosition(TITLE_X, TITLE_Y + 10);
            Console.Write("╩  ┴└─└─┘└─┘└─┘  ╚═╝┘└┘ ┴ └─┘┴└─   ╩ └─┘  ╩  ┴─┘┴ ┴ ┴ ");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(TITLE_X + 20, TITLE_Y + 6);

        }
        #endregion

        #region//--Ship Aniamtion
        #region//--Updates the ships animation
        /// <summary>
        /// Updates the ships animation
        /// </summary>
        private static void UpdateShips()
        {
            for (int x = 0; x < SHIP_SIZE_X; x++)
            {
                for (int y = 0; y < SHIP_SIZE_Y; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(ShipArry[i]);

            i++;
            i = i % 2;
            Thread.Sleep(DELAY);

        }
        #endregion

        #region//--Sets ships arry 
        private static void setShipArry()
        {
            #region//Ship0
            ShipArry[0] = "--    .-\"\"-.\r\n" +
                          "   ) (     )\r\n" +
                          "  (   )   (\r\n" +
                          "     /     )\r\n" +
                          "    (_    _)                     0_,-.__\r\n" +
                          "      (_  )_                     |_.-._/\r\n" +
                          "       (    )                    |_--..\\\r\n" +
                          "        (__)                     |__--_/\r\n" +
                          "     |''   ``\\                   |\r\n" +
                          "     |        \\                  |      /b.\r\n" +
                          "     |         \\  ,,,---===?A`\\  |  ,==y'\r\n" +
                          "   ___,,,,,---==\"\"\\        |M] \\ | ;|\\ |>\r\n" +
                          "           _   _   \\   ___,|H,,---==\"\"\"\"bno,\r\n" +
                          "    o  O  (_) (_)   \\ /          _     AWAW/\r\n" +
                          "                     /         _(+)_  dMM/\r\n" +
                          "      \\@_,,,,,,---==\"   \\      \\\\|//  MW/\r\n" +
                          "--''''\"                         ===  d/\r\n" +
                          "                                    //\r\n" +
                          "                                    ,'_____________________________________________________________________________________________________________________________\r\n" +
                          "   \\    \\    \\     \\               ,/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n" +
                          "                         _____    ,'  ~~~   .-\"\"-.~~~~~~  .-\"\"-.\r\n " +
                          "     .-\"\"-.           ///==---   /`-._ ..-'      -.__..-'\r\n" +
                          "            `-.__..-' =====\\\\\\\\\\\\ V/  .---\\.\r\n" +
                          "                      ~~~~~~~~~~~~, _',--/_.\\  .-\"\"-.\r\n" +
                          "                            .-\"\"-.___` --  \\|         -.__..-";
            #endregion

            #region//Ship1
            ShipArry[1] = "--    .-\"\"-.\r\n" +
                          "    (       )\r\n" +
                          "   (  /  __(\r\n" +
                          "     (_     )\r\n" +
                          "    (__   _)                     0__,-._\r\n" +
                          "      (_  )_                     |__.-./\r\n" +
                          "       (   _)                    |__--.\\\r\n" +
                          "        (_)                      |___--/\r\n" +
                          "     |''   ``\\                   |\r\n" +
                          "     |        \\                  |      /b.\r\n" +
                          "     |         \\  ,,,---===?A`\\  |  ,==y'\r\n" +
                          "   ___,,,,,---==\"\"\\        |M] \\ | ;|\\ |>\r\n" +
                          "           _   _   \\   ___,|H,,---==\"\"\"\"bno,\r\n" +
                          "    o  O  (_) (_)   \\ /          _     AWAW/\r\n" +
                          "                     /         _(+)_  dMM/\r\n" +
                          "      \\@_,,,,,,---==\"   \\      \\\\|//  MW/\r\n" +
                          "--''''\"                         ===  d/\r\n" +
                          "                                    //\r\n" +
                          "                                    ,'_____________________________________________________________________________________________________________________________\r\n" +
                          "   \\    \\    \\     \\               ,/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n" +
                          "                         _____    ,'  ~~.   .-\"\"-_.~._.~~  .-\"\"-.\r\n " +
                          "     .-\"\"-.           ///==---   /`-,_ ._-'      ,-.__..-'\r\n" +
                          "            `-.__..-' =====\\\\\\\\\\\\ V/  .--_\\.\r\n" +
                          "                      `~~~~-~~~~~~ _',--/_.\\  .-\"\"-.\r\n" +
                          "                            `-\"\"-._.-` --  \\|         -._-,.-";
            #endregion
        }
        #endregion
        #endregion
    }
}
