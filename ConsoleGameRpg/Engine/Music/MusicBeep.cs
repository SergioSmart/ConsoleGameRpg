using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameRpg.Engine.Music
{
    public class MusicBeep
    {
        private static int _frequency = 100;
        private static int _duration = 300;
        private static byte _length = 0;
        private static byte _step = 0;
        private static byte _cycle = 0;

        public static void PlayTrack1(bool isActive)
        {
            while (isActive)
            {
                if (_cycle >= 0 && _cycle < 4)
                {
                    while (_length < 4)
                    {
                        Console.Beep(_frequency + _step, _duration);
                        _step += 17;
                        _length++;
                    }
                    while (_length > 0)
                    {
                        Console.Beep(_frequency + _step, _duration);
                        _step -= 17;
                        _length--;
                    }
                    _cycle++;
                }

                if (_cycle >= 4 && _cycle < 6)
                {
                    while (_length < 4)
                    {
                        Console.Beep(_frequency + 90 + _step, _duration);
                        _step += 17;
                        _length++;
                    }
                    while (_length > 0)
                    {
                        Console.Beep(_frequency + 90 + _step, _duration);
                        _step -= 17;
                        _length--;
                    }
                    _cycle++;
                }

                if (_cycle >= 6)
                {
                    _cycle = 0;
                }
            }
        }
    }
}
