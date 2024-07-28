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
using Plexdata.Utilities.Testing;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Exceptions.Tests
{
    [ExcludeFromCodeCoverage]
    [Category(TestType.UnitTest)]
    public class UserNotQualifiedExceptionTests
    {
        [Test]
        public void UserNotQualifiedException_DefaultConstruction_ResultAsExpected()
        {
            UserNotQualifiedException instance = new UserNotQualifiedException();

            Assert.That(instance.Message, Is.EqualTo("The user does not seem to be qualified to perform such an action."));
            Assert.That(instance.InnerException, Is.Null);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void UserNotQualifiedException_MessageIsInvalidWithoutException_ResultAsExpected(String message)
        {
            UserNotQualifiedException instance = new UserNotQualifiedException(message);

            Assert.That(instance.Message, Is.EqualTo("The user does not seem to be qualified to perform such an action."));
            Assert.That(instance.InnerException, Is.Null);
        }

        [Test]
        public void UserNotQualifiedException_MessageIsValidWithoutException_ResultAsExpected()
        {
            String message = "some other funny message";

            UserNotQualifiedException instance = new UserNotQualifiedException(message);

            Assert.That(instance.Message, Is.EqualTo("some other funny message"));
            Assert.That(instance.InnerException, Is.Null);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void UserNotQualifiedException_MessageIsInvalidAndWithException_ResultAsExpected(String message)
        {
            Exception exception = new Exception();

            UserNotQualifiedException instance = new UserNotQualifiedException(message, exception);

            Assert.That(instance.Message, Is.EqualTo("The user does not seem to be qualified to perform such an action."));
            Assert.That(instance.InnerException, Is.SameAs(exception));
        }

        [Test]
        public void UserNotQualifiedException_MessageIsValidAndWithException_ResultAsExpected()
        {
            Exception exception = new Exception();

            String message = "some other funny message";

            UserNotQualifiedException instance = new UserNotQualifiedException(message, exception);

            Assert.That(instance.Message, Is.EqualTo("some other funny message"));
            Assert.That(instance.InnerException, Is.SameAs(exception));
        }
    }
}
