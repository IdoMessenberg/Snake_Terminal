using Snake_Terminal.src;
using System.Text;

public static class Main_Class{
    public static bool Game = true;
    static void Main(string[] args){
        Console.CursorVisible = false;
        Console.OutputEncoding = Encoding.GetEncoding("UTF-16");
        Console.SetWindowSize(50, 25);
        Snake.Set(25, new System.Drawing.Point(5, 5));

        while (Game)
        {
            Snake.Update();
            Thread.Sleep(100);
        }
    }
}