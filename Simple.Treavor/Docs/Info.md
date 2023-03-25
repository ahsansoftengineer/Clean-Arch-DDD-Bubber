### Information 

### List vs Enumerable vs Querable
- List<T>, IEnumerable<T>, and IQueryable<T> are all interfaces in the .NET Framework that can be used to work with collections of data. However, they have different purposes and capabilities.

1. List<T>: It is a class that represents a strongly-typed collection of objects that can be accessed by index. It is implemented as an array and provides methods to add, remove, and manipulate elements. It is suitable for in-memory collections where you want to perform operations like sorting, filtering, and modifying the data.

2. IEnumerable<T>: It is an interface that represents a sequence of objects that can be enumerated. It provides a simple way to iterate over a collection and retrieve each element. It is suitable for read-only collections that don't need to be modified, and you want to perform operations like filtering or projection.

3. IQueryable<T>: It is an interface that extends IEnumerable<T> and provides additional functionality for querying data from a data store, like a database. It supports building complex queries using LINQ (Language Integrated Query) syntax that can be translated to SQL or other query languages. It is suitable for querying large data sets where you want to perform operations like filtering, sorting, paging, and projection on the server-side, and retrieve only the data you need.

- In summary, List<T> is a concrete class that provides methods to manipulate collections in-memory, while IEnumerable<T> and IQueryable<T> are interfaces that allow you to work with collections in a more flexible way, depending on your needs. If you want to perform simple iterations over a collection, use IEnumerable<T>. If you want to query data from a data store, use IQueryable<T>.

### Why Called Enumerable
- The name "IEnumerable" is short for "enumerable," which means "able to be counted or listed." In the .NET Framework, an object that implements the IEnumerable<T> interface represents a sequence of objects that can be enumerated or iterated over, meaning that you can loop over each item in the sequence and perform an operation on it.

1. The IEnumerable<T> interface provides a single method, GetEnumerator(), which returns an IEnumerator<T> object that can be used to iterate over the sequence. The IEnumerator<T> interface provides methods to move through the sequence and retrieve the next item in the sequence.

2. So, the name "IEnumerable" reflects the core functionality of the interface, which is to provide a way to enumerate or iterate over a sequence of objects.

### Nested Classes
1. In .NET, a class can contain one or more nested classes, which are also called inner classes. When a class is defined within another class, it becomes a nested class or an inner class.

```c#
Car car = new Car("Toyota", "Camry", 2021);
car.PrintInfo(); // Make: Toyota, Model: Camry, Year: 2021

Car.Engine engine = new Car.Engine(203);
engine.PrintInfo(); // Horsepower: 203
```