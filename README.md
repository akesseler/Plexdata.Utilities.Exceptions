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

Each extension method comes with a set of overloads that allow users to control the type of thrown exception as well as 
the exception message.

Here is an overview of the existing extension methods that are provided by this package:

- Method `ThrowIfNull()` for any kind of object.
- Method `ThrowIfNullOrEmpty()` especially for strings.
- Method `ThrowIfNullOrWhiteSpace()` especially for strings.
- Method `ThrowIfLessThan(minimum)` for number types such as `Int32`, `Double`, etc.
- Method `ThrowIfGreaterThan(maximum)` for number types such as `Int32`, `Double`, etc.
- Method `ThrowIfOutOfRange(minimum, maximum)` for number types such as `Int32`, `Double`, etc.

### Examples

#### General Usage

This section shows basic examples that apply to all available extension methods.

The simplest use of the extension methods is shown in this example.

```
public void Process(Data data)
{
    data.ThrowIfNull();
}
```

This example shows how to reference the affected parameter name.

```
public void Process(Data data)
{
    data.ThrowIfNull(nameof(data));
}
```

Next example shows how to reference the affected parameter name and how to specify a message as well.

```
public void Process(Data data)
{
    data.ThrowIfNull(nameof(data), $"Value of '{nameof(data)}' must not be null.");
}
```

Last example in this section shows how to use an own exception (for example the `ArgumentException`) instead of the default 
exception. Note that applying the parameter name and an error message works the same way as above.

```
public void Process(Data data)
{
    data.ThrowIfNull<ArgumentException>();
}
```

#### Object Validation

This section shows how to validate objects.

The first way to validate an object is to use `ThrowIfNull()`. Examples of this can be found above.

Another possible use is the method `ThrowIfNotVerified()`. This makes it possible to execute an own validation callback.

Suppose there exists a data model class that has the method `IsValid()`. In this case, extension method `ThrowIfNotVerified()` 
can be called as follows.

```
public void Process(Data data)
{
    data.ThrowIfNotVerified(() => data.IsValid());
}
```

Please note that an extra null check is unnecessary, since `ThrowIfNull()` is already called internally.

It is also possible to use a property (such as `Boolean Valid { get; }`) instead of a method. Furthermore, the usage of an 
independent validation callback (such as `Func<Boolean> validator = delegate { return true; };`) is possible as well.

#### String Validation

A String validation can be done in two different ways. These are the checks for null and empty and for null and white spaces.

The null or empty check can be done by calling `ThrowIfNullOrEmpty()` as shown as next.

```
public void Process(String name)
{
    name.ThrowIfNullOrEmpty();
}
```

The null or white space check can be done by calling `ThrowIfNullOrWhiteSpace()` as shown below.

```
public void Process(String name)
{
    name.ThrowIfNullOrWhiteSpace();
}
```

#### Number Validation

A number validation is also possible. For this purpose, the three methods `ThrowIfLessThan(minimum)`, `ThrowIfGreaterThan(maximum)` 
and `ThrowIfOutOfRange(minimum, maximum)` are available. At the moment, the supported number types are: `SByte`, `Byte`, `Int16`, 
`UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64`, `Single`, `Double` and `Decimal`. Against this background, the methods can be applied 
in the same way to all these types.

***Minimum Check***

```
public void Process(Int32 value)
{
    value.ThrowIfLessThan(3);
}
```

***Maximum Check***

```
public void Process(Int32 value)
{
    value.ThrowIfGreaterThan(1000);
}
```

***Range Check***

```
public void Process(Int32 value)
{
    value.ThrowIfOutOfRange(10, 500);
}
```

For value range checks, it should be noted that there is no internal validation that the minimum value is actually less than 
the maximum value. It is the calles responsibility to ensure that.

#### Default Exceptions

List below shows all default exceptions that are thrown if no other exception has been declared by the generic parameter.

- Method `ThrowIfNull()` throws an `ArgumentNullException` if necessary.
- Method `ThrowIfNullOrEmpty()` throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfNullOrWhiteSpace()` throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfNotVerified()` throws an `ArgumentVerifyException` (defined in this package) if necessary.
- Method `ThrowIfLessThan()` throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfGreaterThan()` throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfOutOfRange()` throws an `ArgumentOutOfRangeException` if necessary.

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

Using the parameter name only in combination with an exception (such as `Exception` for example), that takes the error message 
as first argument, may lead in an unclear error message. This is because of this error message will become the parameter name. 
Therefore, it is strictly recommended to use only exceptions that take a parameter name as first argument. This does not affect 
the use of `ArgumentException`, as corresponding handling exist internally.


