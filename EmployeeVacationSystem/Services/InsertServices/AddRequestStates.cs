

using EmployeeVacationSystem.Entities;

namespace EmployeeVacationSystem.Services.InsertServices
{
    public class AddRequestStates
    {
        public static void addDefaultRequestStates(VacationSystemDbContext dbContext)
        {
            var requestStates = new List<RequestState> { 
            new RequestState("Submitted"),
            new RequestState("Approved"),
            new RequestState("Declined")
            };
            dbContext.requestStates.AddRange(requestStates);
            dbContext.SaveChanges();
        }
    }
}
