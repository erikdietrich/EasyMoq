using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.MoqInheritors
{
    /// <summary>A spy sets up all methods, properties, etc, so that it can be queried about invocations</summary>
    /// <author>Erik Dietrich</author>
    /// <written>12/17/2011</written>
    public class SpyMock<T> : Mock<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the Spy class.
        /// </summary>
        public SpyMock()
        {
            SetupAllProperties();
        }
    }
}
