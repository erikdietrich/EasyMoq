using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCode;
using Moq;
using DaedTech.EasyMoq.Doubles;
using System.Dynamic;
using System.Reflection.Emit;

namespace DaedTech.EasyMoqTest.Doubles
{
    [TestClass]
    public class StubTest
    {
        [TestClass]
        public class Object
        {
            /// <summary>For value types, just pass the default</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_DefaultInt_For_Int_Generic()
            {
                Assert.AreEqual<int>(default(int), (int)new Stub<int>().Object);
            }

            /// <summary>If given a moq-able interface, we should return an implementation of the interface</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_InstanceOfInterface_For_InterfaceArgument()
            {
                Assert.IsInstanceOfType(new Stub<IComparable>().Object, typeof(IComparable));
            }

            /// <summary>If this can be moq-ed, we want it to be, even for class instead of an interface</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Instance_Of_Base_Class_For_Moqable_Type()
            {
                Assert.IsInstanceOfType(new Stub<StubTest>().Object, typeof(StubTest));
            }

            /// <summary>For now, we're going to return null in this situation</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Null_For_Non_Moqable_Reference_Type()
            {
                Assert.IsNull(new Stub<string>().Object);
            }
        }
    }
}
