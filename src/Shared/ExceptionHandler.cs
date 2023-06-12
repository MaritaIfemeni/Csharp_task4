
namespace src.Shared
{
    public class ExceptionHandler
    {
        public static void HandleException(Exception ex)
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
    public class CustomerFileNotFoundException : Exception
    {
        public CustomerFileNotFoundException(string filePath) : base("File: " + filePath + " does not exist.")
        {
            Console.WriteLine("Customer file not found exception occurred. You need to create a file called customers.csv in the Data folder.");
        }
    }
}