using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.SelectServices
{
    public class SelectEmployeeDetails
    {
        public static void showMainDetails(VacationSystemDbContext dbContext, string employeeNumber)
        {
            var employee = dbContext.employees.Where(e => e.number == employeeNumber).FirstOrDefault();
            var department = dbContext.departments.Where(d => d.ID == employee.departmentID).FirstOrDefault();
            var Position = dbContext.positions.Where(p => p.ID == employee.positionID).FirstOrDefault();
            var manegar = dbContext.employees.Where(m => m.number == employee.reportedToEmployeeNumber).FirstOrDefault();

            if (employee != null)
            {
                Console.WriteLine("************************ Employee Details ************************");
                Console.WriteLine($"Name          : " + employee.name);
                Console.WriteLine($"Department    : " + department.Name);
                Console.WriteLine($"Position      : " + Position.Name);
                if (manegar != null)
                Console.WriteLine($"Reporting To  : " + manegar.name);
                else
                Console.WriteLine($"Reporting To  : None" );

                Console.WriteLine("******************************************************************");
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
        }


    }
}
