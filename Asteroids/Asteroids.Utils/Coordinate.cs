using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Utils
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        public Coordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public Coordinate(Coordinate c)
        {
            this._x = c.X;
            this._y = c.Y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Coordinate c = obj as Coordinate;

            if ((System.Object)c == null)
            {
                return false;
            }

            return (c.X == this._x) && (c.Y == this._y);
        }

        public override int GetHashCode()
        {
            return _x * 15 + _y * 69;
        }
    }
}
