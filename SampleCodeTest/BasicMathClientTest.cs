using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCode;
using DaedTech.EasyMoq.MoqInheritors;
using Moq;

namespace SampleCodeTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BasicMathClientTest
    {
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Dummy_Always_Returns_Strict_Behavior()
        {
            var myStub = new DummyMock<IBasicMath>();

            Assert.AreEqual<MockBehavior>(MockBehavior.Strict, myStub.Behavior);
        }
    }
}
