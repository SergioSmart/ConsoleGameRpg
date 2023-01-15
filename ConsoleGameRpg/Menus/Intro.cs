using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Menus
{
    internal class Intro
    {
        public Intro() { }
        
        public void Print()
        {
            string file = File.ReadAllText("intro.txt");
            Console.WriteLine(file);
        }

    }
}
