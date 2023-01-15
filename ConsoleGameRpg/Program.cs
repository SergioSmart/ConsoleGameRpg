using ConsoleGameRpg.Engine.Graphic;
using ConsoleGameRpg.Engine.Graphic.Menus;
using System.Text;

namespace ConsoleGameRpg
{
    public class Program
    {
        //DEVELOP BRANCH

        public static void Main()
        {
            Intro intro = new Intro();

            intro.WriteMap();
        }
    }
}