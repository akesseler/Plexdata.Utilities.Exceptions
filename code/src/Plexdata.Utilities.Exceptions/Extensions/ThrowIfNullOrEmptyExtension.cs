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
    /// Provides extension methods for null and empty checks of values of type <c>String</c>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for null and empty checks of values of type <c>String</c>.
    /// </remarks>
    /// <example>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with default message, 
    /// if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public void Process(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty();
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message, if parameter 
    /// <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public void Process(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty&lt;ArgumentException&gt;();
    /// }
    /// </code>
    /// </example>
    public static class ThrowIfNullOrEmptyExtension
    {
        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an <c>ArgumentOutOfRangeException</c> if <paramref name="value"/> is null or 
        /// empty.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
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
        /// The default exception of type <c>ArgumentOutOfRangeException</c> is thrown if the name is null or 
        /// empty.
        /// </para>
        /// <code>
        /// public void Process(String name)
        /// {
        ///     name.ThrowIfNullOrEmpty(nameof(name), "The name must not be null or empty.");
        /// }
        /// </code>
        /// </example>
        public static String ThrowIfNullOrEmpty(this String value, String parameter = default, String message = default)
        {
            return value.ThrowIfNullOrEmpty<ArgumentOutOfRangeException>(parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if <paramref name="value"/> is null
        /// or empty.
        /// </remarks>
        /// <typeparam name="TException">
        /// Type of an exception to be thrown.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
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
        /// An exception of type <c>ArgumentException</c> is thrown if the name is null or empty.
        /// </para>
        /// <code>
        /// public void Process(String name)
        /// {
        ///     name.ThrowIfNullOrEmpty&lt;ArgumentException&gt;(nameof(name), "The name must not be null or empty.");
        /// }
        /// </code>
        /// </example>
        public static String ThrowIfNullOrEmpty<TException>(this String value, String parameter = default, String message = default)
            where TException : Exception
        {
            if (String.IsNullOrEmpty(value))
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            return value;
        }
    }
}
