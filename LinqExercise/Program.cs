using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int sum = numbers.Sum();
            Console.WriteLine(sum);

            Console.WriteLine();
            //TODO: Print the Average of numbers
            double average = numbers.Average();
            Console.WriteLine(average);

            Console.WriteLine();
            //TODO: Order numbers in ascending order and print to the console
            IEnumerable<int> ascending =
                numbers.OrderBy(x => x);

            PrintIEnum(ascending);

            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
            IEnumerable<int> descending =
                numbers.OrderByDescending(x => x);

            PrintIEnum(descending);

            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            IEnumerable<int> greaterThanSix =
                numbers.Where(x => x > 6);

            PrintIEnum(greaterThanSix);

            Console.WriteLine();
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            IEnumerable<int> fourAscending =
                numbers.OrderBy(x => x);

            int count = 0;
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
                count++;

                if (count >= 4)
                    break;
            }

            PrintIEnum(fourAscending);

            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[3] = 24;

            IEnumerable<int> myAgeDescending =
                numbers.OrderByDescending(x => x);

            PrintIEnum(myAgeDescending);

            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            IEnumerable<Employee> firstNameCorS =
                employees.Where(name => name.FirstName.Contains('C') || name.FirstName.Contains('S'));

            foreach (var name in firstNameCorS)
            {
                Console.WriteLine(name.FullName);
            }

            Console.WriteLine();
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            IEnumerable<Employee> overTwentySix =
                employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);

            foreach (var i in overTwentySix)
            {
                Console.WriteLine(i.FullName);
            }

            Console.WriteLine();
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            int sumYearsOfExperience = employees
            .Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
            .Sum(x => x.YearsOfExperience);

            Console.WriteLine(sumYearsOfExperience);

            Console.WriteLine();
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            double averageYearsOfExperience = employees
                .Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
                .Average(x => x.YearsOfExperience);

            Console.WriteLine(averageYearsOfExperience);

            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Noah", "Urban", 24, 0)).ToList();

            Console.WriteLine();

            Console.ReadLine();
        }

        public static void PrintIEnum(IEnumerable<int> ienum)
        {
            foreach (var i in ienum)
            {
                Console.WriteLine(i);
            }
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
