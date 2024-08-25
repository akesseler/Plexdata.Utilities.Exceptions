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
    /// Provides extension methods for verification of values of any type.
    /// </summary>
    /// <remarks>
    /// This class provides extension methods for verification of values of any type. A delegate is used 
    /// to performs the actual verification action. This delegate returns a <c>Boolean</c> as a result.
    /// </remarks>
    /// <example>
    /// <para>
    /// Consider the example class <c>Data</c> that is able to verify itself by implementing a parameterless method 
    /// <c>IsValid()</c>. This method is used as delegate in the call of the extension method <c>ThrowIfNotVerified()</c>. 
    /// </para>
    /// <code>
    /// public class Data { public Boolean IsValid() { return true; } }
    /// </code>
    /// <para>
    /// This example throws an exception of type <see cref="ArgumentVerifyException"/> with default message, if 
    /// parameter <c>data</c> is null or not verified.
    /// </para>
    /// <code>
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified(() => data.IsValid());
    /// }
    /// </code>
    /// <para>
    /// Alternatively, it is also possible to implement such a verification functionality as an independent method as 
    /// shown here.
    /// </para>
    /// <code>
    /// private Boolean Verify(Data data)
    /// {
    ///     return true;
    /// }
    /// 
    /// public void Process(Data data)
    /// {
    ///     data.ThrowIfNotVerified(() => this.Verify(data));
    /// }
    /// </code>
    /// </example>
    public static class ThrowIfNotVerifiedExtension
    {
        #region Typed object and parameterless verifier

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if the delegate <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentVerifyException"/> if <paramref name="value"/> is null or if the 
        /// delegate <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object to be verified.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="verifier">
        /// A parameterless delegate performing the actual verification.
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
        /// The default exception of type <see cref="ArgumentVerifyException"/> is thrown if verification failed.
        /// </para>
        /// <code>
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNotVerified(() => { return true; }, nameof(data), "Data could not be verified.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNotVerified<TValue>(this TValue value, Func<Boolean> verifier, String parameter = default, String message = default)
        {
            return value.ThrowIfNotVerified<TValue, ArgumentVerifyException>(verifier, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if the delegate <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if <paramref name="value"/> is 
        /// null or if the delegate <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object to be verified.
        /// </typeparam>
        /// <typeparam name="TException">
        /// Type of an exception to be thrown.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="verifier">
        /// A parameterless delegate performing the actual verification.
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
        /// Am exception of type <c>ArgumentException</c> is thrown if verification failed.
        /// </para>
        /// <code>
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNotVerified&lt;Data, ArgumentException&gt;(() => { return true; }, nameof(data), "Data could not be verified.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNotVerified<TValue, TException>(this TValue value, Func<Boolean> verifier, String parameter = default, String message = default)
            where TException : Exception
        {
            if (value == null)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            try
            {
                if (!verifier())
                {
                    throw ExceptionHelper.CreateException<TException>(parameter, message);
                }

                return value;
            }
            catch (NullReferenceException exception)
            {
                // This should actually be an exception and not the rule!
                // All other exceptions must be handled by the user.
                throw ExceptionHelper.CreateException<TException>(nameof(verifier), exception.Message);
            }
        }

        #endregion

        #region Typed object and parameterized verifier

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if the delegate <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentVerifyException"/> if <paramref name="value"/> is null or if the 
        /// delegate <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object to be verified.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="verifier">
        /// A parameterized delegate performing the actual verification.
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
        /// The default exception of type <see cref="ArgumentVerifyException"/> is thrown if verification failed.
        /// </para>
        /// <code>
        /// private Boolean Verify(Data data)
        /// {
        ///     return true;
        /// }
        /// 
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNotVerified(() => this.Verify(data), nameof(data), "Data could not be verified.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNotVerified<TValue>(this TValue value, Func<TValue, Boolean> verifier, String parameter = default, String message = default)
        {
            return value.ThrowIfNotVerified<TValue, ArgumentVerifyException>(verifier, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is null or if the delegate <paramref name="verifier"/> returns false.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if <paramref name="value"/> is 
        /// null or if the delegate <paramref name="verifier"/> returns false.
        /// </remarks>
        /// <typeparam name="TValue">
        /// Type of an object to be verified.
        /// </typeparam>
        /// <typeparam name="TException">
        /// Type of an exception to be thrown.
        /// </typeparam>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="verifier">
        /// A parameterized delegate performing the actual verification.
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
        /// An exception of type <c>ArgumentException</c> is thrown if verification failed.
        /// </para>
        /// <code>
        /// private Boolean Verify(Data data)
        /// {
        ///     return true;
        /// }
        /// 
        /// public void Process(Data data)
        /// {
        ///     data.ThrowIfNotVerified&lt;Data, ArgumentException&gt;(() => this.Verify(data), nameof(data), "Data could not be verified.");
        /// }
        /// </code>
        /// </example>
        public static TValue ThrowIfNotVerified<TValue, TException>(this TValue value, Func<TValue, Boolean> verifier, String parameter = default, String message = default)
            where TException : Exception
        {
            if (value == null)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }

            try
            {
                if (!verifier(value))
                {
                    throw ExceptionHelper.CreateException<TException>(parameter, message);
                }

                return value;
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
