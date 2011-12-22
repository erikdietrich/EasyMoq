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
        /// <summary>We should be able to build a type that has a constructor</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildWithDummies_Returns_Instance_Of_TargetType()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildWithDummies<BasicMathClient>(), typeof(BasicMathClient));
        }

        /// <summary>We should be able to build a type that has no constructor</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildWithDummies_Successfully_Generates_Instance_Of_Class_With_No_Constructor()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildWithDummies<BasicMath>(), typeof(BasicMath));
        }


        private class DummyIntConstructor
        {
            public int IntParameter {get;set; }
            
            /// <summary>Initializes a new instance of the DummyIntConstructor class.</summary>
            public DummyIntConstructor(int intParameter)
            {
                IntParameter = intParameter;
            }
        }

        /// <summary>We should be able to handle a class that takes an int as a parameter</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildWithDummies_Successfully_Generates_Type_With_Literal_Constructor_Parameter()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildWithDummies<DummyIntConstructor>(), typeof(DummyIntConstructor));
        }
    }
}
