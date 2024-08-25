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
using System.Collections.Generic;

namespace Plexdata.Utilities.Exceptions.Extensions
{
    /// <summary>
    /// Provides extension methods for equal checks of types derived from <c>IEquatable&lt;T&gt;</c>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for equal checks. Each of the extension methods can only be used 
    /// with types derived from <c>IEquatable&lt;T&gt;</c>.
    /// </remarks>
    /// <example>
    /// <para>
    /// The default exception of type <c>ArgumentOutOfRangeException</c> is thrown if the price is zero.
    /// </para>
    /// <code>
    /// public void Process(Decimal price)
    /// {
    ///     price.ThrowIfEqualTo(Decimal.Zero, nameof(price), "Price must not be zero.");
    /// }
    /// </code>
    /// <para>
    /// An exception of type <c>ArgumentException</c> is thrown if the price is zero.
    /// </para>
    /// <code>
    /// public void Process(Decimal price)
    /// {
    ///     price.ThrowIfEqualTo&lt;Decimal, ArgumentException&gt;(Decimal.Zero, nameof(price), "Price must not be zero.");
    /// }
    /// </code>
    /// </example>
    public static class ThrowIfEqualToExtension
    {
        /// <summary>
        /// Checks if <paramref name="value"/> is equal to <paramref name="other"/>.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is equal to <paramref name="other"/> and throws an 
        /// <c>ArgumentOutOfRangeException</c> if so.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object derived from <c>IEquatable&lt;T&gt;</c>.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="other">
        /// The value to check against.
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
        /// The default exception of type <c>ArgumentOutOfRangeException</c> is thrown if the price not is zero.
        /// </para>
        /// <code>
        /// public void Process(Decimal price)
        /// {
        ///     price.ThrowIfEqualTo(Decimal.Zero, nameof(price), "Price must not be zero.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfEqualTo<TValue>(this TValue value, TValue other, String parameter = default, String message = default)
            where TValue : IEquatable<TValue>
        {
            return value.ThrowIfEqualTo<TValue, ArgumentOutOfRangeException>(other, parameter, message);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is equal to <paramref name="other"/>.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is equal to <paramref name="other"/> and throws an 
        /// exception of type <typeparamref name="TException"/> if so.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object derived from <c>IEquatable&lt;T&gt;</c>.
        /// </typeparam>
        /// <typeparam name="TException">
        /// Type of an exception to be thrown.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="other">
        /// The value to check against.
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
        /// An exception of type <c>ArgumentException</c> is thrown if the price is zero.
        /// </para>
        /// <code>
        /// public void Process(Decimal price)
        /// {
        ///     price.ThrowIfEqualTo&lt;Decimal, ArgumentException&gt;(Decimal.Zero, nameof(price), "Price must not be zero.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfEqualTo<TValue, TException>(this TValue value, TValue other, String parameter = default, String message = default)
            where TValue : IEquatable<TValue>
            where TException : Exception
        {
            if (EqualityComparer<TValue>.Default.Equals(value, other))
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            return value;
        }
    }
}
