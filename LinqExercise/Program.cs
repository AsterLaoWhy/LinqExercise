using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
             * Rather than submit 2 repos, this exercise took all of 3 minutes so I was hoping submitting only one combined repo would be ok
    Create a list of type string.
    Populate the list with video game names.
        Alternatively, you can choose a different category of items if you prefer. ex. list of baseball teams, list of movie titles, etc.
    Order the list of games by the length of the game name.
        Remember to use LINQ which involves using a lambda expression.
        Use the list of common LINQ methods on the lecture page for help on deciding which method(s) to use:
        Linq Methods
        Use Method Syntax for this exercise.
    Stage, Commit, and Push your work to Github.
*/
            var leagueOfLegendsCharacters = new List<string>() {"Ahri","Syndra", "Blitz","Ori","Kha-Zix", "Zed","Trundle" };
            foreach (var i in leagueOfLegendsCharacters.OrderBy(i => i)) Console.WriteLine(i);
            Console.WriteLine($"------------------------------\n");
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"{numbers.Sum()}\n");
            Console.WriteLine($"------------------------------\n");
            //TODO: Print the Average of numbers
            Console.WriteLine($"{numbers.Average()}\n");
            Console.WriteLine($"------------------------------\n");
            //TODO: Order numbers in ascending order and print to the console
            var orderedNumbers = numbers.OrderBy(i => i);
            foreach (var i in orderedNumbers)
            {
                Console.WriteLine($"{i}\n");
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Order numbers in descending order and print to the console
            var oppositeOrderedNumbers = numbers.OrderByDescending(i => i);
            foreach (var i in oppositeOrderedNumbers)
            {
                Console.WriteLine($"{i}\n");
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Print to the console only the numbers greater than 6
            var biggerNumbers = numbers.Where(i => i>6);
            foreach (var i in biggerNumbers)
            {
                Console.WriteLine($"{i}\n");
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            
            int numberCounter = 0;
            foreach (var i in oppositeOrderedNumbers)
            {
                if (numberCounter >= 4) break;
                Console.WriteLine($"{i}\n");
                numberCounter += 1;
                
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 29;
            var newOppositeOrderedNumbers = numbers.OrderByDescending(i => i);
            foreach (var i in newOppositeOrderedNumbers)
            {
                Console.WriteLine($"{i}\n");
            }
            Console.WriteLine($"------------------------------\n");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName. THERE MUST BE A BETTER WAY TO DO THIS
            //var names = new List<string>() { "C", "S" };
            var sFirstName = employees.Where(name => name.FirstName.Contains("S")||name.FirstName.Contains("C")); 
            //var cFirstName = employees.Where(name => name.FirstName.Contains("C"));
            var newFirstNames = new List<string>();
            /*foreach (var i in cFirstName)
            {
                newFirstNames.Add(i.FirstName);
            }
            */
            foreach (var i in sFirstName)
            {
                newFirstNames.Add(i.FirstName);
            }
            foreach (var i in newFirstNames.OrderBy(i=>i))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var oldEmployees = employees.Where(age => age.Age > 26);

            foreach(var i in oldEmployees.OrderBy(i=>i.Age).ThenBy(i=>i.FirstName)) 
            {
                Console.WriteLine($"{i.FirstName} is {i.Age}");
            }
            Console.WriteLine($"------------------------------\n");
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yearExp = employees.Where(i => i.YearsOfExperience <= 10).Where(i => i.Age > 35);
            int yoeSum = 0;
            foreach(var i in yearExp)
            {
                yoeSum += i.YearsOfExperience;
            }
            Console.WriteLine(yoeSum);
            Console.WriteLine($"------------------------------\n");
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgYOE = yoeSum / yearExp.Count();
            Console.WriteLine(avgYOE);
            Console.WriteLine($"------------------------------\n");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees[employees.Count()-1] = new Employee ("Jon", "Rylatt", 29, 10);
            Console.WriteLine();

            Console.ReadLine();
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
