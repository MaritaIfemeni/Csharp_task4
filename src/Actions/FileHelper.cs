using System;

namespace src.Actions
{
    public class FileHelper
    {
        private const string FilePath = "customers.csv";

        public List<Customer> ReadCustomersFromFile()
        {
            List<Customer> customers = new List<Customer>();

            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    int id = int.Parse(values[0]);
                    string firstName = values[1];
                    string lastName = values[2];
                    string email = values[3];
                    string address = values[4];

                    Customer customer = new Customer(firstName, lastName, email, address);
                    customer.Id = id;
                    customers.Add(customer);
                }
            }

            return customers;
        }

        public void WriteCustomersToFile(List<Customer> customers)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var customer in customers)
                {
                    string line = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
                    writer.WriteLine(line);
                }
            }
        }

        public void DeleteCustomerFromFile(int id)
        {
            List<Customer> updatedCustomers = ReadCustomersFromFile();
            Customer customerToDelete = updatedCustomers.FirstOrDefault(c => c.Id == id)!;
            if (customerToDelete == null)
            {
                throw new Exception("Customer does not exist in the database.");
            }

            updatedCustomers.Remove(customerToDelete);
            WriteCustomersToFile(updatedCustomers);
        }

        public void PrintCustomerById(int id)
        {
            Customer customer = ReadCustomersFromFile().FirstOrDefault(c => c.Id == id)!;
            if (customer == null)
            {
                throw new Exception("Customer does not exist in the database.");
            }

            Console.WriteLine("Customer Details:");
            Console.WriteLine($"ID: {customer.Id}");
            Console.WriteLine($"First Name: {customer.FirstName}");
            Console.WriteLine($"Last Name: {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Address: {customer.Address}");
        }

    }
}
