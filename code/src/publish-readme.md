This library provides a number of extension methods that allow standard checks such as null check, empty check, 
range check an so on, do be done in one single line of code.

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
 
The sources can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions](https://github.com/akesseler/Plexdata.Utilities.Exceptions).

The class documentation can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki](https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki).

The documentation with an overview, an introduction as well as examples is available on the project page.
