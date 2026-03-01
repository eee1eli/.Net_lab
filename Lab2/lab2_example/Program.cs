    using System;
    using lab2;

    class Program
    {
        static void Main()
        {
            string text = "Hello World";
            Console.WriteLine(MyFunctions.ReverseString(text));

            int[] numbers = { 2, 1, 5, 9, 10 };
            MyFunctions.PrintArray(numbers);
        
        }
    }

