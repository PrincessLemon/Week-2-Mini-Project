Notes about my code:
I split the code into three classes as it felt much more clean, product data is in Product-class then the list logic in ProductManager. 

I used LINQ to sort the products by price and calculate the total amount, first time using LINQ, as we studied it this week :) it was a lot easier!

I also learnt some input validation, this time I used decimal.Tryparse to prevent crashes if user types letters instead of numbers. I added a small helper method this time UserTypedQuit to prevent having to repeat the check everywhere (makes the code a lot easier to read).

I am very happy I got to practice classes, lists, LINQ, loops and user input handling in a different way this time, gives the feel of writing a more "real" program.


SOURCE LIST:

https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries
https://learn.microsoft.com/en-us/shows/c-advanced/introduction-to-language-integrated-query-linq--c-advanced-1-of-8
https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/list-collection
https://www.w3schools.com/cs/cs_classes.php
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections
https://www.tutorialsteacher.com/csharp/csharp-list
https://learn.microsoft.com/en-us/training/paths/get-started-c-sharp-part-5/
https://learn.microsoft.com/en-us/training/paths/get-started-c-sharp-part-2/
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1?view=net-10.0
