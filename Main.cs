using System;
using OpenTK;

namespace WindowTest
{
    class MainClass
    {
        static GameWindow window;
        static Window game;

        public static void Main(string[] args)
        {
            window = new GameWindow(720, 720);
            game = new Window(window);
        }
    }
}