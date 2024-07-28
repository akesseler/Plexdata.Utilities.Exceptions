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
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Plexdata.Utilities.Exceptions
{
    /// <summary>
    /// An exception that is thrown when one of the arguments provided to a method is 
    /// invalid.
    /// </summary>
    /// <remarks>
    /// This exception is thrown whenever an argument provided to a method is considered 
    /// invalid.
    /// </remarks>
    [Serializable]
    public class ArgumentVerifyException : ArgumentException
    {
        /// <summary>
        /// Default message.
        /// </summary>
        /// <remarks>
        /// This default message is used whenever a valid message is missing.
        /// </remarks>
        private const String DefaultMessage = "The argument is null or could not be verified.";

        /// <summary>
        /// Default construction.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using a default message.
        /// </remarks>
        /// <seealso cref="DefaultMessage"/>
        public ArgumentVerifyException()
            : this(Constants.NullString, ArgumentVerifyException.DefaultMessage, null)
        {
        }

        /// <summary>
        /// Creates an exception for a specific parameter.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using a default message 
        /// but takes the referenced parameter name.
        /// </remarks>
        /// <param name="parameter">
        /// The name of the referenced parameter.
        /// </param>
        /// <seealso cref="DefaultMessage"/>
        public ArgumentVerifyException(String parameter)
            : this(parameter, ArgumentVerifyException.DefaultMessage, null)
        {
        }

        /// <summary>
        /// Creates an exception for a specific parameter plus an inner exception.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using a default message 
        /// but takes the referenced parameter name and the inner exception as well.
        /// </remarks>
        /// <param name="parameter">
        /// The name of the referenced parameter.
        /// </param>
        /// <param name="exception">
        /// An instance of an inner exception.
        /// </param>
        /// <seealso cref="DefaultMessage"/>
        public ArgumentVerifyException(String parameter, Exception exception)
            : this(parameter, ArgumentVerifyException.DefaultMessage, exception)
        {
        }

        /// <summary>
        /// Creates an exception for a specific parameter plus a user message.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using provided message 
        /// as well as the referenced parameter name.
        /// </remarks>
        /// <param name="parameter">
        /// The name of the referenced parameter.
        /// </param>
        /// <param name="message">
        /// The message to be shown to the user.
        /// </param>
        public ArgumentVerifyException(String parameter, String message)
            : this(parameter, message, null)
        {
        }

        /// <summary>
        /// Creates an exception for a specific parameter plus a user message as well as 
        /// an inner exception.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception for a specific parameter 
        /// plus a user message and an inner exception.
        /// </remarks>
        /// <param name="parameter">
        /// The name of the referenced parameter.
        /// </param>
        /// <param name="message">
        /// The message to be shown to the user.
        /// </param>
        /// <param name="exception">
        /// An instance of an inner exception.
        /// </param>
        public ArgumentVerifyException(String parameter, String message, Exception exception)
            : base(String.IsNullOrWhiteSpace(message) ? ArgumentVerifyException.DefaultMessage : message, String.IsNullOrWhiteSpace(parameter) ? Constants.NullString : parameter, exception)
        {
        }

        /// <summary>
        /// Creates an exception with serialized data.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception with serialized data.
        /// </remarks>
        /// <param name="info">
        /// The object that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The contextual information about the source or destination.
        /// </param>
        [ExcludeFromCodeCoverage]
        protected ArgumentVerifyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Populates serialization information with data needed to serialize the target object.
        /// </summary>
        /// <remarks>
        /// This method populates serialization information with data needed to serialize the 
        /// target object.
        /// </remarks>
        /// <param name="info">
        /// The object that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The contextual information about the source or destination.
        /// </param>
        [ExcludeFromCodeCoverage]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
