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
using Plexdata.Utilities.Testing;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Exceptions.Tests.Extensions
{
    [ExcludeFromCodeCoverage]
    [Category(TestType.UnitTest)]
    public class StringExtensionTests
    {
        #region ThrowIfNullOrEmpty -> OverloadWithoutOtherArguments

        [Test]
        public void ThrowIfNullOrEmpty_DefaultOverloadAndOverloadWithoutOtherArgumentsAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty(), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrEmpty_ExceptionOverloadAndOverloadWithoutOtherArgumentsAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>(), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_DefaultOverloadAndOverloadWithoutOtherArgumentsAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException();

            Assert.That(() => actual.ThrowIfNullOrEmpty(),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_ExceptionOverloadAndOverloadWithoutOtherArgumentsAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception();

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>(),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNullOrEmpty -> OverloadWithParameterOnly      

        [Test]
        public void ThrowIfNullOrEmpty_DefaultOverloadWithParameterOnlyAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty("parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrEmpty_ExceptionOverloadWithParameterOnlyAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>("parameter"), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_DefaultOverloadWithParameterOnlyAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter");

            Assert.That(() => actual.ThrowIfNullOrEmpty("parameter"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_ExceptionOverloadWithParameterOnlyAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>("parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNullOrEmpty -> OverloadWithParameterAndMessage

        [Test]
        public void ThrowIfNullOrEmpty_DefaultOverloadWithParameterAndMessageAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty("parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrEmpty_ExceptionOverloadWithParameterAndMessageAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>("parameter", "message"), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_DefaultOverloadWithParameterAndMessageAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter", "message");

            Assert.That(() => actual.ThrowIfNullOrEmpty("parameter", "message"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowIfNullOrEmpty_ExceptionOverloadWithParameterAndMessageAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception("message");

            Assert.That(() => actual.ThrowIfNullOrEmpty<Exception>("parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNullOrWhiteSpace -> OverloadWithoutOtherArguments

        [Test]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadAndOverloadWithoutOtherArgumentsAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace(), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadAndOverloadWithoutOtherArgumentsAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>(), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadAndOverloadWithoutOtherArgumentsAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException();

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace(),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadAndOverloadWithoutOtherArgumentsAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception();

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>(),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNullOrWhiteSpace -> OverloadWithParameterOnly

        [Test]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadWithParameterOnlyAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace("parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadWithParameterOnlyAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>("parameter"), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadWithParameterOnlyAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter");

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace("parameter"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadWithParameterOnlyAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>("parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNullOrWhiteSpace -> OverloadWithParameterAndMessage

        [Test]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadWithParameterAndMessageAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace("parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadWithParameterAndMessageAndStringIsValid_ThrowsNothing()
        {
            String actual = "value";

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>("parameter", "message"), Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_DefaultOverloadWithParameterAndMessageAndStringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            ArgumentOutOfRangeException expected = new ArgumentOutOfRangeException("parameter", "message");

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace("parameter", "message"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowIfNullOrWhiteSpace_ExceptionOverloadWithParameterAndMessageAndStringIsInvalid_ThrowsException(String actual)
        {
            Exception expected = new Exception("message");

            Assert.That(() => actual.ThrowIfNullOrWhiteSpace<Exception>("parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion
    }
}
