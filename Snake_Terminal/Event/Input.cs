namespace Snake_Terminal.Event{
    public static class ControllerInput
    {
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
                case ConsoleKey _Key when ((_Key == ConsoleKey.UpArrow || _Key == ConsoleKey.W) && _Diraction != 'd'):
                    return _Diraction = 'u';

                //>_[DOWN]------------
                case ConsoleKey _Key when ((_Key == ConsoleKey.DownArrow || _Key == ConsoleKey.S) && _Diraction != 'u'):
                    return _Diraction = 'd';

                //>_[LEFT]------------
                case ConsoleKey _Key when ((_Key == ConsoleKey.LeftArrow || _Key == ConsoleKey.A) && _Diraction != 'r'):
                    return _Diraction = 'l';

                //>_[DOWN]------------
                case ConsoleKey _Key when ((_Key == ConsoleKey.RightArrow || _Key == ConsoleKey.D) && _Diraction != 'l'):
                    return _Diraction = 'r';
            }
        }
    }
}
