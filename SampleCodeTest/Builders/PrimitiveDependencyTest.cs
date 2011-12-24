using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Builders;

namespace SampleCodeTest.Builders
{
    [TestClass]
    public class PrimitiveDependencyTest
    {
        #region Builder

        /// <summary>It's not really possible to build a primitive dependency with anything else using Moq</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Builder_Defaults_To_Dummy_Builder()
        {
            Assert.IsInstanceOfType(new PrimitiveDependency().Builder, typeof(DummyMockBuilder));
        }

        /// <summary>This is an invariant of the class that will be enforced by not allowing it</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Builder_Cannot_Be_Set_To_Null()
        {
            var myDependency = new PrimitiveDependency() { Builder = null };

            Assert.IsNotNull(myDependency.Builder);
        }

        #endregion

        /// <summary>Type of this dependency can be changed on the fly, and we're not going to suggest it at startup</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void TypeToMock_Defaults_To_Null()
        {
            var myDependency = new PrimitiveDependency();

            Assert.IsNull(myDependency.TypeToMock);
        }
    }
}
