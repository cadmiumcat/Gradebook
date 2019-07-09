using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("cat");
            book.AddGrade(1.2);
            book.AddGrade(2.1);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low:N1}!");
            Console.WriteLine($"The highes grade is {stats.High:N1}!");
            Console.WriteLine($"The average grade is {stats.Average:N1}!");
        }
    }
}
