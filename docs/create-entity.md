# Create a new Entity

To create an entity, in Domain project, add a new class. There are several options but the simplest way is to inherit from  **Entity** in the namespace **DynamoCode.Domain.Entities**.

## Inherit from Entity

The class Entity has been designed for the average case where there is simple Id property of type int. Most of the time, this is all we need.

```csharp
using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
```

## Inherit from Entity < TId >

There are cases where the Id as an int is simply not suitable, for those cases we've created a **generic Entity** class where the derived class defines the type of Id. Bear in mind, in this case you'll need to ensure uniqueness (Equals and GetHashCode) based on the specific type of your choice.

```csharp
using System;
using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Student : Entity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }
    }
}
```

## Implement IEntityKey < TId >

If we are in a situation where inheritance is not possible or not suitable, there is another option: directly implement the interface **IEntityKey < TId >**. In this case we have the freedom to choose the type of Id as well. 

```csharp
using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Product : IEntityKey<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
```