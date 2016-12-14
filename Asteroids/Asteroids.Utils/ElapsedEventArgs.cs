using System;

namespace Asteroids.Utils
{
    /// <summary>
    /// Időmúlás eseményargumentum típusa.
    /// </summary>
    public class ElapsedEventArgs
    {
        /// <summary>
        /// Esemény bekövetkezési időpontjának lekérdezése.
        /// </summary>
        public DateTime SignalTime { get; private set; }

        /// <summary>
        /// Időmúlás eseményargumentum példányosítása.
        /// </summary>
        public ElapsedEventArgs() { SignalTime = DateTime.Now; }
    }

    /// <summary>
    /// Időmúlás eseménykezelő típusa.
    /// </summary>
    public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
}
