This library provides a number of extension methods that allow standard checks such as null check, empty check, 
range check an so on, do be done in one single line of code.

Each extension method comes with a set of overloads that allow users to control the type of thrown exception as 
well as the exception message.

Here is an overview of the existing extension methods that are provided by this package:

- Method `ThrowIfNull()` for any kind of object.
- Method `ThrowIfNullOrEmpty()` especially for strings.
- Method `ThrowIfNullOrWhiteSpace()` especially for strings.
- Method `ThrowIfLessThan(minimum)` for number types such as `Int32`, `Double`, etc.
- Method `ThrowIfGreaterThan(maximum)` for number types such as `Int32`, `Double`, etc.
- Method `ThrowIfOutOfRange(minimum, maximum)` for number types such as `Int32`, `Double`, etc.

The sources can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions](https://github.com/akesseler/Plexdata.Utilities.Exceptions).

The class documentation can be found on GitHub under [https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki](https://github.com/akesseler/Plexdata.Utilities.Exceptions/wiki).

The documentation with an overview, an introduction as well as examples is available on the project page.
