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
    /// Provides extension methods for verification of values of type <see cref="Object"/>.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for verification of values of type <see cref="Object"/>. A callback is used that 
    /// performs the actual verification. This callback does not have any parameter and returns a <see cref="Boolean"/> as a 
    /// result.
    /// </remarks>
    /// <example>
    /// <para>
    /// Consider example class <c>Data</c> that is able to verify itself by implementing the parameterless method <c>IsValid()</c>. 
    /// This method is used as delegate callback in every call of extension method <c>ThrowIfNotVerified()</c> in these examples. 
    /// Alternatively, it is also possible to implement such a verification functionality either as class property or as an independent 
    /// delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
    /// </para>
    /// <code>
    /// public class Data { public Boolean IsValid() { return true; } }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentVerifyException</c> with default message, if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified(() => data.IsValid());
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentVerifyException</c> with default message plus parameter name <em>data</em>, 
    /// if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified(() => data.IsValid(), nameof(data));
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentVerifyException</c> with message <em>Value of 'data' must not be null or is invalid. (Parameter 'data')</em>, 
    /// if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified(() => data.IsValid(), nameof(data), $"Value of '{nameof(data)}' must not be null or is invalid.");
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message, if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified&lt;ArgumentException&gt;(() => data.IsValid());
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with default message plus parameter name <em>data</em>, 
    /// if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified&lt;ArgumentException&gt;(() => data.IsValid(), nameof(data));
    /// }
    /// </code>
    /// <para>
    /// This example throws an exception of type <c>ArgumentException</c> with message <em>Value of 'data' must not be null or is invalid. (Parameter 'data')</em>, 
    /// if parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified&lt;ArgumentException&gt;(() => data.IsValid(), nameof(data), $"Value of '{nameof(data)}' must not be null or is invalid.");
    /// }
    /// </code>
    /// </example>
    public static class VerifyExtension
    {
        #region ThrowIfNotVerified

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentVerifyException"/> if value of <paramref name="value"/> is null or if callback 
        /// <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c> 
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <exception cref="ArgumentVerifyException">
        /// This exception is thrown if <paramref name="value"/> fails its verification.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String, String)"/>
        public static void ThrowIfNotVerified(this Object value, Func<Boolean> verifier)
        {
            value.ThrowIfNotVerified<ArgumentVerifyException>(verifier, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> is null 
        /// or if callback <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c> 
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> fails its verification. 
        /// Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String, String)"/>
        public static void ThrowIfNotVerified<TException>(this Object value, Func<Boolean> verifier) where TException : Exception
        {
            value.ThrowIfNotVerified<TException>(verifier, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentVerifyException(String)"/> if value of <paramref name="value"/> is null or 
        /// if callback <paramref name="verifier"/> returns false.
        /// The value of <paramref name="parameter"/> is used as parameter name.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c>
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentVerifyException">
        /// This exception is thrown if <paramref name="value"/> fails its verification.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String, String)"/>
        public static void ThrowIfNotVerified(this Object value, Func<Boolean> verifier, String parameter)
        {
            value.ThrowIfNotVerified<ArgumentVerifyException>(verifier, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> is null 
        /// or if callback <paramref name="verifier"/> returns false.
        /// The value of <paramref name="parameter"/> is used as first constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c>
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking a string 
        /// as argument. This argument is initialized with value of <paramref name="parameter"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> fails its verification.
        /// Such an exception must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String, String)"/>
        public static void ThrowIfNotVerified<TException>(this Object value, Func<Boolean> verifier, String parameter) where TException : Exception
        {
            value.ThrowIfNotVerified<TException>(verifier, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentVerifyException(String, String)"/> if value of <paramref name="value"/> is 
        /// null or if callback <paramref name="verifier"/> returns false. The value of <paramref name="parameter"/> is used as 
        /// parameter name and the value of <paramref name="message"/> is used as message.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c> 
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <exception cref="ArgumentVerifyException">
        /// This exception is thrown if <paramref name="value"/> fails its verification.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String, String)"/>
        public static void ThrowIfNotVerified(this Object value, Func<Boolean> verifier, String parameter, String message)
        {
            value.ThrowIfNotVerified<ArgumentVerifyException>(verifier, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if callback <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> is 
        /// null or if callback <paramref name="verifier"/> returns false. The value of <paramref name="parameter"/> is used as 
        /// first constructor argument and the value of <paramref name="message"/> is used as second constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be verified.
        /// </param>
        /// <param name="verifier">
        /// A callback that performs the actual verification. Such a callback can be either a method like <c>Boolean IsValid()</c>
        /// or a property like <c>Boolean IsValid { get; }</c> or an independent delegate like <c>Func&lt;Boolean&gt; verifier = delegate {...};</c>.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking two strings as 
        /// arguments, the first one for the <paramref name="parameter"/> and the second one for the <paramref name="message"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> fails its verification.
        /// Such an exception must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ObjectExtension.ThrowIfNull{TException}(Object, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String)"/>
        /// <seealso cref="ThrowIfNotVerified(Object, Func{Boolean}, String, String)"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean})"/>
        /// <seealso cref="ThrowIfNotVerified{TException}(Object, Func{Boolean}, String)"/>
        public static void ThrowIfNotVerified<TException>(this Object value, Func<Boolean> verifier, String parameter, String message) where TException : Exception
        {
            value.ThrowIfNull<TException>(parameter, message);

            try
            {
                if (!verifier())
                {
                    throw ExceptionHelper.CreateException<TException>(parameter, message);
                }
            }
            catch (NullReferenceException exception)
            {
                // This should actually be an exception and not the rule!
                // All other exceptions must be handled by the user.
                throw ExceptionHelper.CreateException<TException>(nameof(verifier), exception.Message);
            }
        }

        #endregion
    }
}
