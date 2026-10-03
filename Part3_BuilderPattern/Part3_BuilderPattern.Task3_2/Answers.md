\# Part 3: Builder Pattern \& Refactoring Analysis



\## Task 3.1: Analysis of 20-Parameter Constructors



\### 1. Practical Problems with a 20-Parameter Constructor

\* \*\*Call-Site Readability\*\*: At the call site, a long argument list like `new Invoice(101, "John", "john@email.com", "012345", "Main St", "Cairo", "EG", "11511", "Main St", "Cairo", ...)` becomes unreadable. Developers cannot tell which value maps to which property without inspecting method signatures.

\* \*\*Type Inversion \& Positional Errors\*\*: When consecutive parameters share identical data types (e.g., several `string` parameters for address lines, or several `decimal` values for subtotal, discount, and tax), a developer can easily swap two arguments (e.g., swapping billing street and shipping street, or discount and tax). The compiler will not catch this error because the types match.

\* \*\*Fragility to Changes\*\*: Adding even a single optional field breaks every existing constructor call site across the codebase or requires adding burdensome constructor overloads.



\### 2. Deeper Design Issue Beyond Constructor Length

This is \*\*not\*\* merely a "constructor is too long" problem. It signals a fundamental design flaw: \*\*Violation of the Single Responsibility Principle (SRP) and Primitive Obsession\*\*.

\* A single `Invoice` class containing 20 raw properties is overloaded with distinct concerns: customer identity, billing address details, shipping address details, payment details, and monetary calculations.

\* It treats structured concepts (like an address) as flat primitive strings rather than encapsulating them into value objects.



\---



\## Task 3.3: Advantages of Composed Builders



\### 1. Single Responsibility Principle (SRP)

\* `AddressBuilder` only cares about assembling and validating address properties.

\* `OrderInfoBuilder` (or financial components) only cares about payment and order totals.

\* `InvoiceBuilder` serves as a high-level orchestrator that combines these sub-components into a complete `Invoice`.



\### 2. Independent Validation

\* `AddressBuilder` validates street, city, zip code, and country independently before the parent `Invoice` is ever instantiated.

\* The parent `Invoice` object does not need to duplicate or know any internal validation rules regarding address formatting or missing street names.



\### 3. Code Reuse (DRY Principle)

\* A single `AddressBuilder` is used to construct \*\*both\*\* `BillingAddress` and `ShippingAddress`.

\* Without composition, all address building methods (`WithStreet`, `WithCity`, `WithZipCode`, etc.) would have to be duplicated inside the main builder as `WithBillingStreet`, `WithShippingStreet`, `WithBillingCity`, `WithShippingCity`, etc.



\### 4. Call-Site Readability \& Expressiveness

\* Composed builders produce clean, self-documenting code using fluent nested actions or chained sub-builders, clearly separating billing details from shipping details and order totals.

