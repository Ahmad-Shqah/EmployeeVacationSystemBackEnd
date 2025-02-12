using EmployeeVacationSystem.Entities;


namespace EmployeeVacationSystem.Services.InsertServices
{
    public class AddPositions //by using DB Set.
    {
        public static void addDefaultPositions(VacationSystemDbContext dbContext)
        {
            //this list should be changed from company to company.

            var defaultPositions = new List<Position>
                {
                    new Position("CEO"),
                    new Position("Manager"),
                    new Position("Software Engineer"),
                    new Position("Accountant"),
                    new Position("HR Specialist"),
                    new Position("Marketing Coordinator"),
                    new Position("Sales Executive"),
                    new Position("Logistics Officer"),
                    new Position("Operations Supervisor"),
                    new Position("Customer Support"),
                    new Position("Research Analyst"),
                    new Position("Quality Control Inspector"),
                    new Position("Legal Advisor"),
                    new Position("Procurement Officer"),
                    new Position("Public Relations Officer"),
                    new Position("Business Development Executive"),
                    new Position("Administrative Assistant"),
                    new Position("Security Officer"),
                    new Position("Maintenance Technician"),
                    new Position("Product Manager"),
                    new Position("Training Coordinator")
                };

            dbContext.positions.AddRange(defaultPositions);
            dbContext.SaveChanges();
        }

         //Not in the requirements doc but usefull in the system. 
        public static void addPosition(VacationSystemDbContext dbContext, Position position)
        {
            dbContext.positions.Add(position);
            dbContext.SaveChanges();

           Console.WriteLine("The new Position was Added successfully!");

        }
    }
}
