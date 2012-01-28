using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Doubles;

namespace DaedTech.EasyMoqTest.Doubles
{
    [TestClass]
    public class DummyTest
    {
        [TestClass]
        public class Object
        {
            /// <summary>If we're mocking a value type, we should return its default</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Equals_Zero_When_Generic_Parameter_Is_Int()
            {
                Assert.AreEqual<int>(default(int), (int)new Dummy<int>().Object);
            }

            /// <summary>For reference type dummies, the object is null</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Null_When_Generic_Parameter_Is_String()
            {
                Assert.IsNull(new Dummy<string>().Object);
            }

            /// <summary>Same concpet as a value type</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Null_When_Generic_Parameter_Is_Interface()
            {
                Assert.IsNull(new Dummy<IComparable>().Object);
            }
        }
    }
}
