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
    /// Provides extension methods for null, empty and whitespace checking of values of type <see cref="String"/>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for null, empty and whitespace checking of values of type <see cref="String"/>.
    /// </remarks>
    /// <example>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with default message, if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty();
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with default message plus parameter name <em>name</em>, 
    /// if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty(nameof(name));
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with message <em>Value of 'name' must not be null. (Parameter 'name')</em>, 
    /// if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty(nameof(name), $"Value of '{nameof(name)}' must not be null.");
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message, if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty&lt;ArgumentException&gt;();
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message plus parameter name <em>name</em>, if parameter <c>name</c> 
    /// is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty&lt;ArgumentException&gt;(nameof(name));
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with message <em>Value of 'name' must not be null. (Parameter 'name')</em>, 
    /// if parameter <c>name</c> is null or empty.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrEmpty&lt;ArgumentException&gt;(nameof(name), $"Value of '{nameof(name)}' must not be null.");
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with default message, if parameter <c>name</c> 
    /// is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace();
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with default message plus parameter name <em>name</em>, 
    /// if parameter <c>name</c> is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace(nameof(name));
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentOutOfRangeException</c> with message <em>Value of 'name' must not be null. (Parameter 'name')</em>, 
    /// if parameter <c>name</c> is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace(nameof(name), $"Value of '{nameof(name)}' must not be null.");
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message, if parameter <c>name</c> 
    /// is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace&lt;ArgumentException&gt;();
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message plus parameter name <em>name</em>, 
    /// if parameter <c>name</c> is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace&lt;ArgumentException&gt;(nameof(name));
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with message <em>Value of 'name' must not be null. (Parameter 'name')</em>, 
    /// if parameter <c>name</c> is null or empty or whitespace.
    /// </para>
    /// <code>
    /// public String Transform(String name)
    /// {
    ///     name.ThrowIfNullOrWhiteSpace&lt;ArgumentException&gt;(nameof(name), $"Value of '{nameof(name)}' must not be null.");
    ///     name.ToUpper();
    ///     return name;
    /// }
    /// </code>
    /// </example>
    public static class StringExtension
    {
        #region ThrowIfNullOrEmpty

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException"/> if value of <paramref name="value"/> is null or 
        /// empty.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String, String)"/>
        public static void ThrowIfNullOrEmpty(this String value)
        {
            value.ThrowIfNullOrEmpty<ArgumentOutOfRangeException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null or empty. 
        /// Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String, String)"/>
        public static void ThrowIfNullOrEmpty<TException>(this String value) where TException : Exception
        {
            value.ThrowIfNullOrEmpty<TException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String)"/> if value of <paramref name="value"/> is 
        /// null or empty. The value of <paramref name="parameter"/> is used as parameter name.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String, String)"/>
        public static void ThrowIfNullOrEmpty(this String value, String parameter)
        {
            value.ThrowIfNullOrEmpty<ArgumentOutOfRangeException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty. The value of <paramref name="parameter"/> is used as first constructor argument.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> null or empty. Such 
        /// an exception must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String, String)"/>
        public static void ThrowIfNullOrEmpty<TException>(this String value, String parameter) where TException : Exception
        {
            value.ThrowIfNullOrEmpty<TException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String, String)"/> if value of <paramref name="value"/> 
        /// is null or empty. The value of <paramref name="parameter"/> is used as parameter name and the value of <paramref name="message"/> 
        /// is used as message.
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty. 
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String, String)"/>
        public static void ThrowIfNullOrEmpty(this String value, String parameter, String message)
        {
            value.ThrowIfNullOrEmpty<ArgumentOutOfRangeException>(parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty. The value of <paramref name="parameter"/> is used as first constructor argument and the value of 
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null or empty. Such an 
        /// exception must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrEmpty(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrEmpty{TException}(String, String)"/>
        public static void ThrowIfNullOrEmpty<TException>(this String value, String parameter, String message) where TException : Exception
        {
            if (String.IsNullOrEmpty(value))
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion

        #region ThrowIfNullOrWhiteSpace

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException"/> if value of <paramref name="value"/> is null or empty 
        /// or whitespace.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty or whitespace.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String, String)"/>
        public static void ThrowIfNullOrWhiteSpace(this String value)
        {
            value.ThrowIfNullOrWhiteSpace<ArgumentOutOfRangeException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty or whitespace.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null or empty or 
        /// whitespace. Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String, String)"/>
        public static void ThrowIfNullOrWhiteSpace<TException>(this String value) where TException : Exception
        {
            value.ThrowIfNullOrWhiteSpace<TException>(Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String)"/> if value of <paramref name="value"/> is null
        /// or empty or whitespace. The value of <paramref name="parameter"/> is used as parameter name.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty or whitespace.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String, String)"/>
        public static void ThrowIfNullOrWhiteSpace(this String value, String parameter)
        {
            value.ThrowIfNullOrWhiteSpace<ArgumentOutOfRangeException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty or whitespace. The value of <paramref name="parameter"/> is used as first constructor argument.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> null or empty or whitespace.
        /// Such an exception must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String, String)"/>
        public static void ThrowIfNullOrWhiteSpace<TException>(this String value, String parameter) where TException : Exception
        {
            value.ThrowIfNullOrWhiteSpace<TException>(parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String, String)"/> if value of <paramref name="value"/> 
        /// is null or empty or whitespace. The value of <paramref name="parameter"/> is used as parameter name and the value of 
        /// <paramref name="message"/> is used as message.
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is null or empty or whitespace. 
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String, String)"/>
        public static void ThrowIfNullOrWhiteSpace(this String value, String parameter, String message)
        {
            value.ThrowIfNullOrWhiteSpace<ArgumentOutOfRangeException>(parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or empty or whitespace.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is null or empty or whitespace. The value of <paramref name="parameter"/> is used as first constructor argument and 
        /// the value of <paramref name="message"/> is used as second constructor argument.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is null or empty or whitespace.
        /// Such an exception must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace(String, String, String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String)"/>
        /// <seealso cref="ThrowIfNullOrWhiteSpace{TException}(String, String)"/>
        public static void ThrowIfNullOrWhiteSpace<TException>(this String value, String parameter, String message) where TException : Exception
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion
    }
}
