using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCode;
using Moq;
using DaedTech.EasyMoq.Doubles;

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
        }
    }
}
