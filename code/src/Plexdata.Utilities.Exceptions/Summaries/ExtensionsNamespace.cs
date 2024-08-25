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

namespace Plexdata.Utilities.Exceptions.Extensions
{
    /// <summary>
    /// The <c>Plexdata.Utilities.Exceptions.Extensions</c> namespace contains classes with extension methods to perform 
    /// parameter checks.
    /// </summary>
    /// <remarks>
    /// <para>
    /// All classes in this namespace export extension methods that can be used to perform different types of parameter checks. Each of the provided 
    /// methods has an overload able to throw either the <i>standard exception</i> or a user-defined exception, if necessary. In addition, the name 
    /// of the affected parameter as well as an error message can optionally be specified for each of these methods. Here is an overview of the exposed 
    /// methods and the <i>standard exception</i> they use.
    /// </para>
    /// <list type="bullet">
    /// <item><description><c>ThrowIfNull()</c> - Throws an <i>ArgumentNullException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfNotVerified()</c> - Throws an <see cref="ArgumentVerifyException"/> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfNullOrEmpty()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfNullOrWhiteSpace()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfEqualTo()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfNotEqualTo()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfLessThan()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfLessThanOrEqualTo()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfGreaterThan()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfGreaterThanOrEqualTo()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// <item><description><c>ThrowIfOutOfRange()</c> - Throws an <i>ArgumentOutOfRangeException</i> or a user defined exception if needed.</description></item>
    /// </list>
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }
}
