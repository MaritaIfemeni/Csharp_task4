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
        public HashSet<Customer> customerHistory;
        public Stack<HashSet<Customer>> undoStack;
        public Stack<HashSet<Customer>> redoStack;

        public CustomerDatabase()
        {
            fileHelper = new FileHelper();
            customers = fileHelper.ReadCustomersFromFile();
            customerHistory = new HashSet<Customer>(customers);
            undoStack = new Stack<HashSet<Customer>>();
            redoStack = new Stack<HashSet<Customer>>();

        }
        public void AddCustomer(Customer customer)

        {
            if (customers.Any(c => c.Email == customer.Email))
            {
                throw new Exception("Email already exists in the database.");
            }

            customer.Id = customer.GenerateUniqueId();
            customers.Add(customer);
            customerHistory.Add(customer);
            fileHelper.WriteCustomersToFile(customers);
            undoStack.Push(new HashSet<Customer>(customerHistory));
            redoStack.Clear();
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id)!;
        }
        public void UpdateCustomer(int id, Customer customer)
        {
            Customer customerToUpdate = customers.FirstOrDefault(c => c.Id == customer.Id)!;
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Address = customer.Address;
            fileHelper.WriteCustomersToFile(customers);
            undoStack.Push(new HashSet<Customer>(customerHistory));
            redoStack.Clear();
        }
        public void DeleteCustomer(int id)
        {
            fileHelper.DeleteCustomerFromFile(id);
            customers.RemoveAll(c => c.Id == id);

            undoStack.Push(new HashSet<Customer>(customerHistory));
            redoStack.Clear();
        }

        public void PrintCustomerById(int id)
        {
            fileHelper.PrintCustomerById(id);
        }

        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new HashSet<Customer>(customerHistory));
                customerHistory = undoStack.Pop();
                customers = customerHistory.ToList();
                fileHelper.WriteCustomersToFile(customers);
                Console.WriteLine("Undo successful!");
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }
        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new HashSet<Customer>(customerHistory));
                customerHistory = redoStack.Pop();
                customers = customerHistory.ToList();
                fileHelper.WriteCustomersToFile(customers);
                Console.WriteLine("Redo successful!");
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
            }
        }

    }
}