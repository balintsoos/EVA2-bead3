using System;
using System.Collections.Generic;

namespace Asteroids.Utils
{
    public class FieldsChangedEventArgs : EventArgs
    {
        public Coordinate Player { get; private set; }

        public List<Coordinate> Asteroids { get; private set; }

        public FieldsChangedEventArgs(Coordinate player, List<Coordinate> asteroids)
        {
            Player = player;
            Asteroids = asteroids;
        }
    }
}
