using EmployeeVacationSystem.Entities;
using EmployeeVacationSystem.Services.SelectServices;


namespace EmployeeVacationSystem.Services.UpdateServices
{
    public class HandelVacationRequests
    {
        //handel other's  requests.
        public static void ManageRequestsForSubordinates(VacationSystemDbContext dbContext, List<VacationRequestDTO> vacationsQry, Employee employee)
        {
            if (vacationsQry.Count != 0)
            {
                foreach (var vac in vacationsQry)
                {

                    Console.WriteLine("ID: " + vac.ID);
                    Console.WriteLine("description: " + vac.Description);
                    Console.WriteLine("Employee number: " + vac.EmployeeNumber);
                    Console.WriteLine("Employee name: " + vac.EmployeeName);
                    Console.WriteLine("Submission Date: " + vac.RequestSubmissionDate);
                    Console.WriteLine("Total days: " + vac.TotalVacationDays);
                    Console.WriteLine("Start Date: " + vac.StartDate);
                    Console.WriteLine("End Date: " + vac.EndDate);
                    Console.WriteLine("Employee Salary: " + vac.EmployeeSalary);
                    Console.WriteLine("---------------------------");
                }
                Console.Write("Enter the Vacation Request ID to handel: ");
                int ID_input = int.Parse(Console.ReadLine());
                Console.Write("Enter 1 to aprove , 2 to decline: ");
                string choise = Console.ReadLine();
                if (choise == "1")
                    HandelVacationRequests.aprove(dbContext, ID_input, employee.number);
                if (choise == "2")
                    HandelVacationRequests.decline(dbContext, ID_input, employee.number);
            }
            else
                Console.WriteLine("No data!");
        }
        //aprove function.
        public static void aprove(VacationSystemDbContext dbContext, int vacationRequestID, string manegarNumber)
        {
          var vacationRequest =  dbContext.vacationRequests.Where(v => v.ID == vacationRequestID).FirstOrDefault();

            if (vacationRequest != null)
            {
                vacationRequest.requestStateID = 2;
                vacationRequest.approvedByEmployeeNumber = manegarNumber;
                UpdateVacationDaysBalance.updateVacationDaysBalance(dbContext, vacationRequest.employeeNumber , vacationRequestID);
                dbContext.SaveChanges();
            }
           else 
            {
                Console.WriteLine("Vacation Request was not found!");
            }
        }
        //decline function.
        public static void decline(VacationSystemDbContext dbContext, int vacationRequestID, string manegarNumber)
        {
            var vacationRequest = dbContext.vacationRequests.Where(v => v.ID == vacationRequestID).FirstOrDefault();
            var employee = dbContext.employees.Where(e => e.number == manegarNumber).FirstOrDefault();

            if (vacationRequest != null)
            {
                vacationRequest.requestStateID = 3;
                vacationRequest.declinedByEmployeeNumber = manegarNumber;
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Vacation Request was not found!");
            }
        }
    }
}
