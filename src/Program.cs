using System;
using src.Actions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        CustomerDatabase database = new CustomerDatabase();
        Customer customer1 = new Customer("John", "Doe", "john@example.com", "123 Main St");
        try
        {
            database.AddCustomer(customer1);
            Console.WriteLine("Customer added successfully. ID: " + customer1.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding customer1: {ex.Message}");
        }

        Customer customer2 = new Customer("Jane", "Smith", "john2@example.com", "456 Elm St");
        try
        {
            database.AddCustomer(customer2);
            Console.WriteLine("Customer added successfully. ID: " + customer2.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding customer2: {ex.Message}");
        }


    }
}