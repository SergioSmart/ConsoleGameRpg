using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine.Graphic.Menus
{
    public class Intro : GUI
    {
        private string[] _map = null;

        public Intro()
        {
            
        }

        public override string[] ReadMap(string path)
        {
            string[] mapFile = File.ReadAllLines(path);
            return mapFile;
        }

        public override void WriteMap(string[] map, 
                                      ConsoleColor backgroundColor,
                                      ConsoleColor foregroundColor,
                                      int consoleWidth = 190,
                                      int consoleHeight = 55)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Clear();
            Console.SetWindowSize(consoleWidth, consoleHeight);

            for (int i = 0; i < map.Length; i++)
            {
                Console.SetCursorPosition(48, 9 + i);
                Thread.Sleep(30);
                Console.WriteLine(map[i]);
            }

            Console.SetCursorPosition(80, 35);

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить ...");

            Console.ReadKey();
        }
    }
}
