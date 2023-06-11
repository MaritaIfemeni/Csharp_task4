using System;
using src.Actions;

public class Program
{
    public static void Main(string[] args)
    {
        CustomerDatabase database = new CustomerDatabase();
        Console.WriteLine("Welcome to the Customer Database!");

        string choice = string.Empty;
        while (choice != "7")
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. Update a customer");
            Console.WriteLine("3. Search for a customer by id");
            Console.WriteLine("4. Delete a customer");
            Console.WriteLine("5. Undo");
            Console.WriteLine("6. Redo");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter customer first name: ");
                    string firstName = Console.ReadLine()!;
                    Console.Write("Enter customer last name: ");
                    string lastName = Console.ReadLine()!;
                    Console.Write("Enter customer email: ");
                    string email = Console.ReadLine()!;
                    Console.Write("Enter customer address: ");
                    string address = Console.ReadLine()!;
                    Customer customer = new Customer(firstName, lastName, email, address);
                    try
                    {
                        database.AddCustomer(customer);
                        Console.WriteLine("Customer added successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "2":
                    Console.Write("Enter customer ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Customer customerToUpdate = database.GetCustomerById(id);
                    if (customerToUpdate == null)
                    {
                        Console.WriteLine("Customer not found in the database.");
                        break;
                    }

                    Console.WriteLine("Enter the updated details for the customer:");
                    Console.Write("First Name: ");
                    string updatedFirstName = Console.ReadLine()!;
                    Console.Write("Last Name: ");
                    string updatedLastName = Console.ReadLine()!;
                    Console.Write("Email: ");
                    string updatedEmail = Console.ReadLine()!;
                    Console.Write("Address: ");
                    string updatedAddress = Console.ReadLine()!;

                    customerToUpdate.FirstName = updatedFirstName;
                    customerToUpdate.LastName = updatedLastName;
                    customerToUpdate.Email = updatedEmail;
                    customerToUpdate.Address = updatedAddress;
                    try
                    {
                        database.UpdateCustomer(id, customerToUpdate);
                        Console.WriteLine("Customer updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    Console.Write("Enter customer ID you want to find: ");
                    int searchId = int.Parse(Console.ReadLine()!);
                    try
                    {
                        database.PrintCustomerById(searchId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "4":
                    Console.Write("Enter customer ID you want to delete: ");
                    int deleteId = int.Parse(Console.ReadLine()!);
                    try
                    {
                        database.DeleteCustomer(deleteId);
                        Console.WriteLine("Customer deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "5":
                    database.Undo();
                    break;
                case "6":
                    database.Redo();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }
}
