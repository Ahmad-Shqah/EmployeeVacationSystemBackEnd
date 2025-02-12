

using Azure.Core;
using EmployeeVacationSystem.Entities;

namespace EmployeeVacationSystem.Services.SelectServices
{
    public class VacationRequestDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime RequestSubmissionDate { get; set; }
        public int TotalVacationDays { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal EmployeeSalary { get; set; }
    }

    public class SelectVacationRequest
    {
        //forth LINQ
        public static void showAprovedRequestsHistory(VacationSystemDbContext dbContext, Employee employee)
        {
            var vacationsQry = (from vac in dbContext.vacationRequests
                                join vType in dbContext.vacationTypes
                                on vac.vacationTypeCode equals vType.code
                                join approver in dbContext.employees
                                on vac.approvedByEmployeeNumber equals approver.number into approverJoin
                                from approver in approverJoin.DefaultIfEmpty() // Ensures a left join
                                where vac.employeeNumber == employee.number && vac.requestStateID == 2
                                select new
                                {
                                    VacationType = vType.name,
                                    vac.description,
                                    vac.totalVacationDays,
                                    approvedBy = approver.name  
                                }).ToList();
            if (vacationsQry.Count != 0)//not Empty.
                foreach (var vac in vacationsQry)
                {
                    Console.WriteLine("VacationType: " + vac.VacationType);
                    Console.WriteLine("description: " + vac.description);
                    Console.WriteLine("Total Vacation Days: " + vac.totalVacationDays);
                    Console.WriteLine("aprovedBy:" + vac.approvedBy);
                    Console.WriteLine("---------------------------");

                }
            else
                Console.WriteLine("No data!");
        }
        //Fifth LINQ
        public static List<VacationRequestDTO> vacationsShouldEmployeeTakeActionOn(VacationSystemDbContext dbContext, Employee manager)
        {
              
                   var vacationQry = (from vac in dbContext.vacationRequests
                               join emp in dbContext.employees
                               on vac.employeeNumber equals emp.number
                               where emp.reportedToEmployeeNumber == manager.number
                               && vac.requestStateID == 1
                               select new VacationRequestDTO
                               {
                                   ID = vac.ID,
                                   Description = vac.description,
                                   EmployeeNumber = emp.number,
                                   EmployeeName = emp.name,
                                   RequestSubmissionDate = vac.requestSubmissionDate,
                                   TotalVacationDays = vac.totalVacationDays,
                                   StartDate = vac.startDate,
                                   EndDate = vac.endDate,
                                   EmployeeSalary = emp.salary
                               }).ToList();

                return vacationQry;
           
             
        }



    }
}
