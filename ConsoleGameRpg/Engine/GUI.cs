using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine
{
    internal class GUI
    {
        public GUI() { }

        public string[] ReadMap(string path)
        {
            string[] mapFile = File.ReadAllLines(path);
            return mapFile;
        }

        public void WriteIntro(string[] map)
        {          
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.SetWindowSize(190, 55);

            for (int i = 0; i < map.Length; i++)
            {
                Console.SetCursorPosition(48, 9 + i);
                Thread.Sleep(30);
                Console.WriteLine(map[i]);    
            }

            Console.SetCursorPosition(80, 35);
            
            Console.WriteLine("Нажмите любую клавишу, что-бы продолжить..."); 

            Console.ReadKey();
        }
    }
}
