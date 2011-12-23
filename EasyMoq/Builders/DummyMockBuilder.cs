using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>Builds dummies</summary>
    public class DummyMockBuilder : IMockBuilder
    {

        #region IMockBuilder Members

        public Mock BuildMock(Type typeToMock)
        {
            if (typeToMock == null)
            {
                throw new ArgumentNullException("typeToMock");
            }

            Type[] myTypeArgs = new Type[] { typeToMock };
            return Activator.CreateInstance(typeof(Mock<>).MakeGenericType(myTypeArgs)) as Mock;
        }

        #endregion
    }
}
