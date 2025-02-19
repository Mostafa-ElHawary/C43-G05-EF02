using C43_G05_EF02.Context;
using C43_G05_EF02.Entities;

namespace C43_G05_EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AppDbContext appDbContext = new AppDbContext();
            // building CRUD operations on Employee Table
            // Create | Read | Update | Delete


            // Assignment 
            // 1.Do CRUD operations on all tables (Use Previous Assignment)

            // Create 

            using (AppDbContext context = new AppDbContext())
            {
                var employee = new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    Address = "123 Main St, Anytown, USA",
                    Position = "Software Developer",
                    Salary = 60000.00m,
                    DateOfJoining = new DateTime(2020, 1, 1)
                };

                context.Employees.Add(employee);
                context.SaveChanges();
            }

            // Read
            using (AppDbContext context = new AppDbContext())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Email == "john.doe@example.com");
                if (employee != null)
                {
                    Console.WriteLine($"Employee found: {employee.FirstName} {employee.LastName}");
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
            }

            // Update
            using (AppDbContext context = new AppDbContext())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Email == "john.doe@example.com");
                if (employee != null)
                {
                    employee.Salary = 65000.00m;
                    context.SaveChanges();
                    Console.WriteLine("Employee salary updated");
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
            }

            // Delete
            using (AppDbContext context = new AppDbContext())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Email == "john.doe@example.com");
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employee deleted");
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
            }
        }
    }
}
