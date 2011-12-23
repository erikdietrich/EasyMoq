﻿using System;
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
    public class DummyMockBuilderTest
    {
        /// <summary>This shouldn't be allowed - it makes no sense</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildMock_Throws_Exception_On_Null_Argument()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new DummyMockBuilder().BuildMock(null));
        }

        /// <summary>Happy path should return the mock we want</summary>
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void BuildMock_Returns_Instance_Of_Mock_With_Generic_Parameter_Type()
        {
            Assert.IsInstanceOfType(new DummyMockBuilder().BuildMock(typeof(IBasicMath)), typeof(Mock<IBasicMath>));
        }   
    }
}