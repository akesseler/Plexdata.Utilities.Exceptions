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
using Plexdata.Utilities.Exceptions.Tests.Extensions.Helpers;
using Plexdata.Utilities.Testing;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Exceptions.Tests.Extensions
{
    [ExcludeFromCodeCoverage]
    [Category(TestType.UnitTest)]
    public class ThrowIfOutOfRangeExtensionTests
    {
        #region StandardOverload

        [Test]
        public void StandardOverload_ValueIsNull_ThrowsArgumentOutOfRangeException()
        {
            CustomData value = null;
            CustomData minimum = new CustomData(false);
            CustomData maximum = new CustomData(false);

            Assert.That(() => value.ThrowIfOutOfRange(minimum, maximum), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCaseSource(nameof(TestDataParametersForFailure))]
        public void StandardOverload_ParametersAsProvided_ThrowsArgumentOutOfRangeException<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfOutOfRange(source.Minimum, source.Maximum), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void StandardOverload_ParametersAsProvided_ThrowsNothing<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfOutOfRange(source.Minimum, source.Maximum), Throws.Nothing);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void StandardOverload_ParametersAsProvided_ResultAsExpected<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(source.Value.ThrowIfOutOfRange(source.Minimum, source.Maximum), Is.EqualTo(source.Value));
        }

        #endregion

        #region ExceptionOverload

        [Test]
        public void ExceptionOverload_ValueIsNull_ThrowsArgumentException()
        {
            CustomData value = null;
            CustomData minimum = new CustomData(false);
            CustomData maximum = new CustomData(false);

            Assert.That(() => value.ThrowIfOutOfRange<CustomData, ArgumentException>(minimum, maximum), Throws.ArgumentException);
        }

        [TestCaseSource(nameof(TestDataParametersForFailure))]
        public void ExceptionOverload_ParametersAsProvided_ThrowsArgumentException<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfOutOfRange<T, ArgumentException>(source.Minimum, source.Maximum), Throws.ArgumentException);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void ExceptionOverload_ParametersAsProvided_ThrowsNothing<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfOutOfRange<T, ArgumentException>(source.Minimum, source.Maximum), Throws.Nothing);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void ExceptionOverload_ParametersAsProvided_ResultAsExpected<T>(GenericRange<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(source.Value.ThrowIfOutOfRange<T, ArgumentException>(source.Minimum, source.Maximum), Is.EqualTo(source.Value));
        }

        #endregion

        #region Test Helpers

        public static IEnumerable<Object> TestDataParametersForFailure()
        {
            yield return new GenericRange<Boolean>(true, false, true);

            yield return new GenericRange<SByte>(10, 30, 20);

            yield return new GenericRange<Byte>(10, 30, 20);

            yield return new GenericRange<Int16>(10, 30, 20);

            yield return new GenericRange<UInt16>(10, 30, 20);

            yield return new GenericRange<Int32>(10, 30, 20);

            yield return new GenericRange<UInt32>(10, 30, 20);

            yield return new GenericRange<Int64>(10, 30, 20);

            yield return new GenericRange<UInt64>(10, 30, 20);

            yield return new GenericRange<Int64>(10, 30, 20);

            yield return new GenericRange<UInt64>(10, 30, 20);

            yield return new GenericRange<Int128>(10, 30, 20);

            yield return new GenericRange<UInt128>(10, 30, 20);

            yield return new GenericRange<Single>(10.001F, 10.003F, 10.002F);

            yield return new GenericRange<Double>(10.001D, 10.003D, 10.002D);

            yield return new GenericRange<Decimal>(10.001M, 10.003M, 10.002M);

            yield return new GenericRange<DateTime>(DateTime.Parse("1967-10-29T17:23:05"), DateTime.Parse("2035-10-29T17:23:05"), DateTime.Parse("2024-10-29T17:23:05"));

            yield return new GenericRange<DateOnly>(DateOnly.Parse("1967-10-29"), DateOnly.Parse("2035-10-29"), DateOnly.Parse("2024-10-29"));

            yield return new GenericRange<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.003"), TimeOnly.Parse("17:23:05.002"));

            yield return new GenericRange<Guid>(Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));

            yield return new GenericRange<CustomData>(new CustomData(true), new CustomData(false), new CustomData(true));
        }

        public static IEnumerable<Object> TestDataParametersForSuccess()
        {
            yield return new GenericRange<Boolean>(false, false, true);
            yield return new GenericRange<Boolean>(false, true, true);

            yield return new GenericRange<SByte>(10, 20, 30);
            yield return new GenericRange<SByte>(10, 10, 30);
            yield return new GenericRange<SByte>(10, 30, 30);

            yield return new GenericRange<Byte>(10, 20, 30);
            yield return new GenericRange<Byte>(10, 10, 30);
            yield return new GenericRange<Byte>(10, 30, 30);

            yield return new GenericRange<Int16>(10, 20, 30);
            yield return new GenericRange<Int16>(10, 10, 30);
            yield return new GenericRange<Int16>(10, 30, 30);

            yield return new GenericRange<UInt16>(10, 20, 30);
            yield return new GenericRange<UInt16>(10, 10, 30);
            yield return new GenericRange<UInt16>(10, 30, 30);

            yield return new GenericRange<Int32>(10, 20, 30);
            yield return new GenericRange<Int32>(10, 10, 30);
            yield return new GenericRange<Int32>(10, 30, 30);

            yield return new GenericRange<UInt32>(10, 20, 30);
            yield return new GenericRange<UInt32>(10, 10, 30);
            yield return new GenericRange<UInt32>(10, 30, 30);

            yield return new GenericRange<Int64>(10, 20, 30);
            yield return new GenericRange<Int64>(10, 10, 30);
            yield return new GenericRange<Int64>(10, 30, 30);

            yield return new GenericRange<UInt64>(10, 20, 30);
            yield return new GenericRange<UInt64>(10, 10, 30);
            yield return new GenericRange<UInt64>(10, 30, 30);

            yield return new GenericRange<Int64>(10, 20, 30);
            yield return new GenericRange<Int64>(10, 10, 30);
            yield return new GenericRange<Int64>(10, 30, 30);

            yield return new GenericRange<UInt64>(10, 20, 30);
            yield return new GenericRange<UInt64>(10, 10, 30);
            yield return new GenericRange<UInt64>(10, 30, 30);

            yield return new GenericRange<Int128>(10, 20, 30);
            yield return new GenericRange<Int128>(10, 10, 30);
            yield return new GenericRange<Int128>(10, 30, 30);

            yield return new GenericRange<UInt128>(10, 20, 30);
            yield return new GenericRange<UInt128>(10, 10, 30);
            yield return new GenericRange<UInt128>(10, 30, 30);

            yield return new GenericRange<Single>(10.001F, 10.002F, 10.003F);
            yield return new GenericRange<Single>(10.001F, 10.001F, 10.003F);
            yield return new GenericRange<Single>(10.001F, 10.003F, 10.003F);

            yield return new GenericRange<Double>(10.001D, 10.002D, 10.003D);
            yield return new GenericRange<Double>(10.001D, 10.001D, 10.003D);
            yield return new GenericRange<Double>(10.001D, 10.003D, 10.003D);

            yield return new GenericRange<Decimal>(10.001M, 10.002M, 10.003M);
            yield return new GenericRange<Decimal>(10.001M, 10.001M, 10.003M);
            yield return new GenericRange<Decimal>(10.001M, 10.003M, 10.003M);

            yield return new GenericRange<DateTime>(DateTime.Parse("1967-10-29T17:23:05"), DateTime.Parse("2024-10-29T17:23:05"), DateTime.Parse("2035-10-29T17:23:05"));
            yield return new GenericRange<DateTime>(DateTime.Parse("1967-10-29T17:23:05"), DateTime.Parse("1967-10-29T17:23:05"), DateTime.Parse("2035-10-29T17:23:05"));
            yield return new GenericRange<DateTime>(DateTime.Parse("1967-10-29T17:23:05"), DateTime.Parse("2035-10-29T17:23:05"), DateTime.Parse("2035-10-29T17:23:05"));

            yield return new GenericRange<DateOnly>(DateOnly.Parse("1967-10-29"), DateOnly.Parse("2024-10-29"), DateOnly.Parse("2035-10-29"));
            yield return new GenericRange<DateOnly>(DateOnly.Parse("1967-10-29"), DateOnly.Parse("1967-10-29"), DateOnly.Parse("2035-10-29"));
            yield return new GenericRange<DateOnly>(DateOnly.Parse("1967-10-29"), DateOnly.Parse("2035-10-29"), DateOnly.Parse("2035-10-29"));

            yield return new GenericRange<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.002"), TimeOnly.Parse("17:23:05.003"));
            yield return new GenericRange<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.003"));
            yield return new GenericRange<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.003"), TimeOnly.Parse("17:23:05.003"));

            yield return new GenericRange<Guid>(Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));
            yield return new GenericRange<Guid>(Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));
            yield return new GenericRange<Guid>(Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"), Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));

            yield return new GenericRange<CustomData>(new CustomData(false), new CustomData(true), new CustomData(true));
        }

        #endregion

    }
}
