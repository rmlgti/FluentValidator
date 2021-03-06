﻿using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class DoubleValidationContractTests
    {              
        [TestMethod]
        [TestCategory("DoubleValidation")]
        public void IsBetweenDouble()
        {
            double value = 49.999;
            double from = 50.000;
            double to = 59.999;

            var wrong = new ValidationContract()
                .Requires()
                .IsBetween(value, from, to, "double", "The value 49.999 must be between 50.000 and 59.999");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            value = 1250.01;
            from = 1250.00;
            to = 1299.99;

            var right = new ValidationContract()
                .Requires()
                .IsBetween(value, from, to, "double", "The value 1250.01 is between 1000.01 and 1299.99");

            Assert.AreEqual(true, right.Valid);
        }      
    }
}
