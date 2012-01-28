using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Builders;
using Moq;

namespace DaedTech.EasyMoqTest.Builders
{
    [TestClass]
    public class DummyBuilderTest
    {
        [TestClass]
        public class CreateDouble
        {
            /// <summary>For example... (part of my TDD)</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Default_Int_For_Int()
            {
                var myBuilder = new DummyBuilder();

                Assert.AreEqual<int>(default(int), (int)myBuilder.CreateDouble(typeof(int)));
            }

            /// <summary>For reference types, this is the default and thus what we should get</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Null_For_String()
            {
                var myBuilder = new DummyBuilder();

                Assert.IsNull(myBuilder.CreateDouble(typeof(string)));
            }

            /// <summary>This should return null for something that moq supports</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Null_For_Interface()
            {
                var myBuilder = new DummyBuilder();

                Assert.IsNull(myBuilder.CreateDouble(typeof(IComparable)));
            }
        }
    }
}
