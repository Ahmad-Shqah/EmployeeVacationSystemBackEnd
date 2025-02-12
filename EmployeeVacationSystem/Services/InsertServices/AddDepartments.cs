using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.InsertServices
{
    public class AddDepartments //by using DB context.
    {
        //Default Departments in the company --> must run in the start of the app for the first time only (this is handeled in main class).

        public static void addDefaultDepartments(VacationSystemDbContext dbContext)
        {
            //this list should be changed from company to company.

            var defaultDepartments = new List<Department>
                {
                    new Department("HR"),
                    new Department("IT"),
                    new Department("Finance"),
                    new Department("Marketing"),
                    new Department("Sales"),
                    new Department("Logistics"),
                    new Department("Operations"),
                    new Department("Customer Service"),
                    new Department("R&D"),
                    new Department("Quality Assurance"),
                    new Department("Legal"),
                    new Department("Procurement"),
                    new Department("Public Relations"),
                    new Department("Business Development"),
                    new Department("Administration"),
                    new Department("Security"),
                    new Department("Maintenance"),
                    new Department("Product Management"),
                    new Department("Training"),
                    new Department("Support")
                };

            dbContext.AddRange(defaultDepartments);
            dbContext.SaveChanges();
        }

        //Not in the requirements doc but usefull in the system. 
        public static void addDepartment(VacationSystemDbContext dbContext, Department department)
        {
            dbContext.Add<Department>(department);
            dbContext.SaveChanges();

            Console.WriteLine("The new Department was Added successfully!");

        }
    }
}
