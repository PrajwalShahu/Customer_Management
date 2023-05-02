namespace Customer_CRUD_Exercise
{
    class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string City { get; set; }

        public int CustId = 3;

        public int GenerateId()
        {
            Id = CustId++;
            return Id;
        }
    }

    class Management
    {
        List<Customer> customers;
        public Management()
        {
            customers = new List<Customer>()
            {
                new Customer() {Id = 1, Firstname = "Brajesh", Lastname = "Khetan", Email = "brajeshkhetan2000@gmail.com", Age = 23, Phone = 9647205912, City = "Arvi"},
                new Customer() {Id = 2, Firstname = "Bhumika", Lastname = "jaiswar", Email = "bhumikajaiswar1999@gmail.com", Age = 22, Phone = 498061823, City = "Nagpur"}
            };
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomer(int id)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            foreach (Customer customer1 in customers)
            {
                if (customer1.Id == customer.Id || customer1.Firstname == customer.Firstname)
                {
                    customer1.Id = customer.Id;
                    customer1.Firstname = customer.Firstname;
                    customer1.Lastname = customer.Lastname;
                    customer1.Email = customer.Email;
                    customer1.Age = customer.Age;
                    customer1.Phone = customer.Phone;
                    customer1.City = customer.City;
                }
            }
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    customers.Remove(customer);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
            Customer c = new Customer();
            string ans = "";

            do
            {
                Console.WriteLine("Welcome to the Customer Management app");
                Console.WriteLine("1. Add the Customer");
                Console.WriteLine("2. Get Customer Details by ID");
                Console.WriteLine("3. Get all Customers Details");
                Console.WriteLine("4. Update Customer Details");
                Console.WriteLine("5. Delete Customer by ID");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter First name");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("Enter Last name");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Enter Email");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter Age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number");
                            long phone = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            int id = c.GenerateId();
                            management.AddCustomer(new Customer { Id = id, Firstname = firstname, Lastname = lastname, Email = email, Age = age, Phone = phone, City = city });
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Enter Customer ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Customer? cust = management.GetCustomer(id);
                            if (cust == null)
                            {
                                Console.WriteLine("Product with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{cust.Id} {cust.Firstname} {cust.Lastname} {cust.Email} {cust.Age} {cust.Phone} {cust.City}");
                            }
                            break;
                        }

                    case 3:
                        {
                            foreach (var cust in management.GetCustomers())
                            {
                                Console.WriteLine($"{cust.Id} {cust.Firstname} {cust.Lastname} {cust.Email} {cust.Age} {cust.Phone} {cust.City}");
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Enter the Details to update");
                            Console.WriteLine("Enter ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter First name");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("Enter Last name");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Enter Email");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter Age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number");
                            long phone = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            management.UpdateCustomer(new Customer { Id = id, Firstname = firstname, Lastname = lastname, Email = email, Age = age, Phone = phone, City = city });
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (management.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Product with specified id does not exist");
                            }
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}