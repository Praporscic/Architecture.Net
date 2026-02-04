# Vertical Slice Architecture Example

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

