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
    public class ThrowIfEqualToExtensionTests
    {
        #region StandardOverload

        [TestCaseSource(nameof(TestDataParametersForFailure))]
        public void StandardOverload_ParametersAsProvided_ThrowsArgumentOutOfRangeException<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfEqualTo(source.Other), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void StandardOverload_ParametersAsProvided_ThrowsNothing<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfEqualTo(source.Other), Throws.Nothing);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void StandardOverload_ParametersAsProvided_ResultAsExpected<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(source.Value.ThrowIfEqualTo(source.Other), Is.EqualTo(source.Value));
        }

        #endregion

        #region ExceptionOverload

        [TestCaseSource(nameof(TestDataParametersForFailure))]
        public void ExceptionOverload_ParametersAsProvided_ThrowsArgumentException<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfEqualTo<T, ArgumentException>(source.Other), Throws.ArgumentException);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void ExceptionOverload_ParametersAsProvided_ThrowsNothing<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(() => source.Value.ThrowIfEqualTo<T, ArgumentException>(source.Other), Throws.Nothing);
        }

        [TestCaseSource(nameof(TestDataParametersForSuccess))]
        public void ExceptionOverload_ParametersAsProvided_ResultAsExpected<T>(GenericType<T> source) where T : IComparable<T>, IEquatable<T>
        {
            Assert.That(source.Value.ThrowIfEqualTo<T, ArgumentException>(source.Other), Is.EqualTo(source.Value));
        }

        #endregion

        #region Test Helpers

        public static IEnumerable<Object> TestDataParametersForFailure()
        {
            yield return new GenericType<Boolean>(true, true);

            yield return new GenericType<SByte>(10, 10);

            yield return new GenericType<Byte>(10, 10);

            yield return new GenericType<Int16>(10, 10);

            yield return new GenericType<UInt16>(10, 10);

            yield return new GenericType<Int32>(10, 10);

            yield return new GenericType<UInt32>(10, 10);

            yield return new GenericType<Int64>(10, 10);

            yield return new GenericType<UInt64>(10, 10);

            yield return new GenericType<Int64>(10, 10);

            yield return new GenericType<UInt64>(10, 10);

            yield return new GenericType<Int128>(10, 10);

            yield return new GenericType<UInt128>(10, 10);

            yield return new GenericType<Single>(10.001F, 10.001F);

            yield return new GenericType<Double>(10.001D, 10.001D);

            yield return new GenericType<Decimal>(10.001M, 10.001M);

            yield return new GenericType<DateTime>(DateTime.Parse("2024-10-29T17:23:05"), DateTime.Parse("2024-10-29T17:23:05"));

            yield return new GenericType<DateOnly>(DateOnly.Parse("2024-10-29"), DateOnly.Parse("2024-10-29"));

            yield return new GenericType<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.001"));

            yield return new GenericType<Guid>(Guid.Parse("00112233-4455-6677-8899-AABBCCDDEEFF"), Guid.Parse("00112233-4455-6677-8899-AABBCCDDEEFF"));

            yield return new GenericType<CustomData>(new CustomData(true), new CustomData(true));
        }

        public static IEnumerable<Object> TestDataParametersForSuccess()
        {
            yield return new GenericType<Boolean>(true, false);

            yield return new GenericType<SByte>(10, 20);

            yield return new GenericType<Byte>(10, 20);

            yield return new GenericType<Int16>(10, 20);

            yield return new GenericType<UInt16>(10, 20);

            yield return new GenericType<Int32>(10, 20);

            yield return new GenericType<UInt32>(10, 20);

            yield return new GenericType<Int64>(10, 20);

            yield return new GenericType<UInt64>(10, 20);

            yield return new GenericType<Int64>(10, 20);

            yield return new GenericType<UInt64>(10, 20);

            yield return new GenericType<Int128>(10, 20);

            yield return new GenericType<UInt128>(10, 20);

            yield return new GenericType<Single>(10.001F, 10.002F);

            yield return new GenericType<Double>(10.001D, 10.002D);

            yield return new GenericType<Decimal>(10.001M, 10.002M);

            yield return new GenericType<DateTime>(DateTime.Parse("2024-10-29T17:23:05"), DateTime.Parse("1967-10-29T17:23:05"));

            yield return new GenericType<DateOnly>(DateOnly.Parse("2024-10-29"), DateOnly.Parse("1967-10-29"));

            yield return new GenericType<TimeOnly>(TimeOnly.Parse("17:23:05.001"), TimeOnly.Parse("17:23:05.002"));

            yield return new GenericType<Guid>(Guid.Parse("00112233-4455-6677-8899-AABBCCDDEEFF"), Guid.Parse("FFEEDDCC-BBAA-9988-7766-554433221100"));

            yield return new GenericType<CustomData>(new CustomData(true), new CustomData(false));
        }

        #endregion
    }
}
