# Plexdata Utilities Exceptions

<p align="center">
  <a href="https://github.com/akesseler/Plexdata.Utilities.Exceptions/blob/master/LICENSE.md" alt="license">
    <img src="https://img.shields.io/github/license/akesseler/Plexdata.Utilities.Exceptions.svg" />
  </a>
  <a href="https://github.com/akesseler/Plexdata.Utilities.Exceptions/releases/latest" alt="latest">
    <img src="https://img.shields.io/github/release/akesseler/Plexdata.Utilities.Exceptions.svg" />
  </a>
  <a href="https://github.com/akesseler/Plexdata.Utilities.Exceptions/archive/master.zip" alt="master">
    <img src="https://img.shields.io/github/languages/code-size/akesseler/Plexdata.Utilities.Exceptions.svg" />
  </a>
  <a href="https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki" alt="wiki">
    <img src="https://img.shields.io/badge/wiki-API-orange.svg" />
  </a>
</p>

## Plexdata Utilities Exceptions

The _Plexdata Utilities Exceptions_ provides a number of extension methods that allow standard checks such as null check, 
empty check, range check an so on, do be done in one single line of code.

Every extension method comes with a set of overloads that allow to control the name of affected parameter and the exception's 
message as well as the type of the exception to be thrown.

Here is an overview of all existing extension methods that are provided by this package, including their default exceptions:

- Method `ThrowIfNull()` is used for any kind of null check and throws an `ArgumentNullException` as default.
- Methods `ThrowIfNotVerified(delegate)` and `ThrowIfNotVerified(delegate(value))` are used for any kind of object 
  validation and throw an `ArgumentVerifyException` as default.
- Methods `ThrowIfNullOrEmpty()` and `ThrowIfNullOrWhiteSpace()` are used especially for string checks and throw 
  an `ArgumentOutOfRangeException` as default.
- Methods `ThrowIfEqualTo(other)` and `ThrowIfNotEqualTo(other)` are used for any kind of equal checks and throw an 
  `ArgumentOutOfRangeException` as default.
  - Note that these methods can only be used with types derived from `IEquatable<T>`.
- Methods `ThrowIfLessThan(minimum)` and `ThrowIfLessThanOrEqualTo(minimum)` are used for lower limit checks and 
  throw an `ArgumentOutOfRangeException` as default. 
  - Note that these methods can only be used with types derived from `IComparable<T>`.
- Methods `ThrowIfGreaterThan(maximum)` and `ThrowIfGreaterThanOrEqualTo(maximum)` are used for upper limit checks 
  and throw an `ArgumentOutOfRangeException` as default. 
  - Note that these methods can only be used with types derived from `IComparable<T>`.
- Method `ThrowIfOutOfRange(minimum, maximum)` is used for range checks and throws an `ArgumentOutOfRangeException` as default. 
  - Note that this method can only be used with types derived from `IComparable<T>`.

### Functional Overview

- [Object Null Check](#object-null-check)
- [Object Verification](#object-verification)
  - [Usage of Validation Delegates](#object-verification-validation-delegates-usage)
  - [Usage of Validation Methods](#object-verification-validation-methods-usage)
  - [Usage of Model Validation](#object-verification-model-method-usage)
  - [Special Validation Use Case](#object-verification-special-validation-use-case)
- [String Validation](#string-validation)
- [Equality Validation](#equality-validation)
- [Limit Validation](#limit-validation)
  - [Lower Limit Validation](#lower-limit-validation)
  - [Upper Limit Validation](#upper-limit-validation)
- [Range Validation](#range-validation)

### <a id="object-null-check"></a>Object Null Check

A null check is done like this, which is for sure the easiest way.

```
public void Process(Data data)
{
    data.ThrowIfNull();
}
```

This example shows how to use the name of the affected parameter.

```
public void Process(Data data)
{
    data.ThrowIfNull(nameof(data));
}
```

In this example is shown how to use the name of the affected parameter and how to specify a custom exception message.

```
public void Process(Data data)
{
    data.ThrowIfNull(nameof(data), $"Value of '{nameof(data)}' must not be null.");
}
```

<a id="object-null-check-different-exception-usage"></a>Sometimes it might be helpful to use an own exception, instead of the 
default exception. For this purpose, this extension method offers a suitable overload. How to specify a custom exception, such 
as an `ArgumentException` for example, is shown in code snippet below. 

```
public void Process(Data data)
{
    data.ThrowIfNull<Data, ArgumentException>();
}
```

Of course, applying a parameter name and an exception message is possible and works as shown above. But unfortunately, in this 
case it is required to specify all generic parameters explicitly, which could lead to confusing code when using long type names
plus parameter name plus a long error message.

### <a id="object-verification"></a>Object Verification

By using extension method `ThrowIfNotVerified()`, it becomes possible to perform a custom verification on any kind of object. 
Please note that an additional null check is unnecessary as this is done internally.

#### <a id="object-verification-validation-delegates-usage"></a>Usage of Validation Delegates

Method `ThrowIfNotVerified()` is able to use delegates for object verification and the following examples show some of the 
possible variations. But beforehand, consider this data model, which serves as base for the next examples.

```
public class Data
{
    public Object Object { get; }
}
```

Example of using a parameterless inline delegate.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified(() => { return data.Object != null; });
}
```

Example of using a parameterized inline delegate.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified((affected) => { return affected.Object != null; });
}
```

Example of using a parameterless local delegate.

```
public void Process(Data data)
{
    Func<Boolean> verifier = delegate () { return data.Object != null; };
    data.ThrowIfNotVerified(() => verifier());
}
```

Example of using a parameterized local delegate.

```
public void Process(Data data)
{
    Func<Data, Boolean> verifier = delegate (Data affected) { return affected.Object != null; };
    data.ThrowIfNotVerified((data) => verifier(data));
}
```

<a id="object-verification-different-exception-example"></a>If the validation fails in all examples above, the default exception 
of type `ArgumentVerifyException` is thrown. But sometimes it might be useful to throw an own exception. Here is an example of 
how to trigger a custom exception.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified<Data, ArgumentException>(() => { return data.Object != null; });
}
```

Unfortunately, in this case it is required to specify all generic parameters explicitly, which could lead to confusing code when 
using long type names plus parameter name plus a long error message.

#### <a id="object-verification-validation-methods-usage"></a>Usage of Validation Methods

The usage of validation delegates might be useful for quick checks. But in the real world, a data model validation is of course 
much more complex. For such a purpose it is possible to use for example a private method that can validate each aspect of a 
particular data model. But before continue reading, consider this data model, that serves as base for these examples.

```
public class Buyer
{
    public Int32 Id { get; }
    public String Name { get; }
    public Boolean Active { get; }
}
```

As next, the `Buyer` validation method has to be implemented, for example like this. Note that a null check is not required 
as this is already done by the extension method.

```
private Boolean Validate(Buyer buyer)
{
    return !(buyer.Id < 1 || String.IsNullOrEmpty(buyer.Name) || !buyer.Active);
}
```

Finally, here the example of using a parameterized private method for object verification.

```
public void Process(Buyer buyer)
{
    buyer.ThrowIfNotVerified(() => this.Validate(buyer));
}
```

This actually makes sense because the validation method gets the `Buyer` instance as parameter. Furthermore, several of these 
validation methods can be implemented, one for each parameter for example.

#### <a id="object-verification-model-method-usage"></a>Usage of Model Validation

Some models are able to validate themselves. For this reason, such model classes offer either their own property or their own 
method that can perform such a check. Here are two example models that can validate themselves.

In this example model a validation property is used.

```
public class Data
{
    public Object Object { get; }
    public Boolean IsValid { get { return this.Object != null; } }
}
```

With this in mind, a verification can be done this way.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified(() => data.IsValid);
}
```

And in this example model a validation method is used instead.

```
public class Data
{
    public Object Object { get; }
    public Boolean IsValidated() { return this.Object != null; }
}
```

With this in mind, a verification can be done this way.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified(() => data.IsValidated());
}
```

Using a parameterized validation method would also be possible. But of course this doesn't really make sense, since the method 
for validation is part of the model class and that class knows everything about its properties and states etc.

Note again, all above examples throw their default exception `ArgumentVerifyException` as needed. How to use a different 
exception instead is demonstrated in section [Usage of Validation Delegates](#object-verification-different-exception-example).

#### <a id="object-verification-special-validation-use-case"></a>Special Validation Use Case

As mentioned above, an explicit null check is never required for object validation. However, sometimes it might be necessary 
to throw two different exceptions, one for the null check and one for the actual verification. How this can be achieved is 
shown here. But first, consider the following data model.

```
public class Seller
{
    public Int32 Id { get; }
    public String Name { get; }
    public Boolean Active { get; }

    public Boolean Validate()
    {
        return !(this.Id < 1 || String.IsNullOrEmpty(this.Name) || !this.Active);
    }
}
```

Taking the above data model into account, the null check has to trigger the predefined `ArgumentNullException` and the actual 
verification has to trigger the custom `SellerValidationException`. How this works is shown in the next code snippet.

```
public void Process(Seller seller)
{
    seller.ThrowIfNull<Seller, ArgumentNullException>(nameof(seller), "The seller must not be null.")
          .ThrowIfNotVerified<Seller, SellerValidationException>(() => seller.Validate(), nameof(seller), "The seller could not be verified.");
}
```

As already mentioned, in case of using at least one exception other than the default exception, it is required to specify all 
generic parameters in all concatenated extension methods!

#### <a id="string-validation"></a>String Validation

A string validation can be made in two different ways, the check for _null or empty_ and the check for _null, empty or white space_.

The _null or empty_ check can be done by calling `ThrowIfNullOrEmpty()` as shown here.

```
public void Process(String name)
{
    name.ThrowIfNullOrEmpty();
}
```

The _null, empty or white space_ check can be done by calling `ThrowIfNullOrWhiteSpace()` as shown here.

```
public void Process(String name)
{
    name.ThrowIfNullOrWhiteSpace();
}
```

Using a different exception for a string validation works slightly different as explained in section 
[Object Null Check](#object-null-check-different-exception-usage). In this particular case, it is only necessary to specify the 
exception as generic parameter, as shown in the following both examples.

```
public void Process(String name)
{
    name.ThrowIfNullOrEmpty<ArgumentException>();
}
```

```
public void Process(String name)
{
    name.ThrowIfNullOrWhiteSpace<ArgumentException>();
}
```

On the other hand, something like this would be possible, but it doesn't really make sense.

```
public void Process(String name)
{
    name.ThrowIfNullOrEmpty<ArgumentException>()
        .ThrowIfNullOrWhiteSpace<ArgumentOutOfRangeException>();
}
```

But another scenario could be to throw three different exceptions, one for the null check, one for the empty check, and one for 
the white space check. This is possible and could be done in this way.

```
public void Process(String name)
{
    name.ThrowIfNull<String, ArgumentNullException>()
        .ThrowIfNullOrEmpty<ArgumentException>()
        .ThrowIfNullOrWhiteSpace<ArgumentOutOfRangeException>();
}
```

#### <a id="equality-validation"></a>Equality Validation

The check whether two objects are equal or not can be done with the current package version. The extension methods to be used 
for those checks are `ThrowIfEqualTo()` and `ThrowIfNotEqualTo()`. Here are two examples of how to perform equality checks.

```
public void Process(Decimal price)
{
    price.ThrowIfEqualTo(Decimal.Zero, nameof(price), "Price must not be zero.");
}
```

```
public void Process(Decimal price)
{
    price.ThrowIfNotEqualTo(Decimal.Zero, nameof(price), "Price must be zero.");
}
```

But be aware, each type that wants to participate in an equality check requires the implementation of interface `IEquatable<T>`. 
Otherwise compiler errors will occur. Fortunately, most of the .NET types implement interface `IEquatable<T>`. Vice versa, custom 
types that want to use both extension methods must implement this interface themselves.

Finally note, all generic parameters must be specified as soon as a different exception is used.

#### <a id="limit-validation"></a>Limit Validation

Sometimes it would be useful to check the limit of a particular value, for example to validate the ID of a database entity. 
For this purpose, the current package version provides a set of extension methods for the _less than_, _less than or equal to_, 
_greater than_ and _greater than or equal to_ checks.

Keep in mind, each type that wants to participate in any kind of limit check requires the implementation of interface `IComparable<T>`. 
Otherwise compiler errors will occur. Fortunately, most of the .NET types implement interface `IComparable<T>`. Vice versa, custom 
types that want to use these extension methods must implement this interface themselves.


#### <a id="lower-limit-validation"></a>Lower Limit Validation

A lower limit validation can be done in two ways, a _less than_ check or a _less than or equal to_ check. Consider the following 
examples to get an idea of what is meant in detail.

```
public void Process(Int32 userId)
{
    userId.ThrowIfLessThan(1);
}
```

```
public void Process(Int32 userId)
{
    userId.ThrowIfLessThanOrEqualTo(0);
}
```

For sure, method `ThrowIfLessThanOrEqualTo()` can actually be replaced by this check, which could be useful when using different 
exceptions or using different error messages.

```
public void Process(Int32 userId)
{
    userId.ThrowIfLessThan(0).ThrowIfEqualTo(0);
}
```

Please note, all generic parameters must be specified as soon as a different exception is used.

#### <a id="upper-limit-validation"></a>Upper Limit Validation

An upper limit check can be done the same way as previously described, but using these extension methods instead.

```
public void Process(Decimal credit)
{
    credit.ThrowIfGreaterThan(Decimal.Zero, nameof(credit), "Credit must be less than or equal to zero.");
}
```

```
public void Process(Decimal credit)
{
    credit.ThrowIfGreaterThanOrEqualTo(Decimal.Zero, nameof(credit), "Credit must be a negative value.");
}
```

Method `ThrowIfGreaterThanOrEqualTo()` from the previous example can actually be replaced by this check, which could 
be useful when using different exceptions or using different error messages.

```
public void Process(Decimal credit)
{
    credit.ThrowIfGreaterThan(Decimal.Zero).ThrowIfEqualTo(Decimal.Zero);
}
```

Additionally note, all generic parameters must be specified as soon as a different exception is used.

#### <a id="range-validation"></a>Range Validation

A validation of ranges is also a common use case. For such purposes, the extension method `ThrowIfOutOfRange()` can be used, 
as the following example shows.

An exception is thrown if the value is less than 100 or greater than 500, which conversely means that the range [100...500] is 
considered as valid.

```
public void Process(Int32 value)
{
    value.ThrowIfOutOfRange(100, 500, nameof(value), "The value must be in the range between 100 and 500.");
}
```

For value range checks, it should be noted that there is no internal verification that the minimum value is actually less than 
the maximum value. It is the calles responsibility to ensure that.

Also note that all generic parameters must be specified as soon as a different exception is used.

### Framework

Current target framework of this library is the _.NET Standard v2.0_.

### Licensing

The software has been published under the terms of _MIT License_.

### Downloads

The latest release can be obtained from [https://github.com/akesseler/Plexdata.Utilities.Exceptions/releases/latest](https://github.com/akesseler/Plexdata.Utilities.Exceptions/releases/latest).

The main branch can be downloaded as ZIP from [https://github.com/akesseler/Plexdata.Utilities.Exceptions/archive/master.zip](https://github.com/akesseler/Plexdata.Utilities.Exceptions/archive/master.zip).

### Documentation

The full class documentation is available as Wiki and can be found under [https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki](https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki).

### Known Issues

Using the parameter name only in combination with an exception (such as `Exception` for example), that takes a _message_ as first argument, 
may lead in an unclear exception message. This is because of the exception message becomes the parameter name. Therefore, it is strictly 
recommended to use only exceptions that can take a parameter name as first argument and a message as second. Additionally note, this restriction 
does not affect the use of `ArgumentException`, as corresponding handling exist internally.
