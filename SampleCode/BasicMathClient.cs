using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode
{
    public class BasicMathClient
    {
        private readonly IBasicMath _mathPerformer;

        #region Constructor
        /// <summary>a new instance of the BasicMathClient class.</summary>
        /// <param name="mathPerformer"></param>
        public BasicMathClient(IBasicMath mathPerformer)
        {
            _mathPerformer = mathPerformer;
        }

        #endregion

        public int AddTwoPlusTwo()
        {
            return _mathPerformer.Plus(2, 2);
        }
    }
}
