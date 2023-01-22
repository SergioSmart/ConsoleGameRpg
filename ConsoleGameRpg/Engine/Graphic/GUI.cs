namespace ConsoleGameRpg.Engine.Graphic
{
    public class GUI
    {
        //private string _pathToFile;
        //private char[,] _graphicElement;

        public GUI() { }

        //public GraphicElement(string pathToFile)
        //{
        //    _pathToFile = pathToFile;
        //}    

        //public char[,] ReadFile(string pathToFile)
        //{
        //    string[] file = File.ReadAllLines(pathToFile);

        //    char [,] graphicElement = new char[GetMaxLengthOfLine(file), file.Length];

        //    for (int x = 0; x < graphicElement.GetLength(0); x++)
        //        for (int y = 0; y < graphicElement.GetLength(1); y++)
        //            graphicElement[x, y] = file[y][x];       
            
        //    return graphicElement;
        //}

        //public void ReadFile()
        //{
        //    string[] file = File.ReadAllLines(_pathToFile);

        //    _graphicElement = new char[GetMaxLengthOfLine(file), file.Length];

        //    for (int x = 0; x < _graphicElement.GetLength(0); x++)
        //        for (int y = 0; y < _graphicElement.GetLength(1); y++)
        //            _graphicElement[x, y] = file[y][x];
        //}

        public void WriteElement(string pathToFile, int cursorPosLeft, 
                                 int cursorPosTop, int delay, 
                                 ConsoleColor backgroundColor, 
                                 ConsoleColor foregroundColor) 
        {
            string[] file = File.ReadAllLines(pathToFile);

            char[,] graphicElement = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < graphicElement.GetLength(0); x++)
                for (int y = 0; y < graphicElement.GetLength(1); y++)
                    graphicElement[x, y] = file[y][x];

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            for (int y = 0; y < graphicElement.GetLength(1); y++)
            {
                for (int x = 0; x < graphicElement.GetLength(0); x++)
                {
                    Console.SetCursorPosition(cursorPosLeft + x, cursorPosTop + y);                   
                    Console.Write(graphicElement[x, y]);
                }
                Console.Write("\n");
                Thread.Sleep(delay);
            }    
        }

        public static int PlaceInCenter(string gameString)
        {
            return (Level.ScreenWidth - gameString.Length) / 2;
        }

        //public void WriteElement(int cursorPosLeft, int cursorPosTop, int delay, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        //{
        //    Console.BackgroundColor = backgroundColor;
        //    Console.ForegroundColor = foregroundColor;
        //    Console.Clear();
        //    for (int y = 0; y < _graphicElement.GetLength(1); y++)
        //    {
        //        for (int x = 0; x < _graphicElement.GetLength(0); x++)
        //        {
        //            Console.SetCursorPosition(cursorPosLeft + x, cursorPosTop + y);
        //            Console.Write(_graphicElement[x, y]);
        //        }
        //        Console.Write("\n");
        //        Thread.Sleep(delay);
        //    }
        //}

        public void WriteText(string text, int cursorPosLeft, 
                              int cursorPosTop, int delay,  
                              ConsoleColor backgroundColor, 
                              ConsoleColor foregroundColor, 
                              int lengthOfRow = int.MaxValue)
        {
            int amountOfEnters = 1;
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);

            if(text.Length > lengthOfRow)
            {
                text = text.Insert(lengthOfRow, "\0");
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\0')
                {
                    Console.SetCursorPosition(cursorPosLeft, cursorPosTop + amountOfEnters);
                    amountOfEnters++;
                }
                Console.Write(text[i]);
                Thread.Sleep(delay);
            }

            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (text[i] == ' ') //ALT+255 non-breaking space
            //    {
            //        Console.SetCursorPosition(cursorPosLeft, cursorPosTop + amountOfEnter);
            //        amountOfEnter++;
            //    }
            //    Console.Write(text[i]);
            //    Thread.Sleep(delay);
            //}
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
