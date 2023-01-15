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

        public void PrintMap(string path)
        {
            string[] mapFile = File.ReadAllLines(path);
            //Console.Beep(400, 1000);
            //Console.Beep(210, 1000);
            //Console.Beep(220, 1000);
            //Console.Beep(230, 1000);
            //Console.Beep(240, 1000);
            //Console.Beep(250, 1000);
            //Console.Beep(260, 1000);
            //Console.Beep(270, 1000);
            //Console.Beep(280, 1000);
            //Console.Beep(290, 1000);
            //Console.Beep(300, 1000);
            //Console.Beep(1100, 1000);

            for (int i = 0; i < mapFile.Length; i++)
            {
                Thread.Sleep(15);
                Console.WriteLine(mapFile[i]);
            }
        }

    }
}
