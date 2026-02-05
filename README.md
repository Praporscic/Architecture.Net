# Clean Architecture example:

## Overview
This project follows the **Clean Architecture** principles to create a maintainable, testable, and scalable codebase.  
The architecture enforces a clear separation of concerns, keeping business logic independent from frameworks, UI, and external services.

## Architecture Layers
The solution is organized into distinct layers, each with a single responsibility:

- **Domain**  
  Contains core business entities, value objects, and domain rules.  
  This layer has no dependencies on other layers.

- **Application**  
  Holds use cases, business workflows, and application logic.  
  Depends only on the Domain layer and defines interfaces for external concerns.

- **Infrastructure**  
  Implements external dependencies such as databases, APIs, file systems, and third-party services.  
  Depends on the Application layer through interfaces.

- **Presentation**  
  Handles user interaction (e.g., API controllers, UI).  
  Depends on the Application layer to execute use cases.

## Key Principles
- Dependency rule: dependencies always point inward
- Business logic is framework-agnostic
- Easy to test core logic without external dependencies
- Clear boundaries between layers

## Benefits
- Improved maintainability
- Easier testing
- Better scalability
- Clear separation of responsibilities

---
<img width="339" height="343" alt="image" src="https://github.com/user-attachments/assets/f2531877-1c65-43f4-82ae-2a81b6eaefe7" />

## Folder Structure Example
```text
src/
├── Domain/
│   ├── Entities/
│   │   ├── User.cs
│   │   └── Order.cs
│   ├── ValueObjects/
│   ├── Interfaces/
│   └── Exceptions/
│
├── Application/
│   ├── Common/
│   │   ├── Interfaces/
│   │   └── Behaviors/
│   ├── Features/
│   │   ├── Users/
│   │   │   ├── CreateUser/
│   │   │   │   ├── CreateUserCommand.cs
│   │   │   │   ├── CreateUserHandler.cs
│   │   │   │   └── CreateUserValidator.cs
│   │   │   └── GetUser/
│   │   │       ├── GetUserQuery.cs
│   │   │       └── GetUserHandler.cs
│   │   └── Orders/
│   │       ├── CreateOrder/
│   │       └── GetOrders/
│
├── Infrastructure/
│   ├── Persistence/
│   │   ├── ApplicationDbContext.cs
│   │   └── Migrations/
│   ├── Repositories/
│   └── Services/
│
├── Presentation/
│   ├── Controllers/
│   │   ├── UsersController.cs
│   │   └── OrdersController.cs
│   └── Middleware/
│
└── Shared/
    └── DependencyInjection.cs
```
# Vertical Slice Architecture example:

## Overview

This repository is a demonstration of **Vertical Slice Architecture (VSA)** in a .NET project. Unlike traditional layered architecture, which separates code into horizontal layers like Controllers, Services, and Repositories, **Vertical Slice Architecture organizes code by features**. Each feature contains all the code it needs—handlers, commands, queries, validation, and persistence—making features self-contained and easier to maintain.

This approach helps reduce the complexity of large applications and encourages feature-based thinking.

---

## Key Concepts

- **Feature-first Organization:** Code is grouped by features, not technical layers.
- **CQRS-friendly:** Commands and Queries are often implemented per feature.
- **Encapsulation:** Each vertical slice has all dependencies it needs.
- **Minimal coupling:** Features are mostly independent, reducing cross-feature dependencies.

---

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/f99beb69-b8d7-4186-a775-553457a358bd" />

## Folder Structure Example

```text
src/
└── Features/
    ├── Users/
    │   ├── CreateUser/
    │   │   ├── CreateUserCommand.cs
    │   │   ├── CreateUserHandler.cs
    │   │   └── CreateUserValidator.cs
    │   └── GetUser/
    │       ├── GetUserQuery.cs
    │       └── GetUserHandler.cs
    └── Orders/
        ├── CreateOrder/
        └── GetOrders/

