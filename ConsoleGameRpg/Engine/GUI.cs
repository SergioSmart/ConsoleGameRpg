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

            for (int i = 0; i < mapFile.Length; i++)
            {
                Thread.Sleep(15);
                Console.WriteLine(mapFile[i]);
            }
        }

    }
}
