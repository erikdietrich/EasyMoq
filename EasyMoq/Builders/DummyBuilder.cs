using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using DaedTech.EasyMoq.Common;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>Builds dummies</summary>
    public class DummyBuilder : IDoubleBuilder
    {
        #region IDoubleBuilder Members

        /// <summary>Create a dummy of the given type</summary>
        /// <param name="typeToDouble">Type to dummy</param>
        /// <returns>The type in question as an object</returns>
        public object CreateDouble(Type typeToDouble)
        {
            if(typeToDouble.IsValueType)
                return Activator.CreateInstance(typeToDouble);

            return null;
        }

        #endregion
    }
}
