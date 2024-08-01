﻿/*
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
    /// Provides extension methods for range checking of values of type <see cref="DateTime"/>.
    /// </summary>
    /// <remarks>
    /// This class Provides extension methods for range checking of values of type <see cref="DateTime"/>, 
    /// such as <i>less than</i>, <i>greater than</i> or <i>out of range</i>.
    /// </remarks>
    /// <example>
    /// <para>
    /// The extension methods <c>ThrowIfLessThan(...)</c>, <c>ThrowIfGreaterThan(...)</c> and <c>ThrowIfOutOfRange(...)</c> here 
    /// work in the same way as the extension methods <c>ThrowIfNullOrEmpty(...)</c> and <c>ThrowIfNullOrWhiteSpace(...)</c>, except 
    /// additional parameters <c>minimum</c> and/or <c>maximum</c> are necessary. Therefore, have look at section <em>Examples</em> 
    /// at class <see cref="StringExtension"/>.
    /// </para>
    /// </example>
    public static class DateExtension
    {
        #region ThrowIfLessThan

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfLessThan(this DateTime value, DateTime minimum)
        {
            value.ThrowIfLessThan<ArgumentOutOfRangeException>(minimum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/>. Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfLessThan<TException>(this DateTime value, DateTime minimum) where TException : Exception
        {
            value.ThrowIfLessThan<TException>(minimum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String)"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>. The value of <paramref name="parameter"/> is used as parameter 
        /// name.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfLessThan(this DateTime value, DateTime minimum, String parameter)
        {
            value.ThrowIfLessThan<ArgumentOutOfRangeException>(minimum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>. The value of <paramref name="parameter"/> is used as first 
        /// constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking a string 
        /// as argument. This argument is initialized with value of <paramref name="parameter"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/>. Such an exception must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfLessThan<TException>(this DateTime value, DateTime minimum, String parameter) where TException : Exception
        {
            value.ThrowIfLessThan<TException>(minimum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String, String)"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>. The value of <paramref name="parameter"/> is used as parameter 
        /// name and the value of <paramref name="message"/> is used as message.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfLessThan(this DateTime value, DateTime minimum, String parameter, String message)
        {
            value.ThrowIfLessThan<ArgumentOutOfRangeException>(minimum, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/>. The value of <paramref name="parameter"/> is used as first 
        /// constructor argument and the value of <paramref name="message"/> is used as second constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/>. Such an exception must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfLessThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfLessThan{TException}(DateTime, DateTime, String)"/>
        public static void ThrowIfLessThan<TException>(this DateTime value, DateTime minimum, String parameter, String message) where TException : Exception
        {
            if (value < minimum)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion

        #region ThrowIfGreaterThan

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is greater than <paramref name="maximum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfGreaterThan(this DateTime value, DateTime maximum)
        {
            value.ThrowIfGreaterThan<ArgumentOutOfRangeException>(maximum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is greater than 
        /// <paramref name="maximum"/>. Such an exception must have at least one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfGreaterThan<TException>(this DateTime value, DateTime maximum) where TException : Exception
        {
            value.ThrowIfGreaterThan<TException>(maximum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String)"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>. The value of <paramref name="parameter"/> is used as 
        /// parameter name.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is greater than <paramref name="maximum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfGreaterThan(this DateTime value, DateTime maximum, String parameter)
        {
            value.ThrowIfGreaterThan<ArgumentOutOfRangeException>(maximum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>. The value of <paramref name="parameter"/> is used as 
        /// first constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking a string 
        /// as argument. This argument is initialized with value of <paramref name="parameter"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is greater than 
        /// <paramref name="maximum"/>. Such an exception must have at least one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfGreaterThan<TException>(this DateTime value, DateTime maximum, String parameter) where TException : Exception
        {
            value.ThrowIfGreaterThan<TException>(maximum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String, String)"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>. The value of <paramref name="parameter"/> is used as parameter 
        /// name and the value of <paramref name="message"/> is used as message.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is greater than <paramref name="maximum"/>. 
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String, String)"/>
        public static void ThrowIfGreaterThan(this DateTime value, DateTime maximum, String parameter, String message)
        {
            value.ThrowIfGreaterThan<ArgumentOutOfRangeException>(maximum, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is greater than value of <paramref name="maximum"/>. The value of <paramref name="parameter"/> is used as 
        /// first constructor argument and the value of <paramref name="message"/> is used as second constructor argument.
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is greater than 
        /// <paramref name="maximum"/>. Such an exception must have at least one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfGreaterThan(DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfGreaterThan{TException}(DateTime, DateTime, String)"/>
        public static void ThrowIfGreaterThan<TException>(this DateTime value, DateTime maximum, String parameter, String message) where TException : Exception
        {
            if (value > maximum)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion

        #region ThrowIfOutOfRange

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an <see cref="ArgumentOutOfRangeException"/> if value of <paramref name="value"/> is less than 
        /// value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String, String)"/>
        public static void ThrowIfOutOfRange(this DateTime value, DateTime minimum, DateTime maximum)
        {
            value.ThrowIfOutOfRange<ArgumentOutOfRangeException>(minimum, maximum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least a default constructor.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/> or greater than <paramref name="maximum"/>.Such an exception must have at least 
        /// one public default constructor.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String, String)"/>
        public static void ThrowIfOutOfRange<TException>(this DateTime value, DateTime minimum, DateTime maximum) where TException : Exception
        {
            value.ThrowIfOutOfRange<TException>(minimum, maximum, Constants.NullString, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String)"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>. The value 
        /// of <paramref name="parameter"/> is used as parameter name.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String, String)"/>
        public static void ThrowIfOutOfRange(this DateTime value, DateTime minimum, DateTime maximum, String parameter)
        {
            value.ThrowIfOutOfRange<ArgumentOutOfRangeException>(minimum, maximum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>. The value 
        /// of <paramref name="parameter"/> is used as first constructor argument.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <typeparam name="TException">
        /// The type of the exception to be thrown. Such an exception should have at least one constructor taking a string 
        /// as argument. This argument is initialized with value of <paramref name="parameter"/>.
        /// </typeparam>
        /// <exception cref="Exception">
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/> or greater than <paramref name="maximum"/>. Such an exception must have at least 
        /// one public constructor with one string.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String, String)"/>
        public static void ThrowIfOutOfRange<TException>(this DateTime value, DateTime minimum, DateTime maximum, String parameter) where TException : Exception
        {
            value.ThrowIfOutOfRange<TException>(minimum, maximum, parameter, Constants.NullString);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an <see cref="ArgumentOutOfRangeException(String, String)"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>. The value of 
        /// <paramref name="parameter"/> is used as parameter name and the value of <paramref name="message"/> is used as message.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
        /// </param>
        /// <param name="parameter">
        /// The parameter name that caused the exception.
        /// </param>
        /// <param name="message">
        /// A message describing the error.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is throw if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String, String)"/>
        public static void ThrowIfOutOfRange(this DateTime value, DateTime minimum, DateTime maximum, String parameter, String message)
        {
            value.ThrowIfOutOfRange<ArgumentOutOfRangeException>(minimum, maximum, parameter, message);
        }

        /// <summary>
        /// Throws if <paramref name="value"/> is less than <paramref name="minimum"/> or greater than <paramref name="maximum"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method throws an exception of type <typeparamref name="TException"/> if value of <paramref name="value"/> 
        /// is less than value of <paramref name="minimum"/> or greater than value of <paramref name="maximum"/>. The value 
        /// of <paramref name="parameter"/> is used as first constructor argument and the value of <paramref name="message"/> 
        /// is used as second constructor argument.
        /// </para>
        /// <para>
        /// Attention, there is no check whether <paramref name="minimum"/> is really less than or equal to <paramref name="maximum"/>!
        /// It is the caller’s responsibility to ensure this.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <param name="minimum">
        /// The lower limit to be checked.
        /// </param>
        /// <param name="maximum">
        /// The upper limit to be checked.
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
        /// An exception of type <typeparamref name="TException"/> is throw if <paramref name="value"/> is less than 
        /// <paramref name="minimum"/> or greater than <paramref name="maximum"/>. Such an exception must have at least 
        /// one public constructor with two strings.
        /// </exception>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String)"/>
        /// <seealso cref="ThrowIfOutOfRange(DateTime, DateTime, DateTime, String, String)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime)"/>
        /// <seealso cref="ThrowIfOutOfRange{TException}(DateTime, DateTime, DateTime, String)"/>
        public static void ThrowIfOutOfRange<TException>(this DateTime value, DateTime minimum, DateTime maximum, String parameter, String message) where TException : Exception
        {
            if (value < minimum || value > maximum)
            {
                throw ExceptionHelper.CreateException<TException>(parameter, message);
            }
        }

        #endregion
    }
}

