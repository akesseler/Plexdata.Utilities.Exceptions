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
    public class ThrowIfNullOrEmptyExtensionTests
    {
        #region StandardOverload

        [TestCase(null)]
        [TestCase("")]
        public void StandardOverload_StringIsInvalid_ThrowsArgumentOutOfRangeException(String actual)
        {
            Assert.That(() => actual.ThrowIfNullOrEmpty(), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void StandardOverload_StringIsValid_ThrowsNothing()
        {
            String actual = "  actual  ";

            Assert.That(() => actual.ThrowIfNullOrEmpty(), Throws.Nothing);
        }

        [Test]
        public void StandardOverload_StringIsValid_ResultAsExpected()
        {
            String actual = "  actual  ";

            Assert.That(() => actual.ThrowIfNullOrEmpty(), Is.SameAs(actual));
        }

        #endregion

        #region ExceptionOverload

        [TestCase(null)]
        [TestCase("")]
        public void ExceptionOverload_StringIsInvalid_ThrowsArgumentException(String actual)
        {
            Assert.That(() => actual.ThrowIfNullOrEmpty<ArgumentException>(), Throws.ArgumentException);
        }

        [Test]
        public void ExceptionOverload_StringIsValid_ThrowsNothing()
        {
            String actual = "  actual  ";

            Assert.That(() => actual.ThrowIfNullOrEmpty<ArgumentException>(), Throws.Nothing);
        }

        [Test]
        public void ExceptionOverload_StringIsValid_ResultAsExpected()
        {
            String actual = "  actual  ";

            Assert.That(() => actual.ThrowIfNullOrEmpty<ArgumentException>(), Is.SameAs(actual));
        }

        #endregion
    }
}
