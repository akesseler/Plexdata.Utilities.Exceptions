/*
 * MIT License
 * 
 * Copyright (c) 2024 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using NUnit.Framework;
using Plexdata.Utilities.Exceptions.Extensions;

namespace Plexdata.Utilities.Exceptions.Tests.Extensions
{
    public class ThrowIfNotVerifiedExtensionTests
    {
        [SetUp]
        public void Setup()
        {
            this.checkResult = true;
        }

        #region Some system under test but null and some verifier

        [Test]
        public void StandardOverload_TestClassWithParameterlessVerifierAndValueIsNull_ThrowsArgumentVerifyException()
        {
            TestClass actual = null;
            Func<Boolean> verifier = delegate () { throw new Exception("Don't want to see this exception."); };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestClassWithParameterizedVerifierAndValueIsNull_ThrowsArgumentVerifyException()
        {
            TestClass actual = null;
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { throw new Exception("Don't want to see this exception."); };

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessVerifierAndValueIsNull_ThrowsArgumentException()
        {
            TestClass actual = null;
            Func<Boolean> verifier = delegate () { throw new Exception("Don't want to see this exception."); };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => verifier()), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedVerifierAndValueIsNull_ThrowsArgumentException()
        {
            TestClass actual = null;
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { throw new Exception("Don't want to see this exception."); };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => verifier(actual)), Throws.InstanceOf<ArgumentException>());
        }

        #endregion

        #region Some system under test and some verifier but null

        [Test]
        public void StandardOverload_TestClassWithParameterlessVerifierAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.InstanceOf<ArgumentVerifyException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void StandardOverload_TestClassWithParameterizedVerifierAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.InstanceOf<ArgumentVerifyException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessVerifierAndVerifierIsNull_ThrowsArgumentException()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => verifier()), Throws.InstanceOf<ArgumentException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedVerifierAndVerifierIsNull_ThrowsArgumentException()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => verifier(actual)), Throws.InstanceOf<ArgumentException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void StandardOverload_TestStructWithParameterlessVerifierAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.InstanceOf<ArgumentVerifyException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void StandardOverload_TestStructWithParameterizedVerifierAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.InstanceOf<ArgumentVerifyException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterlessVerifierAndVerifierIsNull_ThrowsArgumentException()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>(() => verifier()), Throws.InstanceOf<ArgumentException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterizedVerifierAndVerifierIsNull_ThrowsArgumentException()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = null;

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>((actual) => verifier(actual)), Throws.InstanceOf<ArgumentException>()
                .And.Property("Message").StartsWith((new NullReferenceException()).Message)
                .And.Property("ParamName").EqualTo(nameof(verifier)));
        }

        #endregion

        #region Some system under test and some verifier returns true

        [Test]
        public void StandardOverload_TestClassWithParameterlessVerifierAndVerifierReturnsTrue_ResultIsSame()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(actual.ThrowIfNotVerified(() => verifier()), Is.SameAs(actual));
        }

        [Test]
        public void StandardOverload_TestClassWithParameterizedVerifierAndVerifierReturnsTrue_ResultIsSame()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return true; };

            Assert.That(actual.ThrowIfNotVerified((actual) => verifier(actual)), Is.SameAs(actual));
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessVerifierAndVerifierReturnsTrue_ResultIsSame()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => verifier()), Is.SameAs(actual));
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedVerifierAndVerifierReturnsTrue_ResultIsSame()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return true; };

            Assert.That(actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => verifier(actual)), Is.SameAs(actual));
        }

        [Test]
        public void StandardOverload_TestStructWithParameterlessVerifierAndVerifierReturnsTrue_ResultIsEqual()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(actual.ThrowIfNotVerified(() => verifier()), Is.EqualTo(actual));
        }

        [Test]
        public void StandardOverload_TestStructWithParameterizedVerifierAndVerifierReturnsTrue_ResultIsEqual()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return true; };

            Assert.That(actual.ThrowIfNotVerified((actual) => verifier(actual)), Is.EqualTo(actual));
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterlessVerifierAndVerifierReturnsTrue_ResultIsEqual()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(actual.ThrowIfNotVerified<TestStruct, ArgumentException>(() => verifier()), Is.EqualTo(actual));
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterizedVerifierAndVerifierReturnsTrue_ResultIsEqual()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return true; };

            Assert.That(actual.ThrowIfNotVerified<TestStruct, ArgumentException>((actual) => verifier(actual)), Is.EqualTo(actual));
        }

        #endregion

        #region Test class and parameterless verifier as delegate and standard exception

        [Test]
        public void StandardOverload_TestClassWithParameterlessVerifierAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return false; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestClassWithParameterlessVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterized verifier as delegate and standard exception

        [Test]
        public void StandardOverload_TestClassWithParameterizedVerifierAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return false; };

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestClassWithParameterizedVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return true; };

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterless verifier as delegate and argument exception

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessVerifierAndVerifierReturnsFalse_ThrowsArgumentException()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return false; };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => verifier()), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestClass actual = new TestClass();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => verifier()), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterized verifier as delegate and argument exception

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedVerifierAndVerifierReturnsFalse_ThrowsArgumentException()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return false; };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => verifier(actual)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestClass actual = new TestClass();
            Func<TestClass, Boolean> verifier = delegate (TestClass _) { return true; };

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => verifier(actual)), Throws.Nothing);
        }

        #endregion

        #region Test struct and parameterless verifier as delegate and standard exception

        [Test]
        public void StandardOverload_TestStructWithParameterlessVerifierAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return false; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestStructWithParameterlessVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifier()), Throws.Nothing);
        }

        #endregion

        #region Test struct and parameterized verifier as delegate and standard exception

        [Test]
        public void StandardOverload_TestStructWithParameterizedVerifierAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return false; };

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestStructWithParameterizedVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return true; };

            Assert.That(() => actual.ThrowIfNotVerified((actual) => verifier(actual)), Throws.Nothing);
        }

        #endregion

        #region Test struct and parameterless verifier as delegate and argument exception

        [Test]
        public void ExceptionOverload_TestStructWithParameterlessVerifierAndVerifierReturnsFalse_ThrowsArgumentException()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return false; };

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>(() => verifier()), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterlessVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestStruct actual = new TestStruct();
            Func<Boolean> verifier = delegate () { return true; };

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>(() => verifier()), Throws.Nothing);
        }

        #endregion

        #region Test struct and parameterized verifier as delegate and argument exception

        [Test]
        public void ExceptionOverload_TestStructWithParameterizedVerifierAndVerifierReturnsFalse_ThrowsArgumentException()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return false; };

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>((actual) => verifier(actual)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestStructWithParameterizedVerifierAndVerifierReturnsTrue_ThrowsNothing()
        {
            TestStruct actual = new TestStruct();
            Func<TestStruct, Boolean> verifier = delegate (TestStruct _) { return true; };

            Assert.That(() => actual.ThrowIfNotVerified<TestStruct, ArgumentException>((actual) => verifier(actual)), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterless verifier as method and standard exception

        [Test]
        public void StandardOverload_TestClassWithParameterlessMethodAndMethodReturnsFalse_ThrowsArgumentVerifyException()
        {
            this.checkResult = false;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified(() => this.DoParameterlessCheck()), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestClassWithParameterlessMethodAndMethodReturnsTrue_ThrowsNothing()
        {
            this.checkResult = true;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified(() => this.DoParameterlessCheck()), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterized verifier as method and standard exception

        [Test]
        public void StandardOverload_TestClassWithParameterizedMethodAndMethodReturnsFalse_ThrowsArgumentVerifyException()
        {
            this.checkResult = false;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified((actual) => this.DoParameterizedCheck(actual)), Throws.InstanceOf<ArgumentVerifyException>());
        }

        [Test]
        public void StandardOverload_TestClassWithParameterizedMethodAndMethodReturnsTrue_ThrowsNothing()
        {
            this.checkResult = true;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified((actual) => this.DoParameterizedCheck(actual)), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterless verifier as method and argument exception

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessMethodAndMethodReturnsFalse_ThrowsArgumentException()
        {
            this.checkResult = false;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => this.DoParameterlessCheck()), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterlessMethodAndMethodReturnsTrue_ThrowsNothing()
        {
            this.checkResult = true;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>(() => this.DoParameterlessCheck()), Throws.Nothing);
        }

        #endregion

        #region Test class and parameterized verifier as method and argument exception

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedMethodAndMethodReturnsFalse_ThrowsArgumentException()
        {
            this.checkResult = false;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => this.DoParameterizedCheck(actual)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ExceptionOverload_TestClassWithParameterizedMethodAndMethodReturnsTrue_ThrowsNothing()
        {
            this.checkResult = true;

            TestClass actual = new TestClass();

            Assert.That(() => actual.ThrowIfNotVerified<TestClass, ArgumentException>((actual) => this.DoParameterizedCheck(actual)), Throws.Nothing);
        }

        #endregion

        #region Private Helpers

        private class TestClass { }

        private struct TestStruct { }

        private Boolean checkResult;

        private Boolean DoParameterlessCheck() { return this.checkResult; }

        private Boolean DoParameterizedCheck(TestClass _) { return this.checkResult; }

        #endregion
    }
}
