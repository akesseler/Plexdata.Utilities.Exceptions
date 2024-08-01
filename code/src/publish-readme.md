This library provides a number of extension methods that allow standard checks such as null check, empty check, 
range check an so on, do be done in one single line of code.

Each extension method comes with a set of overloads that allow users to control the type of thrown exception as 
well as the exception message.

Here an overview of the existing extension methods that are provided by this package (including their default 
exceptions, thrown as needed):

- Method `ThrowIfNull()` is used for any kind of object and throws an `ArgumentNullException` if necessary.
- Method `ThrowIfNotVerified(delegate)` is used for any kind of object with verification and throws an `ArgumentVerifyException` (defined in this package) if necessary.
- Method `ThrowIfNullOrEmpty()` is used especially for strings and throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfNullOrWhiteSpace()` is used especially for strings and throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfLessThan(minimum)` is used for number types such as `Int32`, `Double`, etc. and throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfGreaterThan(maximum)` is used for number types such as `Int32`, `Double`, etc. and throws an `ArgumentOutOfRangeException` if necessary.
- Method `ThrowIfOutOfRange(minimum, maximum)` is used for number types such as `Int32`, `Double`, etc. and throws an `ArgumentOutOfRangeException` if necessary.
 
The sources can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions](https://github.com/akesseler/Plexdata.Utilities.Exceptions).

The class documentation can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki](https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki).

The documentation with an overview, an introduction as well as examples is available on the project page.
