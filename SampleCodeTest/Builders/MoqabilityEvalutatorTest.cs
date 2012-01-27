using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using DaedTech.EasyMoq.Builders;
using SampleCode;
using Moq;

namespace SampleCodeTest.Builders
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

                Assert.IsTrue(myEvaluator.IsMoqable(typeof(IBasicMath)));
            }

            /// <summary>We can't use Moq to mock value types</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_ValueType()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsFalse(myEvaluator.IsMoqable(typeof(int)));
            }

            public class Moqable { }
            
            /// <summary>We should be able to moq a class with a default constructor</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_Type_With_Default_Constructor()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsTrue(myEvaluator.IsMoqable(typeof(Moqable)));
            }

            public class NotMoqable { NotMoqable(int x) { }  }

            /// <summary>Moq won't support this, so neither should we</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_Type_With_No_Empty_Constructor()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsFalse(myEvaluator.IsMoqable(typeof(NotMoqable)));
            }

            /// <summary>Obviously, we can't moq null</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_When_Passed_Null()
            {
                var myEvaluator = new MoqabilityEvaluator();

                Assert.IsFalse(myEvaluator.IsMoqable(null));
            }
        }
    }
}
