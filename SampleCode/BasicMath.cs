using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode
{
    public class BasicMath : IBasicMath
    {

        #region IBasicMath Members

        public virtual int Plus(int x, int y)
        {
            return x + y;
        }

        public virtual int Minus(int x, int y)
        {
            return x - y;
        }

        public virtual int Times(int x, int y)
        {
            return x * y;
        }

        #endregion
    }
}
