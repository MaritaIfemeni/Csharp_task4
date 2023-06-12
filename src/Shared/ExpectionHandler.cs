using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace src.Shared
{
    public class ExpectionHandler
    {
        public static void HandleExpextion(Exception ex)
        {
            Console.WriteLine("There has been an error: " + ex.Message);
        }

    }
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string email) : base("Email: " + email + " already exists in the database.")
        {
            Console.WriteLine("Duplicate email exception occurred.");
        }
    }

    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string id) : base("Id: " + id + " does not exist in the database.")
        {
            Console.WriteLine("Customer not found exception occurred.");
        }
    }

}