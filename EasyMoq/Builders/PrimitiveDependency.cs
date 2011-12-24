using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary></summary>
    internal class PrimitiveDependency : IDependency
    {

        #region IDependency Members

        private readonly Type _typeToMock;

        /// <summary>Type that will be mocked by this object</summary>
        public Type TypeToMock { get { return _typeToMock; } set { throw new NotImplementedException(); } }


        private IMockBuilder _builder = new DummyMockBuilder();

        /// <summary>The builder to use for constructing mocks of this dependency</summary>
        public IMockBuilder Builder { get { return _builder; } set { _builder = value ?? new DummyMockBuilder(); } }

        public object EmitTestDouble()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
