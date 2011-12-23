using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Builders;
using SampleCode;

namespace SampleCodeTest.Builders
{
    [TestClass]
    public class TargetBuilderTest
    {
        #region BuildTarget

        /// <summary>We should be able to build a type that has a constructor</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildTarget_Returns_Instance_Of_TargetType()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildTarget<BasicMathClient>(), typeof(BasicMathClient));
        }

        /// <summary>We should be able to build a type that has no constructor</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildTarget_Successfully_Generates_Instance_Of_Class_With_No_Constructor()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildTarget<BasicMath>(), typeof(BasicMath));
        }


        private class DummyIntConstructor
        {
            public int IntParameter { get; set; }

            /// <summary>Initializes a new instance of the DummyIntConstructor class.</summary>
            public DummyIntConstructor(int intParameter)
            {
                IntParameter = intParameter;
            }
        }

        /// <summary>We should be able to handle a class that takes an int as a parameter</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildTarget_Successfully_Generates_Type_With_Literal_Constructor_Parameter()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildTarget<DummyIntConstructor>(), typeof(DummyIntConstructor));
        }

        /// <summary>By convention, use type default for non-class objects</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildTarget_Assigns_Literal_Parameter_To_Default()
        {
            Assert.AreEqual<int>(default(int), new TargetBuilder().BuildTarget<DummyIntConstructor>().IntParameter);
        }

        #endregion
    }
}
