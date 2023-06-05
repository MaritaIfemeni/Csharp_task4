using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Actions
{
    public class CustomerDatabase
    {
        List<Customer> customers = new List<Customer>();

        public bool addCustomer(Customer customer)
        {
            customers.Add(customer);
            return true;
        }

        public string readCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            return customer.ToString();

        }

        public bool updateCustomer(int id, Customer customer)
        {

        }

        public bool deleteCustomer(int id)
        {

        }
    }
}