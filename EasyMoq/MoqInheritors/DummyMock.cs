using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.MoqInheritors
{
    /// <summary>A dummy is simply an empty mock with no implementation at all</summary>
    /// <author>Erik Dietrich</author>
    /// <written>12/17/2011</written>
    public class DummyMock<T> : Mock<T> where T : class
    {
        /// <summary>CallBase is always false in a dummy</summary>
        public override bool CallBase
        {
            get { return false; }
            set { /* Deliberate no-op */ }
        }

        /// <summary>Initializes a new instance of the Dummy class.</summary>
        public DummyMock() : base(MockBehavior.Strict)
        {
            CallBase = false;
        }

        
    }
}
