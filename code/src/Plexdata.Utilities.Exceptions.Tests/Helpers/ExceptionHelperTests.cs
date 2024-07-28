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
using Plexdata.Utilities.Exceptions.Helpers;
using Plexdata.Utilities.Testing;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Exceptions.Tests.Helpers
{
    [ExcludeFromCodeCoverage]
    [Category(TestType.UnitTest)]
    public class ExceptionHelperTests
    {
        #region Invalid Parameter And Invalid Message

        [Test]
        public void CreateException_TypeIsArgumentExceptionWithParameterAndMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter, [Values(null, "", "  ")] String message)
        {
            ArgumentException expected = new ArgumentException();

            ArgumentException actual = ExceptionHelper.CreateException<ArgumentException>(parameter, message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentNullExceptionWithParameterAndMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter, [Values(null, "", "  ")] String message)
        {
            ArgumentNullException expected = new ArgumentNullException();

            ArgumentNullException actual = ExceptionHelper.CreateException<ArgumentNullException>(parameter, message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentOutOfRangeExceptionWithParameterAndMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter, [Values(null, "", "  ")] String message)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException();

            ArgumentOutOfRangeException actual = ExceptionHelper.CreateException<ArgumentOutOfRangeException>(parameter, message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentVerifyExceptionWithParameterAndMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter, [Values(null, "", "  ")] String message)
        {
            ArgumentVerifyException expected = new ArgumentVerifyException();

            ArgumentVerifyException actual = ExceptionHelper.CreateException<ArgumentVerifyException>(parameter, message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsExceptionWithDefaultConstructorOnlyWithParameterAndMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter, [Values(null, "", "  ")] String message)
        {
            ExceptionWithDefaultConstructorOnly expected = new ExceptionWithDefaultConstructorOnly();

            ExceptionWithDefaultConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithDefaultConstructorOnly>(parameter, message);

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        #endregion

        #region Invalid Parameter And Valid Message

        [Test]
        public void CreateException_TypeIsArgumentExceptionWithParameterIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter)
        {
            ArgumentException expected = new ArgumentException("message");

            ArgumentException actual = ExceptionHelper.CreateException<ArgumentException>(parameter, "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentNullExceptionWithParameterIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter)
        {
            ArgumentNullException expected = new ArgumentNullException(null, "message");

            ArgumentNullException actual = ExceptionHelper.CreateException<ArgumentNullException>(parameter, "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentOutOfRangeExceptionWithParameterIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException(null, "message");

            ArgumentOutOfRangeException actual = ExceptionHelper.CreateException<ArgumentOutOfRangeException>(parameter, "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentVerifyExceptionWithParameterIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter)
        {
            ArgumentVerifyException expected = new ArgumentVerifyException(null, "message");

            ArgumentVerifyException actual = ExceptionHelper.CreateException<ArgumentVerifyException>(parameter, "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsExceptionWithSingleStringConstructorOnlyWithParameterIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String parameter)
        {
            ExceptionWithSingleStringConstructorOnly expected = new ExceptionWithSingleStringConstructorOnly("message");

            ExceptionWithSingleStringConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithSingleStringConstructorOnly>(parameter, "message");

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        #endregion

        #region Valid Parameter And Invalid Message

        [Test]
        public void CreateException_TypeIsArgumentExceptionWithMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String message)
        {
            ArgumentException expected = new ArgumentException(null, "parameter");

            ArgumentException actual = ExceptionHelper.CreateException<ArgumentException>("parameter", message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentNullExceptionWithMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String message)
        {
            ArgumentNullException expected = new ArgumentNullException("parameter");

            ArgumentNullException actual = ExceptionHelper.CreateException<ArgumentNullException>("parameter", message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentOutOfRangeExceptionWithMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String message)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter");

            ArgumentOutOfRangeException actual = ExceptionHelper.CreateException<ArgumentOutOfRangeException>("parameter", message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentVerifyExceptionWithMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String message)
        {
            ArgumentVerifyException expected = new ArgumentVerifyException("parameter");

            ArgumentVerifyException actual = ExceptionHelper.CreateException<ArgumentVerifyException>("parameter", message);

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsExceptionWithSingleStringConstructorOnlyWithMessageIsInvalid_ParameterAndMessageAsExpected([Values(null, "", "  ")] String message)
        {
            ExceptionWithSingleStringConstructorOnly expected = new ExceptionWithSingleStringConstructorOnly("parameter");

            ExceptionWithSingleStringConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithSingleStringConstructorOnly>("parameter", message);

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        #endregion

        #region Valid Parameter And Valid Message

        [Test]
        public void CreateException_TypeIsArgumentExceptionWithParameterAndMessageIsValid_ParameterAndMessageAsExpected()
        {
            ArgumentException expected = new ArgumentException("message", "parameter");

            ArgumentException actual = ExceptionHelper.CreateException<ArgumentException>("parameter", "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentNullExceptionWithParameterAndMessageIsValid_ParameterAndMessageAsExpected()
        {
            ArgumentNullException expected = new ArgumentNullException("parameter", "message");

            ArgumentNullException actual = ExceptionHelper.CreateException<ArgumentNullException>("parameter", "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentOutOfRangeExceptionWithParameterAndMessageIsValid_ParameterAndMessageAsExpected()
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter", "message");

            ArgumentOutOfRangeException actual = ExceptionHelper.CreateException<ArgumentOutOfRangeException>("parameter", "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsArgumentVerifyExceptionWithParameterAndMessageIsValid_ParameterAndMessageAsExpected()
        {
            ArgumentVerifyException expected = new ArgumentVerifyException("parameter", "message");

            ArgumentVerifyException actual = ExceptionHelper.CreateException<ArgumentVerifyException>("parameter", "message");

            Assert.That(actual.ParamName, Is.EqualTo(expected.ParamName));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_TypeIsExceptionWithDoubleStringConstructorOnlyWithParameterAndMessageIsValid_ParameterAndMessageAsExpected()
        {
            ExceptionWithDoubleStringConstructorOnly expected = new ExceptionWithDoubleStringConstructorOnly("parameter", "message");

            ExceptionWithDoubleStringConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithDoubleStringConstructorOnly>("parameter", "message");

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        #endregion

        #region Missing Member Exception Handling

        [Test]
        public void CreateException_MissingMemberExceptionForExceptionWithSingleStringConstructorOnly_ParameterAndMessageAsExpected()
        {
            ExceptionWithSingleStringConstructorOnly expected = new ExceptionWithSingleStringConstructorOnly("message");

            ExceptionWithSingleStringConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithSingleStringConstructorOnly>("parameter", "message");

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        [Test]
        public void CreateException_MissingMemberExceptionForExceptionWithDefaultConstructorOnly_ParameterAndMessageAsExpected()
        {
            ExceptionWithDefaultConstructorOnly expected = new ExceptionWithDefaultConstructorOnly();

            ExceptionWithDefaultConstructorOnly actual = ExceptionHelper.CreateException<ExceptionWithDefaultConstructorOnly>("parameter", "message");

            Assert.That(actual.Parameter, Is.EqualTo(expected.Parameter));
            Assert.That(actual.Message, Does.StartWith(expected.Message));
        }

        #endregion

        #region Helpers

        private class ExceptionWithDefaultConstructorOnly : Exception
        {
            public ExceptionWithDefaultConstructorOnly()
                : base("default message")
            {
                this.Parameter = "default parameter";
            }

            public String Parameter { get; }
        }

        private class ExceptionWithSingleStringConstructorOnly : Exception
        {
            [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
            public ExceptionWithSingleStringConstructorOnly(String message)
                : base(message)
            {
                this.Parameter = "default parameter";
            }

            public String Parameter { get; }
        }

        private class ExceptionWithDoubleStringConstructorOnly : Exception
        {
            [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
            public ExceptionWithDoubleStringConstructorOnly(String parameter, String message)
                : base(message)
            {
                this.Parameter = parameter;
            }

            public String Parameter { get; }
        }

        #endregion
    }
}
