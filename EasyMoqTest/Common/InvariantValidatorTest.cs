using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaedTech.EasyMoq.Common;

namespace DaedTech.EasyMoqTest.Common
{
    [TestClass]
    public class ValidatorTest
    {
        [TestClass]
        public class VerifyNonNull
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_If_Nothing_Is_Null()
            {
                ExtendedAssert.DoesNotThrow(() => new Validator().VerifyNonNull("asdf"));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_InvalidOperationExceptionException_With_Null_Argument()
            {
                ExtendedAssert.Throws<ArgumentNullException>(() => new Validator().VerifyNonNull((object)null));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_Exception_On_Non_Null_Argument()
            {
                ExtendedAssert.DoesNotThrow(() => new Validator().VerifyNonNull(new Object()));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_ArgumentNullException_On_Null_Argument()
            {
                ExtendedAssert.Throws<ArgumentNullException>(() => new Validator().VerifyNonNull((object)null));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_On_Non_Null_Argument()
            {
                ExtendedAssert.DoesNotThrow(() => new Validator().VerifyNonNull(new Object()));
            }
        }

        [TestClass]
        public class VerifyParamsNonNull
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_An_Exception_When_Any_Argument_Is_Null()
            {
                string one = "asdf";
                string two = "sadf";
                string three = null;

                ExtendedAssert.Throws<ArgumentNullException>(() => new Validator().VerifyParamsNonNull(one, two, three));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_For_No_Arguments()
            {
                ExtendedAssert.DoesNotThrow(() => new Validator().VerifyParamsNonNull());
            }
        }

        [TestClass]
        public class VerifyNotNullOrEmpty
        {
            /// <summary>By definition...</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_On_Empty_Or_Null_String()
            {
                var myValidator = new Validator();

                ExtendedAssert.Throws<InvalidOperationException>(() => myValidator.VerifyNotNullOrEmpty(string.Empty));
                ExtendedAssert.Throws<InvalidOperationException>(() => myValidator.VerifyNotNullOrEmpty(null));
            }

            /// <summary>By definition...</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_On_Valid_Argument()
            {
                var myValidator = new Validator();

                ExtendedAssert.DoesNotThrow(() => myValidator.VerifyNotNullOrEmpty("a"));
            }
        }
    }
    
}
