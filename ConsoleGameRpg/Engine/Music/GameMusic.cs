namespace ConsoleGameRpg.Engine.Music
{
    public class GameMusic
    {
        private static int _tempo = (int)Tempo.Allegro;

        public static void PlayTrack1()
        {
            int frequency = 100;
            int duration = 300;
            byte length = 0;
            byte step = 0;
            byte cycle = 0;

            while (true)
            {
                if (cycle >= 0 && cycle < 4)
                {
                    while (length < 4)
                    {
                        Console.Beep(frequency + step, duration);
                        step += 17;
                        length++;
                    }
                    while (length > 0)
                    {
                        Console.Beep(frequency + step, duration);
                        step -= 17;
                        length--;
                    }
                    cycle++;
                }

                if (cycle >= 4 && cycle < 6)
                {
                    while (length < 4)
                    {
                        Console.Beep(frequency + 90 + step, duration);
                        step += 17;
                        length++;
                    }
                    while (length > 0)
                    {
                        Console.Beep(frequency + 90 + step, duration);
                        step -= 17;
                        length--;
                    }
                    cycle++;
                }

                if (cycle >= 6)
                {
                    cycle = 0;
                }
            }
        }

        public static void PlayIntro()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Beep(400 + i * 40, 100);
            }
            Console.Beep(480, 100);
            Console.Beep(620, 500);
        }

        public static void PlayButtonSelected()
        {
            //Console.Beep(550, 100);
            //Console.Beep(650, 100);
            
        }

        public static void PlayButtonPressed()
        {
            Console.Beep(280, 100);
        }

        public static void PlayHeartPickedUp()
        {
            for (int i = 0; i < 12; i++)
            {
                Console.Beep(300 + i * 900, 40);
            }
        }
    }
}
