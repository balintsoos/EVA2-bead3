using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Utils
{
    public class ShuffledPositionList : List<int>
    {
        public ShuffledPositionList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Add(i);
            }

            Shuffle();
        }

        public void Shuffle()
        {
            var rnd = new Random();

            for (int i = 0; i < Count; i++)
                Swap(i, rnd.Next(i, Count));
        }

        public void Swap(int a, int b)
        {
            int tmp = this[a];
            this[a] = this[b];
            this[b] = tmp;
        }
    }
}
