using ConsoleGameRpg.Engine.Graphic;
using ConsoleGameRpg.Engine.Graphic.Menus;
using ConsoleGameRpg.Engine.Music;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleGameRpg
{
    public class Program
    {
        //DEVELOP BRANCH
        private const int ScreenWidth = 170; //170
        private const int ScreenHeight = 46; //46

        public static void Main()
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);
            Console.CursorVisible = false;




            char[] charScreen = new char[ScreenWidth * ScreenHeight];
            
            string strScreen = File.ReadAllText("level1-2d.txt");
          
            charScreen = strScreen.ToCharArray();

            while (true)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(charScreen, 0, charScreen.Length);
            }


            Console.ReadKey();
            //Console.SetWindowSize(1, 1);
            //Console.SetBufferSize(80, 80);
            //Console.SetWindowSize(40, 20);
            //int bufferWidth = Console.BufferWidth;
            //int bufferHeight = Console.BufferHeight;
            //Console.WriteLine("WindowLeft: " + windowLeft + "   WindowTop: " + windowTop);
            //Console.WriteLine(new string('1', 111));
            //Console.WriteLine($"BW = {bufferWidth}\tBH = {bufferHeight}\tWW = {windowWidth}\tWH = {windowHeight}");

            //char[,] map = ReadMap("level1.txt");
            //ConsoleKeyInfo pressedKey;
            //Console.CursorVisible = false;

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        MusicBeep.PlayTrack1(true);
            //    }
            //});


            //int playerPositionX = 2;
            //int playerPositionY = 2;

            //while (true)
            //{


            //    //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //    //Console.ForegroundColor = ConsoleColor.Yellow;
            //    //Console.Clear();



            //    //DrawMap(map);
            //    //Console.ForegroundColor = ConsoleColor.Magenta;
            //    //Console.SetCursorPosition(playerPositionX, playerPositionY);
            //    //Console.Write("☻");

            //    //pressedKey = Console.ReadKey();
            //    //HandleInput(pressedKey, ref playerPositionX, ref playerPositionY, map);
            //    //Thread.Sleep(54);
            //}
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int playerPositionX, ref int playerPositionY, char[,] map) 
        {
            int[] direction = GetDirection(pressedKey);

            int nextPlayerPositionX = playerPositionX + direction[0];
            int nextPlayerPositionY = playerPositionY + direction[1];

            if (map[nextPlayerPositionX, nextPlayerPositionY] != '█') 
            {
                playerPositionX = nextPlayerPositionX;
                playerPositionY = nextPlayerPositionY;
            }

            //switch (pressedKey.Key)
            //{
            //    case ConsoleKey.UpArrow:
            //        playerPositionY -= 1;
            //        break;
            //    case ConsoleKey.DownArrow:
            //        playerPositionY += 1;
            //        break;
            //    case ConsoleKey.LeftArrow:
            //        playerPositionX -= 1;
            //        break;
            //    case ConsoleKey.RightArrow:
            //        playerPositionX += 1;
            //        break;
            //}
        }

        // a piece of shit
        //private static char[] MakeOneDimension(char[,] map)
        //{
        //    char[] oneDMap = new char[map.GetLength(0)];
        //    int count = 0;
        //    for (int x = 0; x < map.GetLength(1); x++)
        //    {
        //        for (int y = 0; y < map.GetLength(0); y++)
        //        {
        //            oneDMap[count] = map[x, y];
        //            count++;
        //        }
        //    }

        //    return oneDMap;
        //}

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    direction[1] = -1;
                    break;
                case ConsoleKey.DownArrow:
                    direction[1] = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    direction[0] = -1;
                    break;
                case ConsoleKey.RightArrow:
                    direction[0] = 1;
                    break;
            }

            return direction;
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = file[y][x];

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            //char[] mapToDraw = MakeOneDimension(map);
            //for (int i = 0; i < mapToDraw.Length; i++)
            //{
            //    Console.Write(mapToDraw[i]);
            //}


            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                    maxLength = line.Length;
            }

            return maxLength;
        }
    }
}