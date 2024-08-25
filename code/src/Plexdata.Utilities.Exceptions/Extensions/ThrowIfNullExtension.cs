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
    /// Provides extension methods for null checks for any type of object.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for null checks for any type of object. Each of the extension 
    /// methods does not have any limitation.
    /// </remarks>
    /// <example>
    /// <para>
    /// The default exception of type <c>ArgumentNullException</c> is thrown if the data model is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull(nameof(data), "The data model must not be null.");
    /// }
    /// </code>
    /// <para>
    /// An exception of type <c>ArgumentException</c> is thrown if the data model is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull&lt;Data, ArgumentException&gt;(nameof(data), "The data model must not be null.");
    /// }
    /// </code>
    /// </example>
    public static class ThrowIfNullExtension
    {
        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is null and throws an <c>ArgumentNullException</c> if so.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Any type of an object.
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
        /// The default exception of type <c>ArgumentNullException</c> is thrown if the data model is null.
        /// </para>
        /// <code>
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNull(nameof(data), "The data model must not be null.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNull<TValue>(this TValue value, String parameter = default, String message = default)
        {
            return value.ThrowIfNull<TValue, ArgumentNullException>(parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method checks if <paramref name="value"/> is null and throws an exception of type <typeparamref name="TException"/> if so.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Any type of an object.
        /// </typeparam>
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
        /// An exception of type <c>ArgumentException</c> is thrown if the data model is null.
        /// </para>
        /// <code>
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNull&lt;Data, ArgumentException&gt;(nameof(data), "The data model must not be null.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNull<TValue, TException>(this TValue value, String parameter = default, String message = default)
            where TException : Exception
        {
            if (value == null)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            return value;
        }
    }
}
