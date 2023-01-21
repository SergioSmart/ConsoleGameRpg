namespace ConsoleGameRpg.Engine.Graphic
{
    public class GraphicInterface
    {
        //private string _pathToFile;
        //private char[,] _graphicElement;

        public GraphicInterface() { }

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
            Console.Clear();
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
                              ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            for (int i = 0; i < text.Length; i++)
            {            
                Console.Write(text[i]);
                Thread.Sleep(delay);
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
