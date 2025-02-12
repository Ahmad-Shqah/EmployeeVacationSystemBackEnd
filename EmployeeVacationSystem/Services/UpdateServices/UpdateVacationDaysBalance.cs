using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.UpdateServices
{
    public class UpdateVacationDaysBalance
    {
        public static void updateVacationDaysBalance(VacationSystemDbContext dbContext,string employeeNumber , int vacationRequestID)
        {
         var vacationRequest = dbContext.vacationRequests.Where(v => v.ID == vacationRequestID).FirstOrDefault();
         var employee = dbContext.employees.Where(e => e.number == employeeNumber).FirstOrDefault();


            //extra check.
            if (vacationRequest != null && vacationRequest.requestStateID == 2  ) 
            {
                employee.vacationDaysLeft -= vacationRequest.totalVacationDays;
            }
            dbContext.SaveChanges();
        }
    }
}
