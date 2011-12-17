using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleCode;
using DaedTech.EasyMoq.MoqInheritors;

namespace SampleCodeTest.MoqInheritors
{
    [TestClass]
    public class DummyTest
    {
        #region Behavior

        /// <summary>Dummy has no implementation behavior, so accesing its members should throw exceptions</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Dummy_Behavior_Is_Strict()
        {
            Assert.AreEqual<MockBehavior>(MockBehavior.Strict, new Dummy<IBasicMath>().Behavior);
        }

        #endregion

        #region CallBase

        /// <summary>A dummy is not capable of this behavior</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void CallBase_Is_Always_False()
        {
            var myDummy = new Dummy<IBasicMath>();
            myDummy.CallBase = true;

            Assert.IsFalse(myDummy.CallBase);
        }

        #endregion
    }
}
