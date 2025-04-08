namespace dz11
{
    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
    }

    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm
                {
                    Name = "White Food Company",
                    FoundationDate = DateTime.Now.AddYears(-3),
                    BusinessProfile = "Marketing",
                    DirectorFullName = "John White",
                    EmployeesCount = 150,
                    Address = "London",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "Lionel Messi", Position = "Manager", Phone = "231234567", Email = "uwfugfweul@example.com", Salary = 5000 },
                        new Employee { FullName = "Cristiano Ronaldo", Position = "Developer", Phone = "987654321", Email = "papa@example.com", Salary = 4000 }
                    }
                },
                new Firm
                {
                    Name = "Black White IT",
                    FoundationDate = DateTime.Now.AddDays(-123),
                    BusinessProfile = "IT",
                    DirectorFullName = "Mike Black",
                    EmployeesCount = 200,
                    Address = "London",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "Lionel Andres", Position = "Manager", Phone = "231112223", Email = "wfwef@example.com", Salary = 4500 },
                        new Employee { FullName = "John Doe", Position = "Tester", Phone = "234567890", Email = "fwwfw@example.com", Salary = 3000 }
                    }
                },
                new Firm
                {
                    Name = "Green Market",
                    FoundationDate = DateTime.Now.AddYears(-1),
                    BusinessProfile = "Marketing",
                    DirectorFullName = "Sarah Green",
                    EmployeesCount = 90,
                    Address = "New York",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "Emily White", Position = "Manager", Phone = "237654321", Email = "di.emily@example.com", Salary = 3500 },
                        new Employee { FullName = "Robert Brown", Position = "Developer", Phone = "239876543", Email = "robert@example.com", Salary = 4200 }
                    }
                }
            };

            // task 1
            Console.WriteLine("task1");

            PrintFirms("All firms:", firms);
            PrintFirms("Firms with 'Food' in name:", firms.Where(f => f.Name.Contains("Food")));
            PrintFirms("Marketing firms:", firms.Where(f => f.BusinessProfile == "Marketing"));
            PrintFirms("Marketing or IT firms:", firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT"));
            PrintFirms("Firms with more than 100 employees:", firms.Where(f => f.EmployeesCount > 100));
            PrintFirms("Firms with employees between 100 and 300:", firms.Where(f => f.EmployeesCount >= 100 && f.EmployeesCount <= 300));
            PrintFirms("Firms in London:", firms.Where(f => f.Address == "London"));
            PrintFirms("Firms with director's name containing 'White':", firms.Where(f => f.DirectorFullName.Contains("White")));
            PrintFirms("Firms older than 2 years:", firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2));
            PrintFirms("Firms founded at least 123 days ago:", firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays >= 123));
            PrintFirms("Firms with director containing 'Black' and name containing 'White':", firms.Where(f => f.DirectorFullName.Contains("Black") && f.Name.Contains("White")));

            // task 2
            Console.WriteLine("\ntask2 (Method Syntax)");

            PrintFirms("All firms (method):", firms.ToList());
            PrintFirms("Firms with 'Food' in name (method):", firms.Where(f => f.Name.Contains("Food")).ToList());
            PrintFirms("Marketing firms (method):", firms.Where(f => f.BusinessProfile == "Marketing").ToList());
            PrintFirms("Marketing or IT firms (method):", firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList());
            PrintFirms("Firms with more than 100 employees (method):", firms.Where(f => f.EmployeesCount > 100).ToList());
            PrintFirms("Firms with employees between 100 and 300 (method):", firms.Where(f => f.EmployeesCount >= 100 && f.EmployeesCount <= 300).ToList());
            PrintFirms("Firms in London (method):", firms.Where(f => f.Address == "London").ToList());
            PrintFirms("Firms with director's name containing 'White' (method):", firms.Where(f => f.DirectorFullName.Contains("White")).ToList());
            PrintFirms("Firms older than 2 years (method):", firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2).ToList());
            PrintFirms("Firms founded at least 123 days ago (method):", firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays >= 123).ToList());
            PrintFirms("Firms with director containing 'Black' and name containing 'White' (method):", firms.Where(f => f.DirectorFullName.Contains("Black") && f.Name.Contains("White")).ToList());

            // task 3
            Console.WriteLine("\ntask3 (Employees)");

            var employeesOfFirm = firms.First().Employees;
            PrintEmployees("Employees of first firm:", employeesOfFirm);
            PrintEmployees("Employees of first firm with salary > 4000:", employeesOfFirm.Where(e => e.Salary > 4000));
            PrintEmployees("All managers:", firms.SelectMany(f => f.Employees).Where(e => e.Position == "Manager"));
            PrintEmployees("Employees with phone starting with '23':", firms.SelectMany(f => f.Employees).Where(e => e.Phone.StartsWith("23")));
            PrintEmployees("Employees with email starting with 'di':", firms.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di")));
            PrintEmployees("Employees with name containing 'Lionel':", firms.SelectMany(f => f.Employees).Where(e => e.FullName.Contains("Lionel")));

            // task 4
            Console.WriteLine("\ntask4");

            int[] numbers = { 121, 75, 81 };
            var ascending = numbers.OrderBy(n => SumOfDigits(n)).ToArray();
            var descending = numbers.OrderByDescending(n => SumOfDigits(n)).ToArray();

            Console.WriteLine("Za zrostanniam sumy tsyfr: " + string.Join(", ", ascending));
            Console.WriteLine("Za spadanniam sumy tsyfr: " + string.Join(", ", descending));

            Console.WriteLine("\nDone!");
        }

        static int SumOfDigits(int number)
        {
            return number.ToString().Sum(c => c - '0');
        }

        static void PrintFirms(string title, IEnumerable<Firm> firms)
        {
            Console.WriteLine($"\n{title}");
            foreach (var firm in firms)
            {
                Console.WriteLine($"- {firm.Name}, Director: {firm.DirectorFullName}, Employees: {firm.EmployeesCount}, Address: {firm.Address}, Profile: {firm.BusinessProfile}, Founded: {firm.FoundationDate.ToShortDateString()}");
            }
        }

        static void PrintEmployees(string title, IEnumerable<Employee> employees)
        {
            Console.WriteLine($"\n{title}");
            foreach (var e in employees)
            {
                Console.WriteLine($"- {e.FullName}, Position: {e.Position}, Phone: {e.Phone}, Email: {e.Email}, Salary: {e.Salary}");
            }
        }
    }
}
