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
        #region Initializing

        /// <summary>This class cannot operate without a constructor info - if you're passing null, something is wrong</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Null_ConstructorInfo_Parameter_Throws_ArgumentNullException()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new ConstructorDependencyBuilder(null));
        }

        #endregion

        #region GetDependencyDoubles

        /// <summary>If nothing is injected, nothing should be returned </summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_Returns_Empty_Array_For_Constructor_With_No_Parameters()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(ConstructorDependencyBuilderTest).GetConstructors()[0]); //What?  It has zero parameters... :P

            Assert.AreEqual<int>(0, myTargetConstructor.GetDependencyDoubles().Count());
        }

        #region SingleIntConstructor

        /// <summary>Define a class with one constructor parameter</summary>
        private class SingleIntConstructor { public SingleIntConstructor(int x) { } }

        /// <summary>If the constructor has a single parameter, we should get one </summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_Returns_One_Element_Array_For_Constructor_With_One_Parameter()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(SingleIntConstructor).GetConstructors()[0]);

            Assert.AreEqual<int>(1, myTargetConstructor.GetDependencyDoubles().Count());
        }

        /// <summary>It's not enough that it exist - it should be valid</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_On_SingleIntConstructor_Returns_FirstItem_With_TypeOf_Int()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(SingleIntConstructor).GetConstructors()[0]);

            Assert.IsInstanceOfType(myTargetConstructor.GetDependencyDoubles()[0], typeof(int));
        }

        /// <summary>Not only should it be an integer, but it should also be equal to default</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_On_SingleIntConstructor_Returns_FirstItem_Equal_To_Zero()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(SingleIntConstructor).GetConstructors()[0]);

            Assert.AreEqual<int>(0, (int)myTargetConstructor.GetDependencyDoubles()[0]);
        }
        #endregion

        #region DoubleIntConstructor

        private class DoubleIntConstructor { public DoubleIntConstructor(int x, int y) { } }

        /// <summary>Keep fleshing things out with TDD - we need to handle n parameters</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_Returns_Two_Element_Array_For_Constructor_With_Two_Parameters()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(DoubleIntConstructor).GetConstructors()[0]);

            Assert.AreEqual<int>(2, myTargetConstructor.GetDependencyDoubles().Count());
        }

        #endregion

        #region SingleStringConstructor

        private class SingleStringConstructor { public SingleStringConstructor(string x) { } }

        /// <summary>Default to null for strings, since that is the default</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_On_SingleStringConstructor_Returns_FirstItem_With_Null()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(SingleStringConstructor).GetConstructors()[0]);

            Assert.IsNull(myTargetConstructor.GetDependencyDoubles()[0]);
        }

        #endregion

        #region SingleInterfaceConstructor

        private class SingleInterfaceConstructor { public SingleInterfaceConstructor(IBasicMath x) { } }

        /// <summary>If the dependency is an interface, we should mock it</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void GetDependencyDoubles_On_SingleInterfaceConstructor_Returns_Null_With_DummyBuilder()
        {
            var myTargetConstructor = new ConstructorDependencyBuilder(typeof(SingleInterfaceConstructor).GetConstructors()[0]);

            Assert.IsNull(myTargetConstructor.GetDependencyDoubles()[0]);
        }

        #endregion

        #endregion
    }
}
