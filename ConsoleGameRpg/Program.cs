using ConsoleGameRpg.Engine;
using System.Text;

namespace ConsoleGameRpg
{
    internal class Program
    {
        //DEVELOP BRANCH



        public static void Main()
        {
            string[] map;
            GUI gui = new GUI();

            

            map = gui.ReadMap("resources/menus/intro.txt");
            gui.WriteIntro(map);

            

            //Console.SetWindowPosition(20, 20);

            //string path = "resources/menus/intro.txt";
            //var gui = new GUI();

            //gui.PrintMap(path);

            //Console.ReadKey();
        }
    }
}