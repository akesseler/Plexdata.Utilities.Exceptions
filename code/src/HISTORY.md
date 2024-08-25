

**1.0.2** (**BREAKING CHANGES**)

- A complete restructuring of the project.
- Introduction of the new methods `ThrowIfEqualTo()`, `ThrowIfNotEqualTo()`, `ThrowIfLessThan()`, 
  `ThrowIfLessThanOrEqualTo()`, `ThrowIfGreaterThan()` and `ThrowIfGreaterThanOrEqualTo()`.
- Replacement of the many data-type-based methods by methods that accept values inheriting either from 
  `IEquatable<T>` or from `IComparable<T>`.
- The change of the result type from `void` to `TValue` for all methods to be able to concatenate them.
- A complete review and revision of the documentation.
- Updating some of the NuGet packages in use.
- Version number increased.

**1.0.1**

- Adding of _DateTime_ validation.
- Typo corrections and documentation updates.
- Version number increased.

**1.0.0**
- Initial draft.
- Published on [https://github.com/akesseler/Plexdata.Utilities.Exceptions](https://github.com/akesseler/Plexdata.Utilities.Exceptions).
