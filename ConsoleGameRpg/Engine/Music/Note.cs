namespace ConsoleGameRpg.Engine.Music
{
    public class Note
    {
        public string Name { get; set; }

        public int Frequency { get; set; }
        public int Duration { get; set; }

        public Note(string name, int frequency, int duration)
        {
            Name = name;
            Frequency = frequency;
            Duration = duration;
        }





    }
}
