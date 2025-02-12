using EmployeeVacationSystem.Entities;

namespace EmployeeVacationSystem.Services.InsertServices
{
    public class AddEmployees
    {
        //Default Employees in the company --> must run in the start of the app for the first time only (this is handeled in main class).
        public static void addDefaultEmployees(VacationSystemDbContext dbContext)
        {
            //this list should be changed from company to company.
           var defaultEmployees = new List<Employee>
            {
                new Employee("E1001", "Ahmad Ali", 1, 1, 'M', null, 2000.50m),
                new Employee("E1002", "Mohammad Saeed", 2, 3, 'M', "E1001", 1500.75m),
                new Employee("E1003", "Omar Khaled", 3, 5, 'M', "E1002", 1800.25m),
                new Employee("E1004", "Kareem Hassan", 4, 2, 'M', null, 2200.90m),
                new Employee("E1005", "Ali Mahmoud", 5, 4, 'M', "E1003", 1300.60m),
                new Employee("E1006", "Yousef Nasser", 6, 6, 'M', "E1004", 1750.30m),
                new Employee("E1007", "Hassan Fadel", 7, 7, 'M', null, 1600.85m),
                new Employee("E1008", "Salma Tariq", 8, 8, 'F', "E1005", 1400.40m),
                new Employee("E1009", "Lina Adel", 9, 9, 'F', null, 1900.20m),
                new Employee("E1010", "Mariam Sami", 10, 10, 'F', "E1006", 2100.95m),
                new Employee("E1011", "Tariq Hassan", 11, 11, 'M', "E1007", 1700.45m),
                new Employee("E1012", "Faisal Saeed", 12, 12, 'M', "E1008", 1550.60m),
                new Employee("E1013", "Nour Ahmad", 13, 13, 'F', "E1009", 1850.75m),
                new Employee("E1014", "Sara Khalil", 14, 14, 'F', "E1010", 2000.30m),
                new Employee("E1015", "Adnan Fadel", 15, 15, 'M', null, 1950.90m),
                new Employee("E1016", "Jamal Hasan", 16, 16, 'M', "E1011", 1450.85m),
                new Employee("E1017", "Layla Omar", 17, 17, 'F', "E1012", 1650.40m),
                new Employee("E1018", "Rami Saad", 18, 18, 'M', "E1013", 1750.95m),
                new Employee("E1019", "Fatima Karim", 19, 19, 'F', null, 2050.20m),
                new Employee("E1020", "Zaid Khaled", 20, 20, 'M', "E1015", 1850.10m),
                new Employee("E1021", "Amira Tariq", 5, 4, 'F', "E1016", 1600.75m),
                new Employee("E1022", "Bilal Hadi", 8, 7, 'M', "E1017", 1700.55m),
                new Employee("E1023", "Rania Nabil", 10, 9, 'F', "E1018", 1900.85m),
                new Employee("E1024", "Othman Sami", 12, 11, 'M', "E1019", 1750.65m),
                new Employee("E1025", "Huda Ameen", 15, 14, 'F', null, 2100.45m),
                new Employee("E1026", "Saif Rahman", 18, 16, 'M', "E1020", 1550.30m),
                new Employee("E1027", "Dalia Hassan", 6, 5, 'F', "E1021", 1650.70m),
                new Employee("E1028", "Waleed Tamer", 9, 8, 'M', "E1022", 1800.55m),
                new Employee("E1029", "Mona Faisal", 13, 12, 'F', "E1023", 1950.90m),
                new Employee("E1030", "Yasir Sameer", 17, 15, 'M', "E1024", 2200.80m)
            };
            dbContext.AddRange(defaultEmployees);
            dbContext.SaveChanges();
        }

        //Not in the requirements doc but usefull in the system. 
        public static void addEmployee(VacationSystemDbContext dbContext, Employee employee)
        {
            dbContext.employees.Add(employee);
            dbContext.SaveChanges();

            Console.WriteLine("The new Employee was Added successfully!");
        }

    }
}
