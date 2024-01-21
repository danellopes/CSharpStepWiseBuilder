### Example of the Builder Design Pattern (Stepwise)

This example of the functional builder design pattern was develop using C#.

This technique is great when you need to build an object in an specific order. To do this, we have to split all of our dependent methods in different interfaces. In our builder, we have only one method we can call (Create()), and one object that implements all of your interfaces.

On the method Create(), we’ll return the first interface (on which all the other depends on). This forces the program into calling the next logical method, which will return an implementation of the next interface and so on, eventually coming to the method Build(), returning the main object.

If you're interested in the udemy course by [Dmitri Nesteruk](https://www.udemy.com/user/dmitrinesteruk/) [link](https://www.udemy.com/course/design-patterns-csharp-dotnet).
