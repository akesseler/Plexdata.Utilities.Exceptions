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
    public class ObjectExtensionTests
    {
        #region ThrowIfNull -> OverloadWithoutOtherArguments

        [Test]
        public void ThrowIfNull_DefaultOverloadWithoutOtherArgumentsAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull(), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithoutOtherArgumentsAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull<Exception>(), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_DefaultOverloadWithoutOtherArgumentsAndObjectIsNull_ThrowsArgumentNullException()
        {
            Object actual = null;

            ArgumentNullException expected = new ArgumentNullException();

            Assert.That(() => actual.ThrowIfNull(),
                Throws.InstanceOf<ArgumentNullException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithoutOtherArgumentsAndObjectIsNull_ThrowsException()
        {
            Object actual = null;

            Exception expected = new Exception();

            Assert.That(() => actual.ThrowIfNull<Exception>(),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNull -> OverloadWithParameterOnly

        [Test]
        public void ThrowIfNull_DefaultOverloadWithParameterOnlyAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull("parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithParameterOnlyAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull<Exception>("parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_DefaultOverloadWithParameterOnlyAndObjectIsNull_ThrowsArgumentNullException()
        {
            Object actual = null;

            ArgumentNullException expected = new ArgumentNullException("parameter");

            Assert.That(() => actual.ThrowIfNull("parameter"),
                Throws.InstanceOf<ArgumentNullException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithParameterOnlyAndObjectIsNull_ThrowsException()
        {
            Object actual = null;

            Exception expected = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNull<Exception>("parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion

        #region ThrowIfNull -> OverloadWithParameterAndMessage

        [Test]
        public void ThrowIfNull_DefaultOverloadWithParameterAndMessageAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull("parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithParameterAndMessageAndObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull<Exception>("parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNull_DefaultOverloadWithParameterAndMessageAndObjectIsNull_ThrowsArgumentNullException()
        {
            Object actual = null;

            ArgumentNullException expected = new ArgumentNullException("parameter", "message");

            Assert.That(() => actual.ThrowIfNull("parameter", "message"),
                Throws.InstanceOf<ArgumentNullException>()
                    .And.Message.EqualTo(expected.Message)
                    .And.Property("ParamName").EqualTo(expected.ParamName));
        }

        [Test]
        public void ThrowIfNull_ExceptionOverloadWithParameterAndMessageAndObjectIsNull_ThrowsException()
        {
            Object actual = null;

            Exception expected = new Exception("message");

            Assert.That(() => actual.ThrowIfNull<Exception>("parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(expected.Message));
        }

        #endregion
    }
}
