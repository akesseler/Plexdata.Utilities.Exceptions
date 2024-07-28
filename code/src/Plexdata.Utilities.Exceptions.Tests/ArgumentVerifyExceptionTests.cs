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
    public class ArgumentVerifyExceptionTests
    {
        [Test]
        public void ArgumentVerifyException_DefaultConstruction_ResultAsExpected()
        {
            ArgumentVerifyException instance = new ArgumentVerifyException();

            Assert.That(instance.Message, Does.StartWith("The argument is null or could not be verified."));
            Assert.That(instance.ParamName, Is.Null);
            Assert.That(instance.InnerException, Is.Null);
        }

        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase("  ", null)]
        [TestCase("parameter", "parameter")]
        public void ArgumentVerifyException_ConstructionWithParameterOnly_ResultAsExpected(String actualParameter, String expectedParameter)
        {
            ArgumentVerifyException instance = new ArgumentVerifyException(actualParameter);

            Assert.That(instance.Message, Does.StartWith("The argument is null or could not be verified."));
            Assert.That(instance.ParamName, Is.EqualTo(expectedParameter));
            Assert.That(instance.InnerException, Is.Null);
        }

        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase("  ", null)]
        [TestCase("parameter", "parameter")]
        public void ArgumentVerifyException_ConstructionWithParameterAndException_ResultAsExpected(String actualParameter, String expectedParameter)
        {
            Exception exception = new Exception();

            ArgumentVerifyException instance = new ArgumentVerifyException(actualParameter, exception);

            Assert.That(instance.Message, Does.StartWith("The argument is null or could not be verified."));
            Assert.That(instance.ParamName, Is.EqualTo(expectedParameter));
            Assert.That(instance.InnerException, Is.SameAs(exception));
        }

        [TestCase(null, "message", null, "message")]
        [TestCase("", "message", null, "message")]
        [TestCase("  ", "message", null, "message")]
        [TestCase("parameter", null, "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "", "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "  ", "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "message", "parameter", "message")]
        public void ArgumentVerifyException_ConstructionWithParameterAndMessage_ResultAsExpected(String actualParameter, String actualMessage, String expectedParameter, String expectedMessage)
        {
            ArgumentVerifyException instance = new ArgumentVerifyException(actualParameter, actualMessage);

            Assert.That(instance.Message, Does.StartWith(expectedMessage));
            Assert.That(instance.ParamName, Is.EqualTo(expectedParameter));
            Assert.That(instance.InnerException, Is.Null);
        }

        [TestCase(null, "message", null, "message")]
        [TestCase("", "message", null, "message")]
        [TestCase("  ", "message", null, "message")]
        [TestCase("parameter", null, "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "", "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "  ", "parameter", "The argument is null or could not be verified.")]
        [TestCase("parameter", "message", "parameter", "message")]
        public void ArgumentVerifyException_ConstructionWithParameterAndMessageAndException_ResultAsExpected(String actualParameter, String actualMessage, String expectedParameter, String expectedMessage)
        {
            Exception exception = new Exception();

            ArgumentVerifyException instance = new ArgumentVerifyException(actualParameter, actualMessage, exception);

            Assert.That(instance.Message, Does.StartWith(expectedMessage));
            Assert.That(instance.ParamName, Is.EqualTo(expectedParameter));
            Assert.That(instance.InnerException, Is.SameAs(exception));
        }
    }
}
