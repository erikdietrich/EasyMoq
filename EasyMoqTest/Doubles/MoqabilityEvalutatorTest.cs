using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using DaedTech.EasyMoq.Builders;
using Moq;
using SampleCode;
using DaedTech.EasyMoq.Doubles;

namespace DaedTech.EasyMoqTest.Doubles
{
    [TestClass]
    public class MoqabilityEvalutatorTest
    {
        [TestClass]
        public class CanBeMoqed
        {
            /// <summary>Interfaces are always moqable</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_Interface()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsTrue(myEvaluator.IsMoqable<IBasicMath>());
            }

            /// <summary>We can't use Moq to mock value types</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_ValueType()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsFalse(myEvaluator.IsMoqable<int>());
            }

            public class Moqable { }
            
            /// <summary>We should be able to moq a class with a default constructor</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_Type_With_Default_Constructor()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsTrue(myEvaluator.IsMoqable<Moqable>());
            }

            public class NoDefaultXtor { NoDefaultXtor(int x) { }  }

            /// <summary>Moq won't support this, so neither should we</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_Reference_Type_With_No_Empty_Constructor()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsTrue(myEvaluator.IsMoqable<NoDefaultXtor>());
            }

            /// <summary>Strings are not moqable</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_String()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsFalse(myEvaluator.IsMoqable<string>());
            }
        }
    }
}
