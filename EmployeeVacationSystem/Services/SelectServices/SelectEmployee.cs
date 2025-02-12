

using EmployeeVacationSystem.Entities;

namespace EmployeeVacationSystem.Services.SelectServices
{
    public class SelectEmployee
    {
        //First LINQ 
        public  static void  getAllEmployees(VacationSystemDbContext dbContext)
        {
            // we need data from two tables : emplotee and department. 
            var employeesQry = (from emp in dbContext.employees 
                                join dept in dbContext.departments
                                on emp.departmentID equals  dept.ID
                                select new 
                                {
                                    emp.number,
                                    emp.name,
                                    deptName = dept.Name,
                                    emp.salary
                                });
            //print info
            if (employeesQry != null ) 
            foreach(var  emp in employeesQry ) 
            {
                Console.WriteLine("Number: " + emp.number);
                Console.WriteLine("Name: " + emp.name); 
                Console.WriteLine("Department: " + emp.deptName);   
                Console.WriteLine("Salary: " + emp.salary);
                Console.WriteLine("--------------------------");
            }
        }
        //Second LINQ 
        public static void getEmployeeByNumber(VacationSystemDbContext dbContext, string employeeNumber)
        {
            // we need data from three tables : employee, department and Position.
            var employeeQry = (from emp in dbContext.employees
                               join dept in dbContext.departments on emp.departmentID equals dept.ID
                               join pos in dbContext.positions on emp.positionID equals pos.ID
                               join manager in dbContext.employees
                               on emp.reportedToEmployeeNumber equals manager.number into managerGroup
                               from manager in managerGroup.DefaultIfEmpty()  // LEFT JOIN for employees with no manager
                               where emp.number == employeeNumber
                               select new
                               {
                                   emp.number,
                                   emp.name,
                                   deptName = dept.Name,
                                   posName = pos.Name,
                                   managerName = manager != null ? manager.name : "No Manager",
                                   emp.vacationDaysLeft
                               }).FirstOrDefault();

            //print info
            if (employeeQry != null)
            {
                Console.WriteLine("Number: " + employeeQry.number);
                Console.WriteLine("Name: " + employeeQry.name);
                Console.WriteLine("Department: " + employeeQry.deptName);
                Console.WriteLine("Postion: " + employeeQry.posName);
                Console.WriteLine("Reported To : " + employeeQry.managerName);
                Console.WriteLine("Total vacation days left: " + employeeQry.vacationDaysLeft);
            }
            else
                Console.WriteLine("No such a number! ");
        }
        //third LINQ
        public static void getEmployeesThatHasPendingRequests(VacationSystemDbContext dbContext) 
        {
            //we need data from two tables : employee and vacationRequests. 
            var employeesQry = (from emp in dbContext.employees
                                join vac in dbContext.vacationRequests
                                on emp.number equals vac.employeeNumber
                                where vac.requestStateID == 1
                                select emp.name).Distinct().ToList();
            int counter = 1;
            if (employeesQry.Count != 0)
                foreach (var emp in employeesQry )
            {
                Console.WriteLine(counter +". "+ emp);
                Console.WriteLine("--------------------");
                counter++;
            }
            else
                Console.WriteLine("No data!");
        }
    }
}
