using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using LambdaExercise.Entities;

namespace LambdaExercise
{
    internal class Program
    {
        static void Print<T>(List<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);    
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\guilh\OneDrive\Documentos\Exercises\LambdaExercise\LambdaExercise\in.txt";
            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee { Email = email, Salary = salary, Name = name });
                }
            }

            var FilterByM = list.Where(x => x.Name[0] == 'M').Sum(_ => _.Salary);
            var FilterByEmail = list.Where(_ => _.Salary > 2000).OrderBy(_ => _.Email).Select(_ => _.Email).ToList();
            Console.WriteLine("Email of people whose salary is more than 2000.00:");
            Print(FilterByEmail);
            Console.WriteLine("Sum of people whose name starts with 'M': " + FilterByM);
            
        }
    }
}
