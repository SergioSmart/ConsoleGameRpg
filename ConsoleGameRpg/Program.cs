using ConsoleGameRpg.Engine.Graphic;
using System.Text;

namespace ConsoleGameRpg
{
    public class Program
    {
        //DEVELOP BRANCH



        public static void Main()
        {
            string[] map;
            GUI gui = new GUI();

            

            map = gui.ReadMap("resources/menus/intro.txt");
            gui.WriteMap(map);

            

            //Console.SetWindowPosition(20, 20);

            //string path = "resources/menus/intro.txt";
            //var gui = new GUI();

            //gui.PrintMap(path);

            //Console.ReadKey();
        }
    }
}