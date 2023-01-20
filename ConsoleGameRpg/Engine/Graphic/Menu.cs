namespace ConsoleGameRpg.Engine.Graphic
{
    public class Menu
    {
        private string[] _strFile;
        private string _pathToFile;

        public Menu() { }

        public void ReadFile()
        {
            _strFile = File.ReadAllLines(_pathToFile);            
        }

        public void WriteFile(string[] file) 
        {

        }

    }
}
