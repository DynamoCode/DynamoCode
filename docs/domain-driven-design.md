# Domain Driven Design 

## What is DDD ?

Domain‐Driven Design (DDD) is a development philosophy defined by Eric Evans in 2003. DDD is an approach to software development that enables teams to effectively manage the construction and maintenance of software for complex problem domains. This is achieved by focusing on the Core Domain, learning through collaboration and constantly evolving the model.

## DDD common terms

> **Strategic Design** - Strategic design refers to the process of identifying as accurately as possible the fundamental pillars of DDD: Domain Model, Subdomains, Core Domain, Bounded Contexts.

> **Tactical Design** - Tactical design is when you define your domain models with more precision within a single bounded context.

> **Domain Model** - The domain model is an object‐oriented model that incorporates both behavior and data (in memory). This is based on the premise that there is no database; therefore, it can evolve in a completely persistence‐ignorant way.

> **Subdomain** - It refers to just one area of the business that focuses on specific activities. 

> **Core Domain** - It's a specific subdomain where the core parts of the system represent the fundamental competitive advantage that your company can gain through the delivery of this software.

> **Bounded Context** - Autonomous part of the system whose  boundaries can be influenced by ambiguity in terminology, concepts of the domain, alignment to subdomains, business capabilities, team organization, physical location, legacy code base, third party integration.

> **Entities** - Entities are domain concepts that have a unique identity in the problem domain and clearly defined life cycle.

> **Value Object** - Value objects are the inverse of entities; they have no identity, and their equality is based on representing the same value.

> **Aggregates** - Aggregates represent domain concepts and decompose large object graphs into small clusters of domain objects to reduce the complexity of the technical implementation of the domain model. Transactions should not cross aggregate boundaries.

> **Factories** - A factory separates use from construction in the domain.

> **Repositories** - The repository mediates between the domain model and the data model; it maps the domain model to a persistence store.

> **Domain Events** - Domain events are significant occurrences in the real‐world problem domain. Using domain events can make it easier to transition certain operations or use cases into asynchronous processes.
