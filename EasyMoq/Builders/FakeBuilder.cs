using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This class will build fake doubles</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/13/2012</written>
    public class FakeBuilder : IDoubleBuilder
    {
        #region IDoubleBuilder Members

        /// <summary>Creates a moq double (assuming that the type is moq-able)</summary>
        public object CreateMoqDouble(Type typeToMock)
        {
            if (typeToMock == null)
            {
                throw new ArgumentNullException("typeToMock");
            }

            Type[] myTypeArgs = new Type[] { typeToMock };
            return Activator.CreateInstance(typeof(Mock<>).MakeGenericType(myTypeArgs)) as Mock;
        }

        public object CreateNonMoqDouble(Type typeToMock)
        {
            throw new NotImplementedException();
        }

        public object CreateValueDouble(Type typeToMock)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
