namespace Snake_Terminal.Event{
    public static class Input{
        #region//--[Variables]------------

        private static ConsoleKeyInfo _KeyInputInfo;
        private static char _Diraction = 'n';
        #endregion
        public static char Get(){
            if(!Console.KeyAvailable) return _Diraction;

            _KeyInputInfo = Console.ReadKey(true);
            switch (_KeyInputInfo.Key){
                default:
                    return _Diraction;

                //>_[UP]--------------
                case ConsoleKey _Key when (_Key == ConsoleKey.UpArrow || _Key == ConsoleKey.W):
                    return _Diraction = 'u';

                //>_[DOWN]------------
                case ConsoleKey _Key when (_Key == ConsoleKey.DownArrow || _Key == ConsoleKey.S):
                    return _Diraction = 'd';

                //>_[LEFT]------------
                case ConsoleKey _Key when (_Key == ConsoleKey.LeftArrow || _Key == ConsoleKey.A):
                    return _Diraction = 'l';

                //>_[DOWN]------------
                case ConsoleKey _Key when (_Key == ConsoleKey.RightArrow || _Key == ConsoleKey.D):
                    return _Diraction = 'r';
            }
        }
    }
}
