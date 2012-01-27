using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This class is used to </summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/26/2012</written>
    public class MoqabilityEvaluator
    {
        /// <summary>Determines whether moq will support the passed in type</summary>
        /// <param name="typeToEvaluate">Type to check for "moqability"</param>
        /// <returns>True if moq will work on it, false otherwise</returns>
        public bool IsMoqable(Type typeToEvaluate)
        {
            return typeToEvaluate != null &&
                (typeToEvaluate.IsInterface || typeToEvaluate.GetConstructor(new Type[] { }) != null);
        }

    }
}
