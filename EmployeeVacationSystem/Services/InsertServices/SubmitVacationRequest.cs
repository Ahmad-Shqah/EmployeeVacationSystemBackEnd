using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.InsertServices
{
    public class SubmitVacationRequest
    {
        //add new vacation request.
        public static void submitVacationRequest(VacationSystemDbContext dbContext, Employee user)
        {
            string employeeNumber = user.number;

            // let the user enter these values form UI ( consol ). 


            //check if employee is exist.
            var employee = dbContext.employees.Where(e => e.number == employeeNumber).FirstOrDefault();
                 while(employee == null)
                  {
                       Console.Write("Wrong number please try again : ");
                       employeeNumber = Console.ReadLine();
                  }
         //Check if employee still has days off
                if (employee.vacationDaysLeft <= 0)
            {
                Console.WriteLine("Sorry no Vacation days left!");
                return;
            }

            Console.Write("Enter the vacation request submission date (YYYY-MM-DD): ");
            DateTime requestSubmissionDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the description of the vacation request: ");
            string description = Console.ReadLine();

            Console.Write("Enter the vacation type code (e.g., 'A' for annual, 'S' for sick leave, etc.): ");
            char vacationTypeCode = Console.ReadLine()[0];

            Console.Write("Enter the vacation start date (YYYY-MM-DD): ");
            DateOnly startDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter the vacation end date (YYYY-MM-DD): ");
            DateOnly endDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter the total number of vacation days: ");
            int totalVacationDays = int.Parse(Console.ReadLine());


            // calling the constructor to make the new vacation request.
            var newVacationRequest = new VacationRequest(requestSubmissionDate,description,employeeNumber,vacationTypeCode,startDate,endDate,totalVacationDays);
            // if two Vacation Requests have same start date, then there is over lap:

            //  1.get all user's vacation requests.
            var userVacationRequests = dbContext.vacationRequests.Where(v => v.employeeNumber == user.number);

            //  2. check if there is an overlap --> there might be more senarios for overlaping but its esiar to handel them by the user.
            var possibleRedandantRequest = userVacationRequests.Where(v => v.startDate == newVacationRequest.startDate).FirstOrDefault();
            if (possibleRedandantRequest != null)
            {
                Console.WriteLine("Error: Overlap!");
                return;
            }
 
            //if no over lap, then add to database.
            dbContext.vacationRequests.Add(newVacationRequest);
            dbContext.SaveChanges();
            Console.WriteLine("Vacation request submitted successfully!");
        }

    }
}
