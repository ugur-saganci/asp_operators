using System;

namespace OperatorOverloadingDemo
{
    // Employee class that demonstrates operator overloading
    public class Employee
    {
        // Properties to store employee information
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize employee properties
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        // Override ToString() method to provide a formatted string representation of the employee
        public override string ToString()
        {
            return $"Employee [ID: {Id}, Name: {FirstName} {LastName}]";
        }

        // Overload the equality operator (==) to compare employees by their Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check if both objects are null
            if (ReferenceEquals(emp1, null) && ReferenceEquals(emp2, null))
                return true;

            // Check if either object is null
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return false;

            // Compare employees by their Id
            return emp1.Id == emp2.Id;
        }

        // Overload the inequality operator (!=) as operators must be overloaded in pairs
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            // Use the negation of the equality operator
            return !(emp1 == emp2);
        }

        // Override Equals method to maintain consistency with operator overloading
        public override bool Equals(object obj)
        {
            if (obj is Employee employee)
                return this == employee;
            return false;
        }

        // Override GetHashCode to maintain consistency with Equals
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create two Employee objects with different properties
            Employee employee1 = new Employee(1, "John", "Doe");
            Employee employee2 = new Employee(1, "Jane", "Smith");
            Employee employee3 = new Employee(2, "Alice", "Johnson");

            // Display employee information
            Console.WriteLine("Employee Information:");
            Console.WriteLine(employee1);
            Console.WriteLine(employee2);
            Console.WriteLine(employee3);
            Console.WriteLine();

            // Compare employees using overloaded operators and display results
            Console.WriteLine("Comparison Results:");
            Console.WriteLine($"{employee1} == {employee2}: {employee1 == employee2}");
            Console.WriteLine($"{employee1} != {employee3}: {employee1 != employee3}");

            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}