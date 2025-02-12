using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.UpdateServices
{
    public class UpdateEmployee
    {
        public static void updateEmployeeMainInfo(VacationSystemDbContext dbContext,string employeeNumber)
        {
            //to find the wanted employee
            var employee = dbContext.employees.Where(e => e.number == employeeNumber).FirstOrDefault();

            if (employee != null)
            {
                // update the department
                if (employee.positionID == 1 || employee.positionID == 2) //CEO or Maniger
                {
                    Console.WriteLine($"Current Department ID: " + employee.departmentID);
                    Console.Write("Enter new department ID (or press Enter to keep the current department):");
                    string departmentInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(departmentInput) && int.TryParse(departmentInput, out int newDepartmentID))
                    {
                        employee.departmentID = newDepartmentID;
                    }
                }
     
                // update the position
                if (employee.positionID == 1 || employee.positionID == 2) //CEO or Maniger
                {
                    Console.WriteLine($"Current Position ID: " + employee.positionID);
                    Console.WriteLine("Enter new position ID (or press Enter to keep the current position):");
                    string positionInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(positionInput) && int.TryParse(positionInput, out int newPositionID))
                    {
                        employee.positionID = newPositionID;
                    }
                }

                // update the name
                Console.WriteLine($"Current Name: " +  employee.name);
                Console.Write("Enter new name (or press Enter to keep the current name):");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    employee.name = newName;
                }

                // update the salary
               if (employee.positionID == 1) //CEO
                {
                    Console.WriteLine($"Current Salary: "  + employee.salary);
                    Console.Write("Enter new salary (or press Enter to keep the current salary):");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(salaryInput) && decimal.TryParse(salaryInput, out decimal newSalary))
                    {
                        employee.salary = newSalary;
                    }
                }
                // Save changes to the database
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("This Employee does not exist!");
            }
        }
    }
}
