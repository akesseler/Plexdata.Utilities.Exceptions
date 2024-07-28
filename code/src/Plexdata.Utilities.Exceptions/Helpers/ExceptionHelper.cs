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

using System;

namespace Plexdata.Utilities.Exceptions.Helpers
{
    /// <summary>
    /// Helper class to create exceptions.
    /// </summary>
    /// <remarks>
    /// This class serves as helper to create exceptions.
    /// </remarks>
    internal static class ExceptionHelper
    {
        #region Public Members

        /// <summary>
        /// Creates an exception of specified type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method creates an exception of specified type using <paramref name="parameter"/> 
        /// and <paramref name="message"/> if possible.
        /// </para>
        /// <para>
        /// Every exception of type <typeparamref name="TException"/> should have a constructor 
        /// with two strings, like <see cref="ArgumentNullException(String, String)"/> for example. 
        /// The first string should represent the parameter name and the second string should 
        /// represent the message text.
        /// </para>
        /// <para>
        /// The value of <paramref name="message"/> (if valid) is used if an exception of type 
        /// <typeparamref name="TException"/> has only a constructor with one single string. 
        /// Otherwise, the value of <paramref name="parameter"/> (if valid) might be used as 
        /// message text.
        /// </para>
        /// <para>
        /// A note about <see cref="ArgumentException(String, String)"/>. The values ​​of the arguments
        /// <paramref name="parameter"/> and <paramref name="message"/> are swapped automatically.
        /// </para>
        /// </remarks>
        /// <typeparam name="TException">
        /// The type of exception to create.
        /// </typeparam>
        /// <param name="parameter">
        /// The name of the parameter that caused the exception.
        /// </param>
        /// <param name="message">
        /// The error message that explains the reason for this exception.
        /// </param>
        /// <returns>
        /// An instance of an exception of type <typeparamref name="TException"/>.
        /// </returns>
        public static TException CreateException<TException>(String parameter, String message) where TException : Exception
        {
            try
            {
                parameter = parameter.GetStringOrDefault();
                message = message.GetStringOrDefault();

                if (parameter == null && message == null)
                {
                    if (typeof(TException) == typeof(ArgumentException))
                    {
                        return new ArgumentException() as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentNullException))
                    {
                        return new ArgumentNullException() as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                    {
                        return new ArgumentOutOfRangeException() as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentVerifyException))
                    {
                        return new ArgumentVerifyException() as TException;
                    }

                    return (TException)Activator.CreateInstance(typeof(TException));
                }
                else if (parameter != null && message == null)
                {
                    if (typeof(TException) == typeof(ArgumentException))
                    {
                        return new ArgumentException(null, parameter) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentNullException))
                    {
                        return new ArgumentNullException(parameter) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                    {
                        return new ArgumentOutOfRangeException(parameter) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentVerifyException))
                    {
                        return new ArgumentVerifyException(parameter) as TException;
                    }

                    // BUG: Unfortunately, this can lead to exceptions with unclear error messages.
                    return (TException)Activator.CreateInstance(typeof(TException), new Object[] { parameter });
                }
                else if (parameter == null && message != null)
                {
                    if (typeof(TException) == typeof(ArgumentException))
                    {
                        return new ArgumentException(message) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentNullException))
                    {
                        return new ArgumentNullException(null, message) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                    {
                        return new ArgumentOutOfRangeException(null, message) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentVerifyException))
                    {
                        return new ArgumentVerifyException(null, message) as TException;
                    }

                    return (TException)Activator.CreateInstance(typeof(TException), new Object[] { message });
                }
                else
                {
                    if (typeof(TException) == typeof(ArgumentException))
                    {
                        return new ArgumentException(message, parameter) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentNullException))
                    {
                        return new ArgumentNullException(parameter, message) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                    {
                        return new ArgumentOutOfRangeException(parameter, message) as TException;
                    }

                    if (typeof(TException) == typeof(ArgumentVerifyException))
                    {
                        return new ArgumentVerifyException(parameter, message) as TException;
                    }

                    return (TException)Activator.CreateInstance(typeof(TException), new Object[] { parameter, message });
                }
            }
            catch (MissingMemberException)
            {
                try
                {
                    return (TException)Activator.CreateInstance(typeof(TException), new Object[] { message });
                }
                catch (MissingMemberException)
                {
                    return (TException)Activator.CreateInstance(typeof(TException));
                }
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Returns the string or null as default.
        /// </summary>
        /// <remarks>
        /// This method returns the string or null as default if <paramref name="value"/> is null, empty 
        /// or whitespace.
        /// </remarks>
        /// <param name="value">
        /// The value to be normalized.
        /// </param>
        /// <returns>
        /// The normalized value.
        /// </returns>
        private static String GetStringOrDefault(this String value)
        {
            return String.IsNullOrWhiteSpace(value) ? null : value;
        }

        #endregion
    }
}
