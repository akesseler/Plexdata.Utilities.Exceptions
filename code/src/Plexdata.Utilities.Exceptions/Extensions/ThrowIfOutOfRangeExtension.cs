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

using Plexdata.Utilities.Exceptions.Helpers;
using System;

namespace Plexdata.Utilities.Exceptions.Extensions
{
    /// <summary>
    /// Provides extension methods for range checks of types derived from <c>IComparable&lt;T&gt;</c>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for range checks. Each of the extension methods can only be used 
    /// with types derived from <c>IComparable&lt;T&gt;</c>.
    /// </remarks>
    /// <example>
    /// <para>
    /// The default exception of type <c>ArgumentOutOfRangeException</c> is thrown if the price is less than zero 
    /// or greater than 5,000.
    /// </para>
    /// <code>
    /// public void Process(Decimal price)
    /// {
    ///     price.ThrowIfOutOfRange(Decimal.Zero, 5000M, nameof(price), "Price must be between 0 and 5,000.");
    /// }
    /// </code>
    /// <para>
    /// An exception of type <c>ArgumentException</c> is thrown if the price is less than zero or greater than 5,000.
    /// </para>
    /// <code>
    /// public void Process(Decimal price)
    /// {
    ///     price.ThrowIfOutOfRange&lt;Decimal, ArgumentException&gt;(Decimal.Zero, 5000M, nameof(price), "Price must be between 0 and 5,000.");
    /// }
    /// </code>
    /// </example>
    public static class ThrowIfOutOfRangeExtension
    {
        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/> 
        /// and throws an <c>ArgumentOutOfRangeException</c> if so. An implicit null check is done as well.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object derived from <c>IComparable&lt;T&gt;</c>.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to check against.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to check against.
        /// </param>
        /// <param name="parameter">
        /// The name of affected call parameter.
        /// </param>
        /// <param name="message">
        /// The exception message to be used.
        /// </param>
        /// <returns>
        /// Returns the <paramref name="value"/> if no exception was thrown.
        /// </returns>
        /// <example>
        /// <para>
        /// The default exception of type <c>ArgumentOutOfRangeException</c> is thrown if the price is less than zero 
        /// or greater than 5,000.
        /// </para>
        /// <code>
        /// public void Process(Decimal price)
        /// {
        ///     price.ThrowIfOutOfRange(Decimal.Zero, 5000M, nameof(price), "Price must be between 0 and 5,000.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfOutOfRange<TValue>(this TValue value, TValue minimum, TValue maximum, String parameter = default, String message = default)
            where TValue : IComparable<TValue>
        {
            return value.ThrowIfOutOfRange<TValue, ArgumentOutOfRangeException>(minimum, maximum, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/> 
        /// and throws an exception of type <typeparamref name="TException"/> if so. An implicit null check is done as well.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object derived from <c>IComparable&lt;T&gt;</c>.
        /// </typeparam>
        /// <typeparam name="TException">
        /// Type of an exception to be thrown.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to check against.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to check against.
        /// </param>
        /// <param name="parameter">
        /// The name of affected call parameter.
        /// </param>
        /// <param name="message">
        /// The exception message to be used.
        /// </param>
        /// <returns>
        /// Returns the <paramref name="value"/> if no exception was thrown.
        /// </returns>
        /// <example>
        /// <para>
        /// An exception of type <c>ArgumentException</c> is thrown if the price is less than zero or greater than 5,000.
        /// </para>
        /// <code>
        /// public void Process(Decimal price)
        /// {
        ///     price.ThrowIfOutOfRange&lt;Decimal, ArgumentException&gt;(Decimal.Zero, 5000M, nameof(price), "Price must be between 0 and 5,000.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfOutOfRange<TValue, TException>(this TValue value, TValue minimum, TValue maximum, String parameter = default, String message = default)
            where TValue : IComparable<TValue>
            where TException : Exception
        {
            if (value == null || value.CompareTo(minimum) < 0 || value.CompareTo(maximum) > 0)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            return value;
        }
    }
}
