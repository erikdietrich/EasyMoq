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
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildWithDummies_Returns_Instance_Of_TargetType()
        {
            Assert.IsInstanceOfType(new TargetBuilder().BuildWithDummies<BasicMathClient>(), typeof(BasicMathClient));
        }
    }
}
