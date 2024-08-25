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
    public class ThrowIfNullExtensionTests
    {
        #region StandardOverload

        [Test]
        public void StandardOverload_ObjectIsNull_ThrowsArgumentNullException()
        {
            Object actual = null;

            Assert.That(() => actual.ThrowIfNull(), Throws.ArgumentNullException);
        }

        [Test]
        public void StandardOverload_ObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull(), Throws.Nothing);
        }

        [Test]
        public void StandardOverload_ObjectIsValid_ResultAsExpected()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull(), Is.SameAs(actual));
        }

        #endregion

        #region ExceptionOverload

        [Test]
        public void ExceptionOverload_ObjectIsNull_ThrowsArgumentException()
        {
            Object actual = null;

            Assert.That(() => actual.ThrowIfNull<Object, ArgumentException>(), Throws.ArgumentException);
        }

        [Test]
        public void ExceptionOverload_ObjectIsValid_ThrowsNothing()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull<Object, ArgumentException>(), Throws.Nothing);
        }

        [Test]
        public void ExceptionOverload_ObjectIsValid_ResultAsExpected()
        {
            Object actual = new Object();

            Assert.That(() => actual.ThrowIfNull<Object, ArgumentException>(), Is.SameAs(actual));
        }

        #endregion
    }
}
