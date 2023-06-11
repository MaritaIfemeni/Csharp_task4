using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Actions
{
    public class Customer
    {
        private int _id { get; set; }
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _email { get; set; }
        private string _address { get; set; }

        public Customer(string firstName, string lastName, string email, string address)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _address = address;
            _id = GenerateUniqueId();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int GenerateUniqueId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}