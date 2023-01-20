using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine.Graphic
{
    public class GUI
    {
        private const int _charInRowEnd = 2;      
        
        public static int ScreenWidth { get; } = 170; //170
        public static int ScreenHeight { get; } = 47;  //47
        public static int ScreenLength { get; } = (ScreenWidth * ScreenHeight) + (ScreenHeight * _charInRowEnd) - _charInRowEnd;  //8082

        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public GUI(int playerX, int playerY)
        {
            PlayerX = playerX;
            PlayerY = playerY;
        }

        public string InitializeScreen(string path)
        {
            return File.ReadAllText(path);
        }

        public void ConstructScreen(char[] screen, string strScreen)
        {
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    screen[y * (ScreenWidth + _charInRowEnd) + x] = strScreen[y * (ScreenWidth + _charInRowEnd) + x];
                }
            }
        }

        public void DrawScreen(char[] screen, int index, int count)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(screen, index, count);
        }
        
        public void DrawPlayer(char[] screen, char player = '☻')
        {
            screen[PlayerY * (ScreenWidth + _charInRowEnd) + PlayerX] = player;
        }

        public void ControlBehavior(string strScreen)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.A:
                        {
                            PlayerX -= 1;

                            if (strScreen[PlayerY * (ScreenWidth + _charInRowEnd) + PlayerX] == '█')
                            {
                                PlayerX += 1;
                            }
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            PlayerX += 1;

                            if (strScreen[PlayerY * (ScreenWidth + _charInRowEnd) + PlayerX] == '█')
                            {
                                PlayerX -= 1;
                            }
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            PlayerY -= 1;

                            if (strScreen[PlayerY * (ScreenWidth + _charInRowEnd) + PlayerX] == '█')
                            {
                                PlayerY += 1;
                            }
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            PlayerY += 1;

                            if (strScreen[PlayerY * (ScreenWidth + _charInRowEnd) + PlayerX] == '█')
                            {
                                PlayerY -= 1;
                            }

                            break;
                        }
                }
            }
        }
    }
}
