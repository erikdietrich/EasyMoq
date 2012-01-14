using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Builders;
using SampleCode;
using Moq;

namespace SampleCodeTest.Builders
{
    [TestClass]
    public class DummyBuilderTest
    {
        #region CreateMoqDouble

        /// <summary>This shouldn't be allowed - it makes no sense</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void CreateMoqDouble_Throws_Exception_On_Null_Argument()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new DummyBuilder().CreateMoqDouble(null));
        }

        /// <summary>Happy path should return the mock we want</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void CreateMoqDouble_Returns_Null()
        {
            Assert.IsNull(new DummyBuilder().CreateMoqDouble(typeof(IBasicMath)));
        }

        #endregion

        /// <summary>This </summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void CreateNonMoqDouble_Returns_Null_For_UnMoqable_Class()
        {
            Assert.IsNull(new DummyBuilder().CreateNonMoqDouble(typeof(string)));
        }
    }
}
