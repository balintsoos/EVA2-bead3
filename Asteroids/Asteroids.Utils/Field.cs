using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Utils
{
    public class Field
    {
        private Coordinate _coords;
        private FieldType _type;

        public Field(int x, int y, FieldType type)
        {
            this._coords = new Coordinate(x, y);
            this._type = type;
        }

        public Coordinate Coords
        {
            get { return _coords; }
        }

        public int X
        {
            get { return _coords.X; }
        }

        public int Y
        {
            get { return _coords.Y; }
        }

        public FieldType Type
        {
            get { return _type; }
        }
    }
}
