using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine.Graphic
{
    public abstract class GUI
    {
        //protected int ConsoleWidth { get; } = 190;
        //protected int ConsoleHeight { get; } = 55;

        public abstract string[] ReadMap(string path);

        public abstract void WriteMap(string[] map,                                    
                                      ConsoleColor backgroundColor, 
                                      ConsoleColor foregroundColor,
                                      int consoleWidth = 190,
                                      int consoleHeight = 55, );      
    }
}
