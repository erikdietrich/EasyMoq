using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode
{
    public class BasicMathInheritor : BasicMath
    {
        public override int Minus(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override int Plus(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override int Times(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
