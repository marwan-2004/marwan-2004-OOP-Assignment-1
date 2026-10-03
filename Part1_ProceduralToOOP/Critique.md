\# Architectural \& Design Critique of Procedural C++ Code



\## 1. Global Parallel Arrays \& Missing Domain Models

\- \*\*Problem\*\*: Entities like Customer, Product, Order, and OrderLine are split across multiple parallel global arrays (`customerNames`, `customerEmails`, `productPrices`, `lineProductIndexes`, etc.).

\- \*\*Consequence\*\*: Data integrity is fragile and easily corrupted. Adding a customer or order line requires manually synchronizing across 4 to 5 separate arrays using raw indices.



\## 2. Hardcoded Arbitrary Fixed Limits

\- \*\*Problem\*\*: Fixed constant capacity bounds (`MAX\_CUSTOMERS = 50`, `MAX\_PRODUCTS = 50`, `MAX\_ORDERS = 100`, `MAX\_LINES\_PER\_ORDER = 20`).

\- \*\*Consequence\*\*: The system fails or rejects input once customer/order capacity is reached, while wasting memory if capacity is unused.



\## 3. Global Mutable State

\- \*\*Problem\*\*: State variables (`customerCount`, `productCount`, `orderCount`, and all state arrays) are declared globally and accessible to every function.

\- \*\*Consequence\*\*: Any function can alter global state directly without going through validation. Debugging state corruption or scaling to concurrent access is nearly impossible.



\## 4. Tightly Coupled Console I/O and Business Logic

\- \*\*Problem\*\*: Business logic functions (such as `addLineToOrder` and `markOrderPaid`) directly print error messages to standard output (`cout`).

\- \*\*Consequence\*\*: Domain functions cannot be reused in non-console environments (like Web APIs, GUIs, or automated unit tests) because business outcomes are mixed with UI output.



\## 5. Scattered Business Invariants

\- \*\*Problem\*\*: Rules like VIP discounts (10% off) and stock deductions are scattered inside free functions (`calculateOrderTotal` and `addLineToOrder`).

\- \*\*Consequence\*\*: Modifying domain behavior (e.g., changing VIP logic or pricing calculations) requires hunting through procedural control flows rather than updating a single encapsulated entity.

