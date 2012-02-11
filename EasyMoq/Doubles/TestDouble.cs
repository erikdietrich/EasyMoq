using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>This is the base class for all test doubles</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/27/2012</written>
    public abstract class TestDouble<T>
    {
        public abstract T Object { get; }
    }
}
