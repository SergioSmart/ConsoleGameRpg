using ConsoleGameRpg.Engine.Music;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleGameRpg
{
    public class Program
    {
        //DEVELOP BRANCH
        private const int _screenWidth = 170; //170
        private const int _screenHeight = 47;  //47
        private const int _charInRowEnd = 2;  //47
        private const int _screenLength = (_screenWidth * _screenHeight) + (_screenHeight * 2) - 2;  //8082

        private const int _interfaceWidth = 170; // hz
        private const int _interfaceHeight = 17; // hz

        private static int _playerX = 62;
        private static int _playerY = 6;

        private static string _strScreen = null;


        public static void Main()
        {
            Console.SetWindowSize(_screenWidth, _screenHeight);
            Console.SetBufferSize(_screenWidth, _screenHeight);
            Console.CursorVisible = false;
            
            InitScreen("test2d.txt");  //changed from test2d.txt
            var screen = new char[_screenLength];
            

            while (true)
            {
                DateTime dateTime = DateTime.Now;
                Controls();
                Console.BackgroundColor= ConsoleColor.DarkBlue;
                //Map drawing
                screen = _strScreen.ToCharArray();
                
                for (int x = 0; x < _screenWidth; x++)
                {
                    for (int y = 0; y < _screenHeight; y++)
                    {
                        screen[y * _screenWidth + x] = _strScreen[y * _screenWidth + x];
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                screen[_playerY * (_screenWidth + _charInRowEnd) + _playerX] = '☻';


                //for (int x = 0; x < _mapWidth; x++)
                //{
                //    for (int y = 0; y < _mapHeight; y++)
                //    {
                //        screen[y * ScreenWidth + x] = _map[y * _mapWidth + x];
                //    }
                //}

                // screen[(playerY + 1) * ScreenWidth + playerX] = '☻';

                //for (int i = 0; i < 4500; i++)
                //{
                //    screen[4000 + i] = '☻';
                //}                               
                char[] stats = $"{dateTime}".ToCharArray();
                stats.CopyTo(screen, 5507);

                Console.SetCursorPosition(0, 0);
                Console.Write(screen, 0, _screenLength);

                //5502
                               
            }
            /*
              //Map
                for (int x = 0; x < _mapWidth; x++)
                {
                    for (int y = 0; y < _mapHeight; y++)
                    {
                        screen[(y + 1) * ScreenWidth + x] = _map[y * _mapWidth + x];
                    }
                }

                screen[(int)(_playerY + 1) * ScreenWidth + (int)_playerX] = 'J';

                Console.SetCursorPosition(0, 0);
                Console.Write(screen, 0, ScreenWidth * ScreenHeight);
             


            //char[] charScreen = new char[ScreenWidth * ScreenHeight];            
            //string strScreen = File.ReadAllText("test2d.txt");

            //char[] playerArray = { '☻' };
            //char player = '☻';

            //char[] charInterface = new char[ScreenWidth * InterfaceHeight];
            //string strInterface = File.ReadAllText("testGUI.txt");

            //charScreen = strScreen.ToCharArray();
            //charInterface = strInterface.ToCharArray();
            //int count = 0;
            //while (true)
            //{                
            //    //player.CopyTo(charScreen, count);
            //    Console.SetCursorPosition(0, 0);
            //    charScreen.SetValue(player, count);

            //    Console.Write(charScreen);

            //    Console.SetCursorPosition(4, 33);
            //    Console.Write(count);
            //}         

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
            */
        }

        private static void InitScreen(string path)
        {
            _strScreen = File.ReadAllText(path);
        }


        private static void Controls()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.A:
                        {
                            _playerX -= 1;

                            if(_strScreen[_playerY * (_screenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerX += 1;
                            }
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            _playerX += 1;

                            if (_strScreen[_playerY * (_screenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerX -= 1;
                            }
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            _playerY -= 1;                            

                            if (_strScreen[_playerY * (_screenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerY += 1;
                            }
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            _playerY += 1;

                            if (_strScreen[_playerY * (_screenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerY -= 1;
                            }

                            break;
                        }
                }
            }
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