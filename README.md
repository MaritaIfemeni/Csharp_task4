## C# Assignment: Customer Database Management

The purpose off this assignment was to build a customer database application that can store and retrieve customer information in a .csv file and it should contain the basic CRUD operations and seperate exception handler.

## Missing Features

- No proper validation has been applied.
- In some cases application crashes when user enters invalid input.

### Technologies used
- C#

### File structure

```
.
├── CustomerDatabase.csproj
├── README.md
├── bin
├── obj
└── src
    ├── Actions
    │   ├── Customer.cs
    │   ├── CustomerDatabase.cs
    │   └── FileHelper.cs
    ├── Data
    │   └── customers.csv
    ├── Program.cs
    └── Shared
        └── ExpectionHandler.cs