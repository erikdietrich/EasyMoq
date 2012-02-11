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
using Moq.Language.Flow;

namespace DaedTech.EasyMoqTest.Doubles
{
    [TestClass]
    public class StubTest
    {
        [TestClass]
        public class Constructor
        {
            /// <summary>We should do this when the class is moqable</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_On_Wrong_Number_Of_Parameters_When_TestClass_Is_Moqable()
            {
                ExtendedAssert.Throws<ArgumentException>(() => new Stub<StubTest>("asdf", "fdsa"));
            }

            /// <summary>If this is true on a value type, we should throw as well</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_On_Wrong_Number_Of_Parameters_For_Value_Type()
            {
                ExtendedAssert.Throws<ArgumentException>(() => new Stub<int>("asdf"));
            }

            /// <summary>Should be true for strings just like anything else</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_On_Wrong_Number_Of_Paramters_For_string()
            {
                ExtendedAssert.Throws<ArgumentException>(() => new Stub<string>(12));
            }
        }

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

            public sealed class NonMoqable { }

            /// <summary>For now, we're going to return null in this situation</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_ConcreteInstance_Non_Moqable_Reference_Type()
            {
                Assert.IsInstanceOfType(new Stub<NonMoqable>().Object, typeof(NonMoqable));
            }

            /// <summary>We should be able to handle stubbed strings as if they were value types</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_EmptyString_For_String_Type()
            {
                Assert.AreEqual<string>(string.Empty, new Stub<string>().Object);
            }

            public class HasParameters { public HasParameters(int x, string y, bool z) { } }

            /// <summary>The constructor parameters should be passed on to the mock</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Instance_Of_Class_For_Type_With_Constructor_Parameters()
            {
                Assert.IsInstanceOfType(new Stub<HasParameters>(1, "asfd", true).Object, typeof(HasParameters));
            }

            public struct SomeStruct { public int x; public bool y; }

            /// <summary>This should be true for a struct</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Is_Instance_Of_Struct_For_Value_Type()
            {
                Assert.IsInstanceOfType(new Stub<SomeStruct>().Object, typeof(SomeStruct));
            }
        }

        [TestClass]
        public class SetReturnsDefault
        {
            /// <summary>If the stub is moqable, we'll just use moq's implementation</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Causes_Methods_With_Matching_Type_To_Return_That_Default_When_Stub_IS_Moqable()
            {
                var myStub = new Stub<IComparable>();
                myStub.SetReturnsDefault<int>(12);

                Assert.AreEqual<int>(12, myStub.Object.CompareTo(null));
            }

            /// <summary>This is an optimistic operation, so if we have no internal moq, we should just do nothing
            /// (arguably, we're attempting to set a default, and the concrete instance is just going to override the default
            /// in all cases)</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_Exception_On_Value_Type()
            {
                var myStub = new Stub<int>();

                ExtendedAssert.DoesNotThrow(() => myStub.SetReturnsDefault<string>("asdf"));
            }
        }

        [TestClass]
        public class SetupGet
        {
            /// <summary>If the class is moqable, this should do what it's asked to do</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Results_In_Expected_Setup_When_Type_Is_Moqable()
            {
                var myStub = new Stub<IList<string>>();
                myStub.SetupGet<IList<string>, int>(list => list.Count).Returns(12);

                Assert.AreEqual<int>(12, myStub.Object.Count);
            }
        }

    }
}
