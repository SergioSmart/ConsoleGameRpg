using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine.Graphic
{
    public abstract class GUI
    {
        public abstract string[] ReadMap(string path);

        public abstract void WriteMap(string[] map,                                    
                                      ConsoleColor backgroundColor, 
                                      ConsoleColor foregroundColor,
                                      int consoleWidth,
                                      int consoleHeight);      
    }
}
