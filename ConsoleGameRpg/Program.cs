using ConsoleGameRpg.Engine.Graphic;
using ConsoleGameRpg.Engine.Graphic.Menus;
using ConsoleGameRpg.Engine.Music;
using System.Text;

namespace ConsoleGameRpg
{
    public class Program
    {
        //DEVELOP BRANCH

        public static void Main()
        {
            char[,] map = ReadMap("level1.txt");
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('D', ConsoleKey.D, false, false, false);

            int mainHeroX = 2;
            int mainHeroY = 2;

            while (true)
            {

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();                
                
                DrawMap(map);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(mainHeroX, mainHeroY);
                Console.Write("☻");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(55, 0);
                Console.Write(pressedKey.KeyChar);

                pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref mainHeroX, ref mainHeroY);
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int mainHeroX, ref int mainHeroY)
        {

        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x,y] = file[y][x];

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x,y]);
                }
                Console.Write("\n");
            }
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
            {
                if(line.Length > maxLength)
                    maxLength= line.Length;
            }

            return maxLength;
        }
    }
}