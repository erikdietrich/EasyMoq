using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.MoqInheritors
{
    /// <summary>A stub is a minimal implementation, with voids being no-ops, return values being defaults</summary>
    /// <author>Erik Dietrich</author>
    /// <written>12/17/2011</written>
    public class StubMock<T> : Mock<T> where T : class
    {
        /// <summary>Initializes a new instance of the Stub class.</summary>
        public StubMock()
        {
            SetupAllProperties();
        }
    }
}
