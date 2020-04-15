# Create a new Repository

We define a repository as the instrument to use when we need to retrieve or persist data that exists in the domain. 

There are several choices of persistence technologies but we go down the fundamentals. The vast majority of the time we need to perform the basic four operations: create, retrieve, update, delete (CRUD). For which we provide interfaces equipped with these frequent operations.

## Implementing directly the interfaces

Although it's tempting to just implement the interfaces provided (and for simple cases that's probably it) we suggest to create your own Repository Interfaces that suit your needs.

### IReadOnlyRepository < TEntity >

This interface defines methods for retrieving data in various ways, here are the methods divided in two groups.

#### Sync versions

* IList< TEntity > All(); It should return all the items without any filtering.

* PagedResult< TEntity > All(int page, int itemsPerPage); It should return a 'page' of the entire data set. *page* is usually implemented starting at 1 and *itemsPerPage* specify the number of items to retrieve.

* TEntity FindBy(TKey id); It should return only one instance of the entity given its unique identifier.

#### Async versions

* Task< List< TEntity > > AllAsync(); Async version of All() above.

* Task< PagedResult< TEntity > > AllAsync(int page, int itemsPerPage); Async version of All(int page, int itemsPerPage) above.

* Task< TEntity > FindByAsync(TKey id); Async version of FindBy(TKey id) above.

### IRepository < TEntity >

This interface defines methods for persisting and altering the data in various ways, here are the methods: 

* void Add(TEntity entity); It should persist the given entity in the data store. Depending on the specific circumstance, duplicated unique identifiers need to be handled.

* void Add(IEnumerable< TEntity > items); It should persist a list of instances of the given entity, ideally using some form of batching mechanism to make it more efficiently. 

* void Delete(TEntity entity); It should remove the given instance of the entity from the data store. Depending on the specific circumstance, non-existent unique identifiers need to be handled.

* void Delete(int id); Normally only one of these Delete is fully implemented, the other one will only call it with the required information.

* void Delete(IEnumerable< TEntity > entities); It should remove a list of instances of the given entity, ideally using some form of batching mechanism to make it more efficiently. 

* void Update(TEntity entity); It should replace all non-identity information of the given entity with the provided up to date data into the data store. 

> **Note:** - For all these methods, the general convention is to assume everything was successful unless an exception is thrown from either the implemented code or the data store itself. 

## Examples

In memory Person repository with all the operations, in this case the async implementations are just a copy of the sync ones. 

```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamoCode.Infrastructure.Data;
using DynamoCode.Infrastructure.Data.Entities;
using MyApp.Domain;

namespace MyApp.Infrastructure
{
    public class PersonInMemoryRepository : IRepository<Person>
    {
        private readonly IList<Person> data = new List<Person>();
        public PersonInMemoryRepository()
        {
            data.Add(new Person { Id = 1, FirstName = "P1", LastName = "LN1", Age = 30 });
            data.Add(new Person { Id = 2, FirstName = "P2", LastName = "LN2", Age = 31 });
            data.Add(new Person { Id = 3, FirstName = "P3", LastName = "LN3", Age = 32 });
            data.Add(new Person { Id = 4, FirstName = "P4", LastName = "LN4", Age = 33 });
            data.Add(new Person { Id = 5, FirstName = "P5", LastName = "LN5", Age = 34 });
        }

        public IList<Person> All()
        {
            return data;
        }

        public PagedResult<Person> All(int page, int itemsPerPage)
        {
            if (page <= 0)
                page = 1;

            var items = data;

            if (itemsPerPage > 0)
            {
                items = data.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }
            return new PagedResult<Person> { PageOfItems = items, TotalItems = data.Count };
        }
        public Person FindBy(int id)
        {
            return data.First(x => x.Id == id);
        }

        public Task<List<Person>> AllAsync()
        {
            return new Task<List<Person>>(() => All().ToList());
        }

        public Task<PagedResult<Person>> AllAsync(int page, int itemsPerPage)
        {
            return new Task<PagedResult<Person>>(() => All(page, itemsPerPage));
        }

        public Task<Person> FindByAsync(int id)
        {
            return new Task<Person>(() => FindBy(id));
        }


        public void Add(Person entity)
        {
            data.Add(entity);
        }

        public void Add(IEnumerable<Person> items)
        {
            foreach (var item in items)
            {
                data.Add(item);
            }
        }

        public void Delete(Person entity)
        {
            data.Remove(entity);
        }

        public void Delete(int id)
        {
            var item = FindBy(id);
            Delete(item);
        }

        public void Delete(IEnumerable<Person> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public void Update(Person entity)
        {
            Delete(entity);
            Add(entity);
        }
    }
}
```









