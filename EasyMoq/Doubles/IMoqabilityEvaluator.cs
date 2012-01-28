using System;
using System.Collections.Generic;
using System.Linq;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>This is the interface that is used for moqability evaluation</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/27/2012</written>
    public interface IMoqabilityEvaluator
    {
        /// <summary>Determines whether moq will support the passed in type</summary>
        /// <param name="typeToEvaluate">Type to check for "moqability"</param>
        /// <returns>True if moq will work on it, false otherwise</returns>
        bool IsMoqable<T>();
    }
}
