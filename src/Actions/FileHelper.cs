using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    customer.Id = id; // Set the ID explicitly
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
    }
}