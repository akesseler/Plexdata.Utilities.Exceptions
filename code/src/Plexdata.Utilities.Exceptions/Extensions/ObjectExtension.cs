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

using Plexdata.Utilities.Exceptions.Defines;
using Plexdata.Utilities.Exceptions.Helpers;
using System;

namespace Plexdata.Utilities.Exceptions.Extensions
{
    /// <summary>
    /// Provides extension methods for null checking of values of type <see cref="Object"/>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for null checking of values of type <see cref="Object"/>.
    /// </remarks>
    /// <example>
    /// <para>
    /// This example throws an exception of type <c>ArgumentNullException</c> with default message, if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull();
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentNullException</c> with default message plus parameter name <em>data</em>, 
    /// if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull(nameof(data));
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentNullException</c> with message <em>Value of 'data' must not be null. (Parameter 'data')</em>, 
    /// if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull(nameof(data), $"Value of '{nameof(data)}' must not be null.");
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message, if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull&lt;ArgumentException&gt;();
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message plus parameter name <em>data</em>, 
    /// if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull&lt;ArgumentException&gt;(nameof(data));
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with message <em>Value of 'data' must not be null. (Parameter 'data')</em>, 
    /// if parameter <c>data</c> is null.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNull&lt;ArgumentException&gt;(nameof(data), $"Value of '{nameof(data)}' must not be null.");
    /// }
    /// </code>
    /// </example>
    public static class ObjectExtension
    {
        #region ThrowIfNull

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentNullException"/> if value of <paramref name="value"/> is null.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception is throw if <paramref name="value"/> is null.
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object, String)"/>
        /// <seealso cref="ThrowIfNull(Object, String, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String, String)"/>
        public static void ThrowIfNull(this Object value)
        {
            value.ThrowIfNull<ArgumentNullException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null. 
        /// Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object)"/>
        /// <seealso cref="ThrowIfNull(Object, String)"/>
        /// <seealso cref="ThrowIfNull(Object, String, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String, String)"/>
        public static void ThrowIfNull<TException>(this Object value) where TException : Exception
        {
            value.ThrowIfNull<TException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentNullException(String)"/> if value of <paramref name="value"/> is null. 
        /// The value of <paramref name="parameter"/> is used as parameter name.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null.
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object)"/>
        /// <seealso cref="ThrowIfNull(Object, String, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String, String)"/>
        public static void ThrowIfNull(this Object value, String parameter)
        {
            value.ThrowIfNull<ArgumentNullException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null. The value of <paramref name="parameter"/> is used as first constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking a string 
        /// as argument. This argument is initialized with value of <paramref name="parameter"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> null. Such an exception 
        /// must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object)"/>
        /// <seealso cref="ThrowIfNull(Object, String)"/>
        /// <seealso cref="ThrowIfNull(Object, String, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String, String)"/>
        public static void ThrowIfNull<TException>(this Object value, String parameter) where TException : Exception
        {
            value.ThrowIfNull<TException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentNullException(String, String)"/> if value of <paramref name="value"/> is null. 
        /// The value of <paramref name="parameter"/> is used as parameter name and the value of <paramref name="message"/> is used 
        /// as message.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception is throw if <paramref name="value"/> is null. 
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object)"/>
        /// <seealso cref="ThrowIfNull(Object, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String, String)"/>
        public static void ThrowIfNull(this Object value, String parameter, String message)
        {
            value.ThrowIfNull<ArgumentNullException>(parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null. The value of <paramref name="parameter"/> is used as first constructor argument and the value of 
        /// <paramref name="message"/> is used as second constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking two strings as 
        /// arguments, the first one for the <paramref name="parameter"/> and the second one for the <paramref name="message"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null. Such an exception 
        /// must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfNull(Object)"/>
        /// <seealso cref="ThrowIfNull(Object, String)"/>
        /// <seealso cref="ThrowIfNull(Object, String, String)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object)"/>
        /// <seealso cref="ThrowIfNull{TException}(Object, String)"/>
        public static void ThrowIfNull<TException>(this Object value, String parameter, String message) where TException : Exception
        {
            if (value == null)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion
    }
}
