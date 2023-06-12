using src.Shared;

namespace src.Actions
{
    public class FileHelper
    {
        private const string _filePath = "src/Data/customers.csv";
        public FileHelper()
        {
            if (!File.Exists(_filePath))
            {
                throw new CustomerFileNotFoundException(_filePath);
            }
        }
        public List<Customer> ReadCustomersFromFile()
        {
            List<Customer> customers = new List<Customer>();
            var lines = File.ReadAllLines(_filePath);
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
            return customers;
        }
        public void WriteCustomersToFile(List<Customer> customers)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var customer in customers)
                {
                    string line = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
                    writer.WriteLine(line);
                }
            }
        }
        public void PrintCustomerById(int id)
        {
            Customer customer = ReadCustomersFromFile().FirstOrDefault(c => c.Id == id)!;
            if (customer == null)
            {
                throw new CustomerNotFoundException(id.ToString());
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
