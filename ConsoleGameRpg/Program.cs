using ConsoleGameRpg.Engine.Graphic;
using System.Globalization;
using System.Resources;
using ConsoleGameRpg.Engine.Resources.Languages;
using System;
using ConsoleGameRpg.Engine.Music;

namespace ConsoleGameRpg
{
    public class Program
    {
        private static ResourceManager _resManager = new ResourceManager("ConsoleGameRpg.Engine.Resources.Languages.Local", typeof(Program).Assembly);
        private static CultureInfo _cultureInfo = CultureInfo.CreateSpecificCulture("en");
        //private static CultureInfo _cultureInfo = CultureInfo.CurrentCulture;


        private static GUI _intro = new GUI();
        private static GUI _mainMenu = new GUI();

        private static Level level1 = new Level("test2d.txt", 62, 6, ConsoleColor.Black, ConsoleColor.White);
        
        private static sbyte _selectorMainMenu = 0;
        private static sbyte _selectorSettingsMenu = 0;
        private static bool _isMusicEnabled = true;

        private static string _startGameStr;//" ► " + _resManager.GetString("MainMenu_StartGame", _cultureInfo) + " ◄ ";
        private static string _settingsStr;//" ∙ " + _resManager.GetString("MainMenu_Settings", _cultureInfo) + " · ";
        private static string _exitStr;//" ∙ " + _resManager.GetString("MainMenu_Exit", _cultureInfo) + " · ";

        private static string _langRusStr;//" ∙ " + _resManager.GetString("SettingsMenu_UILang_Ru", _cultureInfo) + " · ";
        private static string _langEngStr;//" ∙ " + _resManager.GetString("SettingsMenu_UILang_En", _cultureInfo) + " · ";
        private static string _enabledSoundsStr;//" ∙ " + _resManager.GetString("SettingsMenu_UILang_En", _cultureInfo) + " · ";
        private static string _disabledSoundsStr;//" ∙ " + _resManager.GetString("SettingsMenu_UILang_En", _cultureInfo) + " · ";

        public static void Main()
        {
            InitializeConsole(Level.ScreenWidth, Level.ScreenHeight, false);
            InitializeLocalization();

            DrawIntro(_intro);
            Console.ReadKey();
        
            DrawMainMenu(_mainMenu);

            //DrawLevel(level1);
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

        private static void InitializeConsole(int screenWidth, int ScreenHeight, bool cursorVisible)
        {
            Console.SetWindowSize(screenWidth, ScreenHeight);
            Console.SetBufferSize(screenWidth, ScreenHeight);
            Console.CursorVisible = cursorVisible;
        }

        private static void InitializeLocalization()
        {
             _startGameStr = " ► " + _resManager.GetString("MainMenu_StartGame", _cultureInfo) + " ◄ ";
             _settingsStr = " ∙ " + _resManager.GetString("MainMenu_Settings", _cultureInfo) + " · ";
             _exitStr = " ∙ " + _resManager.GetString("MainMenu_Exit", _cultureInfo) + " · ";
            
             _langRusStr = " ∙ " + _resManager.GetString("SettingsMenu_UILang_Ru", _cultureInfo) + " · ";
             _langEngStr = " ∙ " + _resManager.GetString("SettingsMenu_UILang_En", _cultureInfo) + " · ";
        }

        private static void DrawIntro(GUI graphicInterface)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            graphicInterface.WriteElement("resources/graphicElements/intro/intro.txt", 36, 6, 5, ConsoleColor.White, ConsoleColor.Blue);
            graphicInterface.WriteText(_resManager.GetString("Intro_PressAnyKey", _cultureInfo), GUI.PlaceInCenter(_resManager.GetString("Intro_PressAnyKey", _cultureInfo)), 34, 5, ConsoleColor.Blue, ConsoleColor.White);
        }

        private static void DrawMainMenu(GUI graphicInterface)
        {

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            graphicInterface.WriteText(new string('▄', 170), 0, 0, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            graphicInterface.WriteElement("resources/graphicElements/mainMenu/mainMenuHeader.txt", 0, 1, 0, ConsoleColor.Cyan, ConsoleColor.DarkMagenta);
            graphicInterface.WriteText(new string('▀', 170), 0, 17, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            graphicInterface.WriteText(new string('╦', 170), 0, 18, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteText(new string('╩', 170), 0, 19, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 69, 23, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 69, 35, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            for (int i = 0; i < 11; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 69, 24 + i, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            }
            for (int i = 0; i < 11; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 100, 24 + i, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            }

            graphicInterface.WriteText(_resManager.GetString("MainMenu_Credits", _cultureInfo),
                                        GUI.PlaceInCenter(_resManager.GetString("MainMenu_Credits", _cultureInfo)),
                                        45, 0, ConsoleColor.DarkRed, ConsoleColor.Yellow);

            DrawSelectedMainMenuOption(graphicInterface);

            graphicInterface.WriteText(new string('╦', 170), 0, 39, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteText(new string('╩', 170), 0, 40, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteElement("resources/graphicElements/mainMenu/mainMenuTip.txt",
                                          6, 24, 0, ConsoleColor.DarkGreen, ConsoleColor.White);
            graphicInterface.WriteText(_resManager.GetString("MainMenu_Tip1", _cultureInfo),
                                       21, 24, 1, ConsoleColor.DarkGreen, ConsoleColor.White, 32);
            graphicInterface.WriteText(_resManager.GetString("MainMenu_Tip2", _cultureInfo),
                                        21, 28, 1, ConsoleColor.DarkGreen, ConsoleColor.White);

            MainMenuSelector(graphicInterface);
        }       

        private static void MainMenuSelector(GUI graphicInterface)
        {
            while (true)
            {
                if (_selectorMainMenu == 0)
                {
                    _startGameStr = _startGameStr.Replace('∙', '►').Replace('·', '◄');
                    _settingsStr = _settingsStr.Replace('►', '∙').Replace('◄', '·');
                    _exitStr = _exitStr.Replace('►', '∙').Replace('◄', '·');

                    DrawSelectedMainMenuOption(graphicInterface);
                }
                else if (_selectorMainMenu == 1)
                {
                    _startGameStr = _startGameStr.Replace('►', '∙').Replace('◄', '·');
                    _settingsStr = _settingsStr.Replace('∙', '►').Replace('·', '◄');
                    _exitStr = _exitStr.Replace('►', '∙').Replace('◄', '·');

                    DrawSelectedMainMenuOption(graphicInterface);
                }
                else if (_selectorMainMenu == 2)
                {
                    _startGameStr = _startGameStr.Replace('►', '∙').Replace('◄', '·');
                    _settingsStr = _settingsStr.Replace('►', '∙').Replace('◄', '·');
                    _exitStr = _exitStr.Replace('∙', '►').Replace('·', '◄');

                    DrawSelectedMainMenuOption(graphicInterface);
                }
                else if (_selectorMainMenu > 2)
                {
                    _selectorMainMenu = 0;

                    _startGameStr = _startGameStr.Replace('∙', '►').Replace('·', '◄');
                    _settingsStr = _settingsStr.Replace('►', '∙').Replace('◄', '·');
                    _exitStr = _exitStr.Replace('►', '∙').Replace('◄', '·');

                    DrawSelectedMainMenuOption(graphicInterface);
                }
                else if (_selectorMainMenu < 0)
                {
                    _selectorMainMenu = 2;

                    _startGameStr = _startGameStr.Replace('►', '∙').Replace('◄', '·');
                    _settingsStr = _settingsStr.Replace('►', '∙').Replace('◄', '·');
                    _exitStr = _exitStr.Replace('∙', '►').Replace('·', '◄');

                    DrawSelectedMainMenuOption(graphicInterface);
                }

                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.W:
                        {
                            _selectorMainMenu -= 1;
                            GameMusic.PlayButtonSelected(_isMusicEnabled);
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            _selectorMainMenu += 1;
                            GameMusic.PlayButtonSelected(_isMusicEnabled);
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (_selectorMainMenu == 0)
                            {
                                GameMusic.PlayButtonPressed(_isMusicEnabled);
                                continue;
                            }
                            else if (_selectorMainMenu == 1)
                            {
                                GameMusic.PlayButtonPressed(_isMusicEnabled);
                                DrawSettingsMenu(graphicInterface);
                            }
                            else if (_selectorMainMenu == 2)
                            {
                                GameMusic.PlayButtonPressed(_isMusicEnabled);
                                DrawExitMenu(graphicInterface);
                            }
                            break;
                        }
                }
            }
        }

        private static void DrawExitMenu(GUI graphicInterface)
        {
            Console.Clear();
            graphicInterface.WriteText(new string('╦', 170), 0, 4, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteText(new string('╩', 170), 0, 5, 0, ConsoleColor.DarkYellow, ConsoleColor.White);

            graphicInterface.WriteText("╬" + new string('=', 59) + "╬", 54, 19, 0, ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
            graphicInterface.WriteText("╬" + new string('=', 59) + "╬", 54, 27, 0, ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
            for (int i = 0; i < 7; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 54, 20 + i, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            }
            for (int i = 0; i < 7; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 114, 20 + i, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            }

            graphicInterface.WriteText(new string('╦', 170), 0, 41, 0, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);
            graphicInterface.WriteText(new string('╩', 170), 0, 42, 0, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta);



            graphicInterface.WriteText(_resManager.GetString("MainMenu_ExitQuestion", _cultureInfo),
                                       GUI.PlaceInCenter(_resManager.GetString("MainMenu_ExitQuestion", _cultureInfo)),
                                       23, 1, ConsoleColor.Red, ConsoleColor.White);

            ConsoleKey consoleKey = Console.ReadKey(true).Key;
            switch (consoleKey)
            {
                case ConsoleKey.Escape:
                    {
                        GameMusic.PlayButtonPressed(_isMusicEnabled);
                        DrawMainMenu(_mainMenu);
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        GameMusic.PlayButtonPressed(_isMusicEnabled);
                        Console.SetCursorPosition(0, 43);
                        Environment.Exit(0);
                        break;
                    }
                default:
                    GameMusic.PlayButtonPressed(_isMusicEnabled);
                    DrawExitMenu(graphicInterface); 
                    break;
            }
        }

        private static void DrawSelectedMainMenuOption(GUI graphicInterface)
        {
            graphicInterface.WriteText(_startGameStr, GUI.PlaceInCenter(_startGameStr),
                                       26, 0, ConsoleColor.DarkMagenta, ConsoleColor.White);
            graphicInterface.WriteText(_settingsStr, GUI.PlaceInCenter(_settingsStr),
                                        29, 0, ConsoleColor.DarkGreen, ConsoleColor.White);
            graphicInterface.WriteText(_exitStr, GUI.PlaceInCenter(_exitStr),
                                        32, 0, ConsoleColor.Red, ConsoleColor.White);
        }

        private static void DrawSettingsMenu(GUI graphicInterface)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            graphicInterface.WriteText(new string('▄', 170), 0, 0, 0, ConsoleColor.Magenta, ConsoleColor.DarkBlue);
            graphicInterface.WriteElement("resources/graphicElements/settingsMenu/settingsHeaderEng.txt", 0, 1, 0, ConsoleColor.Cyan, ConsoleColor.Magenta);
            graphicInterface.WriteText(new string('▀', 170), 0, 16, 0, ConsoleColor.Magenta, ConsoleColor.DarkBlue);
            graphicInterface.WriteText(new string('╦', 170), 0, 17, 0, ConsoleColor.DarkYellow, ConsoleColor.White);
            graphicInterface.WriteText(new string('╩', 170), 0, 18, 0, ConsoleColor.DarkYellow, ConsoleColor.White);

            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 55, 23, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 55, 35, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            for (int i = 0; i < 11; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 55, 24 + i, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            }
            for (int i = 0; i < 11; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 86, 24 + i, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            }

            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 86, 23, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            graphicInterface.WriteText("╬" + new string('=', 30) + "╬", 86, 35, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            for (int i = 0; i < 11; i++)
            {
                graphicInterface.WriteText(new string('I', 1), 117, 24 + i, 0, ConsoleColor.Magenta, ConsoleColor.Yellow);
            }
            SettingsMenuSelector(graphicInterface);
        }

        private static void DrawSelectedSettingsMenuOption(GUI graphicInterface)
        {
            graphicInterface.WriteText(_resManager.GetString("SettingsMenu_UILang", _cultureInfo), GUI.PlaceInCenter(_resManager.GetString("SettingsMenu_UILang", _cultureInfo)) - 14,
                                       26, 0, ConsoleColor.DarkRed, ConsoleColor.White);
            graphicInterface.WriteText(_langRusStr, GUI.PlaceInCenter(_langRusStr) - 14,
                                        29, 0, ConsoleColor.Yellow, ConsoleColor.Magenta);
            graphicInterface.WriteText(_langEngStr, GUI.PlaceInCenter(_langEngStr) - 14,
                                        32, 0, ConsoleColor.DarkCyan, ConsoleColor.White);
        }

        private static void SettingsMenuSelector(GUI graphicInterface)
        {
            while (true)
            {
                if (_selectorSettingsMenu == 0)
                {
                    _langRusStr = _langRusStr.Replace('∙', '►').Replace('·', '◄');                
                    _langEngStr = _langEngStr.Replace('►', '∙').Replace('◄', '·');

                    DrawSelectedSettingsMenuOption(graphicInterface);
                }
                else if (_selectorSettingsMenu == 1)
                {
                    _langRusStr = _langRusStr.Replace('►', '∙').Replace('◄', '·');
                    _langEngStr = _langEngStr.Replace('∙', '►').Replace('·', '◄');

                    DrawSelectedSettingsMenuOption(graphicInterface);
                }                
                else if (_selectorSettingsMenu > 1)
                {
                    _selectorSettingsMenu = 0;

                    _langRusStr = _langRusStr.Replace('∙', '►').Replace('·', '◄');
                    _langEngStr = _langEngStr.Replace('►', '∙').Replace('◄', '·');

                    DrawSelectedSettingsMenuOption(graphicInterface);
                }
                else if (_selectorSettingsMenu < 0)
                {
                    _selectorSettingsMenu = 1;

                    _langRusStr = _langRusStr.Replace('►', '∙').Replace('◄', '·');
                    _langEngStr = _langEngStr.Replace('∙', '►').Replace('·', '◄');

                    DrawSelectedSettingsMenuOption(graphicInterface);
                }

                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.W:
                        {
                            _selectorSettingsMenu -= 1;
                            GameMusic.PlayButtonSelected(_isMusicEnabled);
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            _selectorSettingsMenu += 1;
                            GameMusic.PlayButtonSelected(_isMusicEnabled);
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (_selectorSettingsMenu == 0)
                            {
                                GameMusic.PlayButtonPressed(_isMusicEnabled);
                                _cultureInfo = CultureInfo.CreateSpecificCulture("ru");
                                InitializeLocalization();
                                DrawSettingsMenu(graphicInterface);
                            }
                            else if (_selectorSettingsMenu == 1)
                            {
                                GameMusic.PlayButtonPressed(_isMusicEnabled);
                                _cultureInfo = CultureInfo.CreateSpecificCulture("en");
                                InitializeLocalization();
                                DrawSettingsMenu(graphicInterface);
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            GameMusic.PlayButtonPressed(_isMusicEnabled);
                            DrawMainMenu(_mainMenu);
                        }
                        break;
                }
            }
        }

        private static void DrawLevel(Level level)
        {
            level.InitializeScreen();

            while (true)
            {
                level.ControlBehavior();
                level.ConstructScreen();
                level.DrawPlayer();
                level.DrawScreen();
            }
        }

        /*private static void HandleInput(ConsoleKeyInfo pressedKey, ref int playerPositionX, ref int playerPositionY, char[,] map)
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
        }*/
    }
}