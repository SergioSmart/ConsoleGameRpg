namespace ConsoleGameRpg.Engine.Graphic
{
    public class Level
    {
        private const byte _charInRowEnd = 2;
        
        private char[] _screen = new char[ScreenLength];
        private string _pathToMapFile;
        private string _map { get; set; }
        private int _playerX;
        private int _playerY;
        private ConsoleColor _backgroundColor;
        private ConsoleColor _foregroundColor;

        public static byte ScreenWidth { get; } = 170; //170
        public static byte ScreenHeight { get; } = 47;  //47
        public static int ScreenLength { get; } = (ScreenWidth * ScreenHeight) + (ScreenHeight * _charInRowEnd) - _charInRowEnd;  //8082

        public Level(string pathToMapFile,
                   int startPlayerPosX,                   
                   int startPlayerPosY, 
                   ConsoleColor backgroundColor, 
                   ConsoleColor foregroundColor)
        {
            _pathToMapFile = pathToMapFile;
            _playerX = startPlayerPosX;
            _playerY = startPlayerPosY;
            _backgroundColor = backgroundColor;
            _foregroundColor = foregroundColor;
        }

        public void InitializeScreen()
        {
            _map = File.ReadAllText(_pathToMapFile);
        }

        public void ConstructScreen()
        {
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    _screen[y * (ScreenWidth + _charInRowEnd) + x] = _map[y * (ScreenWidth + _charInRowEnd) + x];
                }
            }
        }

        public void DrawScreen()
        {
            Console.BackgroundColor = _backgroundColor;
            Console.ForegroundColor = _foregroundColor;
            Console.SetCursorPosition(0, 0);
            Console.Write(_screen, 0, ScreenLength);
        }
        
        public void DrawPlayer(char player = '☻')
        {           
            _screen[_playerY * (ScreenWidth + _charInRowEnd) + _playerX] = player;
        }

        public void ControlBehavior()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.A:
                        {
                            _playerX -= 1;

                            if (_map[_playerY * (ScreenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerX += 1;
                            }
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            _playerX += 1;

                            if (_map[_playerY * (ScreenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerX -= 1;
                            }
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            _playerY -= 1;

                            if (_map[_playerY * (ScreenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerY += 1;
                            }
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            _playerY += 1;

                            if (_map[_playerY * (ScreenWidth + _charInRowEnd) + _playerX] == '█')
                            {
                                _playerY -= 1;
                            }

                            break;
                        }
                }
            }
        }
    }
}
