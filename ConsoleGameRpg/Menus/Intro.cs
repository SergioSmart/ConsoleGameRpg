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
            string[] file = File.ReadAllLines("intro.txt");


            for (int i = 0; i < file.Length; i++)
            {
                Console.WriteLine(file[i]);
            }
        }

    }
}
