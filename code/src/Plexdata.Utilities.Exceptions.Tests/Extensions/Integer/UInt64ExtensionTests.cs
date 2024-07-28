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
    public class UInt64ExtensionTests
    {
        #region ThrowIfLessThan -> OverloadWithoutOtherArguments

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_DefaultOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan(minimum), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_ExceptionOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_DefaultOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException();

            Assert.That(() => actual.ThrowIfLessThan(minimum),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_ExceptionOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum)
        {
            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfLessThan -> OverloadWithParameterOnly

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_DefaultOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan(minimum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_ExceptionOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_DefaultOverloadWithParameterOnlyAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter");

            Assert.That(() => actual.ThrowIfLessThan(minimum, "parameter"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_ExceptionOverloadWithParameterOnlyAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum)
        {
            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum, "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfLessThan -> OverloadWithParameterAndMessage

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_DefaultOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan(minimum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)4, (UInt64)3)]
        public void ThrowIfLessThan_ExceptionOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum)
        {
            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_DefaultOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter", "message");

            Assert.That(() => actual.ThrowIfLessThan(minimum, "parameter", "message"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)3, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)5)]
        public void ThrowIfLessThan_ExceptionOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum)
        {
            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfLessThan<Exception>(minimum, "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfGreaterThan -> OverloadWithoutOtherArguments

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_DefaultOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan(maximum), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_DefaultOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException();

            Assert.That(() => actual.ThrowIfGreaterThan(maximum),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 maximum)
        {
            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfGreaterThan -> OverloadWithParameterOnly

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_DefaultOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan(maximum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_DefaultOverloadWithParameterOnlyAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter");

            Assert.That(() => actual.ThrowIfGreaterThan(maximum, "parameter"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithParameterOnlyAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 maximum)
        {
            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum, "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfGreaterThan -> OverloadWithParameterAndMessage

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_DefaultOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan(maximum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)3, (UInt64)3)]
        [TestCase((UInt64)3, (UInt64)4)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_DefaultOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter", "message");

            Assert.That(() => actual.ThrowIfGreaterThan(maximum, "parameter", "message"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)4, (UInt64)3)]
        [TestCase((UInt64)5, (UInt64)3)]
        public void ThrowIfGreaterThan_ExceptionOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 maximum)
        {
            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfGreaterThan<Exception>(maximum, "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfOutOfRange -> OverloadWithoutOtherArguments

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithoutOtherArgumentsAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum), Throws.Nothing);
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException();

            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithoutOtherArgumentsAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfOutOfRange -> OverloadWithParameterOnly

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithParameterOnlyAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum, "parameter"), Throws.Nothing);
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithParameterOnlyAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter");

            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum, "parameter"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithParameterOnlyAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum, "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion

        #region ThrowIfOutOfRange -> OverloadWithParameterAndMessage

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)4, (UInt64)4, (UInt64)4)]
        [TestCase((UInt64)3, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)4, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)5, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithParameterAndMessageAndValueIsValid_ThrowsNothing(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum, "parameter", "message"), Throws.Nothing);
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_DefaultOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsArgumentOutOfRangeException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            ArgumentOutOfRangeException reference = new ArgumentOutOfRangeException("parameter", "message");

            Assert.That(() => actual.ThrowIfOutOfRange(minimum, maximum, "parameter", "message"),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Message.EqualTo(reference.Message)
                    .And.Property("ParamName").EqualTo(reference.ParamName));
        }

        [TestCase((UInt64)2, (UInt64)3, (UInt64)5)]
        [TestCase((UInt64)6, (UInt64)3, (UInt64)5)]
        public void ThrowIfOutOfRange_ExceptionOverloadWithParameterAndMessageAndValueIsInvalid_ThrowsException(UInt64 actual, UInt64 minimum, UInt64 maximum)
        {
            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfOutOfRange<Exception>(minimum, maximum, "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        #endregion
    }
}
