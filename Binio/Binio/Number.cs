using System;
using System.Collections.Generic;
using System.Text;

namespace Binio
{
    class Number
    {
        int id;
        int numData;
        bool pulled;

        public Number()
        {
            numData = 0;
            pulled = false;
        }

        public Number(int numData, bool pulled)
        {
            this.numData = numData;
            this.pulled = pulled;
        }
        public int NumData { get { return numData; } set { numData = value; } }
        public bool Pulled { get { return pulled; } set { pulled = value; } }
    }
}
