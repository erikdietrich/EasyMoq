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
    public class ConstructorDependencyBuilderTest
    {
        /// <summary>Builds the target we want built</summary>
        /// <param name="type"></param>
        /// <param name="builder"></param>
        private static ConstructorDependencyBuilder BuildTarget(Type type, IDoubleBuilder builder = null)
        {
            var myBuilder = builder ?? new Mock<IDoubleBuilder>().Object;
            return new ConstructorDependencyBuilder(type.GetConstructors(), myBuilder);
        }

        [TestClass]
        public class Constructor
        {
            /// <summary>This class cannot operate without a constructor info - if you're passing null, something is wrong</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_ArgumentNullException_On_Null_Argument()
            {
                ExtendedAssert.Throws<ArgumentNullException>(() => new ConstructorDependencyBuilder(null));
            }
        }

        [TestClass]
        public class GetDependencyDoubles
        {
            /// <summary>Define a class with one constructor parameter</summary>
            private class SingleIntConstructor { public SingleIntConstructor(int x) { } }

            /// <summary>If nothing is injected, nothing should be returned </summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Empty_Array_For_Constructor_With_No_Parameters()
            {
                var myBuilder = BuildTarget(typeof(ConstructorDependencyBuilderTest)); //What?  It has zero parameters... :P

                Assert.AreEqual<int>(0, myBuilder.GetDependencyDoubles().Count());
            }

            /// <summary>If the constructor has a single parameter, we should get one </summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_One_Element_Array_For_Constructor_With_One_Parameter()
            {
                var myBuilder = BuildTarget(typeof(SingleIntConstructor));

                Assert.AreEqual<int>(1, myBuilder.GetDependencyDoubles().Count());
            }

            /// <summary>It's not enough that it exist - it should be valid</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Passes_Int_To_Builder_For_SingleIntConstructor()
            {
                var myStub = new Mock<IDoubleBuilder>();
                var myBuilder = BuildTarget(typeof(SingleIntConstructor), myStub.Object);
                myBuilder.GetDependencyDoubles();

                myStub.Verify(builder => builder.CreateDouble(typeof(int)), Times.Once());
            }

            private class DoubleIntConstructor { public DoubleIntConstructor(int x, int y) { } }

            /// <summary>Keep fleshing things out with TDD - we need to handle n parameters</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Two_Element_Array_For_Constructor_With_Two_Parameters()
            {
                var myBuilder = BuildTarget(typeof(DoubleIntConstructor));

                Assert.AreEqual<int>(2, myBuilder.GetDependencyDoubles().Count());
            }

            private class TwoConstructors { public TwoConstructors(int x) { } public TwoConstructors() { } }

            /// <summary>We want to mock the simplest constructor available -- less can go wrong that way</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Empty_For_Type_With_Default_Constructor_And_Parameter_Constructor()
            {
                var myBuilder = new ConstructorDependencyBuilder(typeof(TwoConstructors).GetConstructors());

                Assert.AreEqual<int>(0, myBuilder.GetDependencyDoubles().Count);
            }
        }
    }
}
