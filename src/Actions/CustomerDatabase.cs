using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 2. Create `CustomerDatabase` class: This class should contain the data 
//structure used to store customer information, such as a collection of customers. It should also contain methods for adding, 
//reading, updating, deleting. Extra features:
//     - Email should be unique in the database.
//     - Implement a feature to search customers by their ID
//     - Implement an undo and redo feature which allows users to undo their last action or redo an action that they have undone

namespace src.Actions
{
    public class CustomerDatabase
    {
        private List<Customer> customers;
        private FileHelper fileHelper;

        public CustomerDatabase()
        {
            fileHelper = new FileHelper();
            customers = fileHelper.ReadCustomersFromFile();


        }

        public void AddCustomer(Customer customer)
        {
            if (customers.Any(c => c.Email == customer.Email))
            {
                throw new Exception("Email already exists in the database.");
            }

            customer.Id = customer.GenerateUniqueId();
            customers.Add(customer);
            fileHelper.WriteCustomersToFile(customers);
        }
    }
}