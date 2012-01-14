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
        /// <summary>Used to verify method preconditions and object invariants</summary>
        private readonly Validator _validator = new Validator();
        #region IDoubleBuilder Members

        /// <summary>Creates a moq double (assuming that the type is moq-able)</summary>
        public object CreateMoqDouble(Type typeToMock)
        {
            _validator.VerifyNonNull(typeToMock, "typeToMock");
            return null;
        }

        /// <summary>Dummy builder just returns null for non-moqable objects</summary>
        public object CreateNonMoqDouble(Type typeToMock)
        {
            return null;
        }

        /// <summary>Returns default instance of the value type in question</summary>
        /// <param name="typeToMock">Value type for which to create a double</param>
        public object CreateValueDouble(Type typeToMock)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
