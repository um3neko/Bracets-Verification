using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BracketsVerificationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        
        public void Empty_Input_String()
        {
            string str = "";
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            var ex = Assert.Throws<ArgumentException>(() => verificator.checkInputValidation(str));
            Assert.That(ex.Message, Is.EqualTo("String is empty"));
        }

        [Test]
        public void Null_Input_String()
        {
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            var ex = Assert.Throws<ArgumentException>(() => verificator.checkInputValidation(null));
            Assert.That(ex.Message, Is.EqualTo("String is empty"));
        }

        [Test]
        public void String_Contain_Not_Allowed_Characters()
        {
            string str = "{str}";
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            var ex = Assert.Throws<ArgumentException>(() => verificator.checkInputValidation(str));
            Assert.That(ex.Message, Is.EqualTo($"A characters doesn’t belong to any known brackets type "));
        }

        [Test]
        public void check_Input_Validation_For_Balanced_String()
        {
            string str = "{([])}";
            List<int> expected = new List<int>();
            expected.Add(-1);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void check_Input_Validation_For_Balanced_String_2()
        {
            string str = "({[]}{}()[])";
            List<int> expected = new List<int>();
            expected.Add(-1);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void check_Input_Validation_For_Balanced_String_3()
        {
            string str = "({}{[[[()]]]}{})";
            List<int> expected = new List<int>();
            expected.Add(-1);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void check_Input_Validation_For_Not_Balanced_IString()
        {
            string str = "){([])}";
            List<int> expected = new List<int>();
            expected.Add(1);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void check_Input_Validation_For_Not_Balanced_IString2()
        {
            string str = "{(})";
            List<int> expected = new List<int>();
            expected.Add(3);
            expected.Add(4);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void check_Input_Validation_For_Not_Balanced_IString3()
        {
            string str = "([)]{(})[";
            List<int> expected = new List<int>();
            expected.Add(3);
            expected.Add(4);
            expected.Add(7);
            expected.Add(8);
            Bracets_Verification.BracketsVerification verificator = new Bracets_Verification.BracketsVerification();
            List<int> actual = new List<int>();
            actual = verificator.checkInputValidation(str);
            Assert.AreEqual(expected, actual);
        }

    }
}