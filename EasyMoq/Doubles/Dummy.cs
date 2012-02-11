using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>This is a test double that returns a compiler placeholder and nothing more</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/27/2012</written>
    public class Dummy<T> : TestDouble<T>
    {
        /// <summary>This is the actual dummy</summary>
        public override T Object
        {
            get { return default(T); }
        }
    }
}
