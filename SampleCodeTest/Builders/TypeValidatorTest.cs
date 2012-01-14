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
    public class TypeValidatorTest
    {
        #region VerifyMoqable

        /// <summary>An interface is moqable, so this shouldn't throw</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void VerifyMoqable_Does_Not_Throw_When_Type_Is_Interface()
        {
            var myValidator = new TypeValidator();

            ExtendedAssert.DoesNotThrow(() => myValidator.VerifyMoqable(typeof(IBasicMath)));
        }


        #endregion
    }
}
