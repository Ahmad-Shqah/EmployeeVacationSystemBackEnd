using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.InsertServices
{
    public class AddVacationTypes
    {
        public static void addDefaultVacationTypes(VacationSystemDbContext dbContext)
        {
            var vacationTypes = new List<VacationType>
        {
            new VacationType('S', "Sick"),
            new VacationType('U', "Unpaid"),
            new VacationType('A', "Annual"),
            new VacationType('O', "Day Off"),
            new VacationType('B', "Business Trip")
        };
            dbContext.vacationTypes.AddRange(vacationTypes);
            dbContext.SaveChanges();
        }

        //Not in the requirements doc but usefull in the system. 
        public static void addVacationType(VacationSystemDbContext dbContext, VacationType vacationType) 
        {
            dbContext.vacationTypes.Add(vacationType);
            dbContext.SaveChanges();

            Console.WriteLine("The new Vacation Type was Added successfully!");

        }
    }
}
