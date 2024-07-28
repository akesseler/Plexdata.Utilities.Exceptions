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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Plexdata.Utilities.Exceptions
{
    /// <summary>
    /// An exception caused by an incorrect user input.
    /// </summary>
    /// <remarks>
    /// This exception is explicitly meant as some kind of joke and can be thrown as soon as a developer recognizes an 
    /// unqualified user. A user who triggers this an exception may have qualified for <em>Dumbest Assumable User</em> 
    /// award.
    /// </remarks>
    [Serializable]
    public class UserNotQualifiedException : Exception
    {
        /// <summary>
        /// Default message.
        /// </summary>
        /// <remarks>
        /// This default message is used whenever a valid message is missing.
        /// </remarks>
        private const String DefaultMessage = "The user does not seem to be qualified to perform such an action.";

        /// <summary>
        /// Default construction.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using a default message.
        /// </remarks>
        /// <seealso cref="DefaultMessage"/>
        public UserNotQualifiedException()
            : this(UserNotQualifiedException.DefaultMessage, null)
        {
        }

        /// <summary>
        /// Creates an exception for a specific message.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception using the referenced message text.
        /// </remarks>
        /// <param name="message">
        /// The message to be shown to the user.
        /// </param>
        public UserNotQualifiedException(String message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Creates an exception for a specific message plus an inner exception.
        /// </summary>
        /// <remarks>
        /// This constructor creates an instance of this exception for a specific user message as well as an inner exception.
        /// </remarks>
        /// <param name="message">
        /// The message to be shown to the user.
        /// </param>
        /// <param name="exception">
        /// An instance of an inner exception.
        /// </param>
        /// <seealso cref="DefaultMessage"/>
        public UserNotQualifiedException(String message, Exception exception)
            : base(String.IsNullOrWhiteSpace(message) ? UserNotQualifiedException.DefaultMessage : message, exception)
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
        protected UserNotQualifiedException(SerializationInfo info, StreamingContext context)
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
