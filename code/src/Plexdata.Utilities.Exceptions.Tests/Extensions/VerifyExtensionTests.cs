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

using NUnit.Framework;
using Plexdata.Utilities.Exceptions.Extensions;
using Plexdata.Utilities.Testing;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Exceptions.Tests.Extensions
{
    [ExcludeFromCodeCoverage]
    [Category(TestType.UnitTest)]
    public class VerifyExtensionTests
    {
        #region ThrowIfNotVerified -> OverloadWithoutOtherArguments

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndSimpleObjectIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndSimpleObjectIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(nameof(verifyer)));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsArgumentVerifyException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsAnyOtherException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer()), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer()), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = null;

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = null;

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid()),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(null));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid()),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid()), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithoutOtherArgumentsAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid()), Throws.Nothing);
        }

        #endregion

        #region ThrowIfNotVerified -> OverloadWithParameterOnly

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndSimpleObjectIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndSimpleObjectIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(nameof(verifyer)));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsArgumentVerifyException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsAnyOtherException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = null;

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = null;

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = null;

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            Exception reference = new Exception("parameter");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterOnlyAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterOnlyAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter"), Throws.Nothing);
        }

        #endregion

        #region ThrowIfNotVerified -> OverloadWithParameterAndMessage

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndSimpleObjectIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndSimpleObjectIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = null;
            Func<Boolean> verifyer = null;

            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith(reference.Message)
                    .And.Property("ParamName").EqualTo(nameof(verifyer)));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierIsNull_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = null;

            NullReferenceException reference = new NullReferenceException();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsArgumentVerifyException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndSimpleObjectIsNullAndVerifierReturnsAnyResult_ThrowsAnyOtherException([Values(true, false)] Boolean result)
        {
            Object actual = null;
            Func<Boolean> verifyer = delegate { return result; };

            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return false; };

            Exception reference = new Exception("message");

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo(reference.Message));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => verifyer(), "parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndSimpleObjectIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            Object actual = new Object();
            Func<Boolean> verifyer = delegate { return true; };

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => verifyer(), "parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = null;

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = null;

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo("message"));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(false);

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo("message"));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.Valid, "parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationPropertyIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationProperty actual = new ObjectWithValidationProperty(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.Valid, "parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = null;

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationMethodIsNullAndVerifierIsNull_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = null;

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo("message"));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsArgumentVerifyException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter", "message"),
                Throws.InstanceOf<ArgumentVerifyException>()
                    .And.Message.StartsWith("message")
                    .And.Property("ParamName").EqualTo("parameter"));
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationMethodIsValidAndVerifierReturnsFalse_ThrowsAnyOtherException()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(false);

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter", "message"),
                Throws.InstanceOf<Exception>()
                    .And.Message.EqualTo("message"));
        }

        [Test]
        public void ThrowIfNotVerified_DefaultOverloadWithParameterAndMessageAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            ArgumentVerifyException reference = new ArgumentVerifyException();

            Assert.That(() => actual.ThrowIfNotVerified(() => actual.IsValid(), "parameter", "message"), Throws.Nothing);
        }

        [Test]
        public void ThrowIfNotVerified_ExceptionOverloadWithParameterAndMessageAndObjectWithValidationMethodIsValidAndVerifierReturnsTrue_ThrowsNothing()
        {
            ObjectWithValidationMethod actual = new ObjectWithValidationMethod(true);

            Exception reference = new Exception();

            Assert.That(() => actual.ThrowIfNotVerified<Exception>(() => actual.IsValid(), "parameter", "message"), Throws.Nothing);
        }

        #endregion

        #region Helpers

        private abstract class ObjectWithValidation : Object
        {
            protected readonly Boolean valid = false;

            private ObjectWithValidation() { }

            protected ObjectWithValidation(Boolean valid) : base() { this.valid = valid; }
        }

        private class ObjectWithValidationProperty : ObjectWithValidation
        {
            [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
            public ObjectWithValidationProperty(Boolean valid) : base(valid) { }

            public Boolean Valid { get { return base.valid; } }
        }

        private class ObjectWithValidationMethod : ObjectWithValidation
        {
            [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
            public ObjectWithValidationMethod(Boolean valid) : base(valid) { }

            public Boolean IsValid() { return base.valid; }
        }

        #endregion
    }
}
