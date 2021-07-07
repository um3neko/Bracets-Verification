using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bracets_Verification;
using System;
using NUnit.Framework;

namespace BracketsVerification.tests
{
    [TestClass]
    public class BracketsVerificationTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), "A string is empty.")]
        public void NullOrEmptyInputString()
        {
            string str = "s";

            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            verificator.checkInputValidation(str);

        }
    }
}
