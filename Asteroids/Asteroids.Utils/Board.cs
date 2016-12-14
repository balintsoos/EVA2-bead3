using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Utils
{
    public class Board
    {
        private int _width;
        private int _height;

        public Board(int w, int h)
        {
            this._width = w;
            this._height = h;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }
    }
}
