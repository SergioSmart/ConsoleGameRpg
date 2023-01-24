namespace ConsoleGameRpg.Engine.Music
{
    /// <summary>
    /// Represents music notes' duration
    /// Default whole note is 666 ms (Prestissimo - 360 BPM)
    /// </summary>
    enum Duration
    {
        /// <summary>
        /// Pause
        /// </summary>
        Pause = 0,
        /// <summary>
        /// 1/1
        /// </summary>
        Whole = 666,
        /// <summary>
        /// 1/2
        /// </summary>
        Half = 333,
        /// <summary>
        /// 1/4
        /// </summary>
        Quarter = 166,
        /// <summary>
        /// 1/8
        /// </summary>
        Eighth = 83,
        /// <summary>
        /// 1/16
        /// </summary>
        Sixteenth = 41,
        /// <summary>
        /// 1/32
        /// </summary>
        ThirtySecond = 14 
    }
}
