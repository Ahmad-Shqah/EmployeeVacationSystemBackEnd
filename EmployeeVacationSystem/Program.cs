
using EmployeeVacationSystem.Entities;
using EmployeeVacationSystem.Services.InsertServices;
using EmployeeVacationSystem.Services.SelectServices;
using EmployeeVacationSystem.Services.UpdateServices;
    

namespace MyApp
{
    public class Program
    {
        // please check the Notes list at the bottom of the code.
        static void Main(string[] args)
        {
            // my dbContext object.
            VacationSystemDbContext db = new VacationSystemDbContext();

            //Check if DataBase is empty or not.
            //this case should fell the Database with its initial values (default values).
            bool isDatabaseEmpty = !db.employees.Any() && !db.departments.Any() && !db.positions.Any();//...
            if (isDatabaseEmpty)
            {
                AddDepartments.addDefaultDepartments(db);
                AddPositions.addDefaultPositions(db);
                AddEmployees.addDefaultEmployees(db);
                AddRequestStates.addDefaultRequestStates(db);
                AddVacationTypes.addDefaultVacationTypes(db);
            }
            //The Main menu (first page )
            while (true) 
            {
                Console.WriteLine("******************************* Company X Vacation System ******************************************");
                Console.WriteLine();
                Console.WriteLine("<=================== Welcome ===================>");
                Console.WriteLine("1. Log in.");
                Console.WriteLine("2. View all employees.");
                Console.WriteLine("3. Get employee by thier number.");
                Console.WriteLine("4. Exit");
                Console.WriteLine("<===============================================>");
                Console.Write("Enter your action please: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                      var username = loginPage(db);
                        if (username == null)
                            break;
                        else
                        employeeHomePage(db,username);
                        break;
                    case "2":
                        Console.Clear();
                        SelectEmployee.getAllEmployees(db);
                        break;
                    case "3":
                        Console.Clear();        
                        Console.Write("Enter the employee number:");
                        SelectEmployee.getEmployeeByNumber(db, Console.ReadLine());
                         break;
                    case "4":
                        Console.WriteLine("Exiting the system...");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please enter (1 - 4).");
                        break;
                }
            }
        }
        // Login function: simple function , just checks for name (login based on employee  name).
        public static Employee loginPage(VacationSystemDbContext dbContext)
        {
            Console.Clear();
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            var userEmployee = dbContext.employees.Where(e => e.name == username).FirstOrDefault();

            if (userEmployee != null)
                return userEmployee;
            else
                Console.WriteLine("No such a name like that. Please check your name then try again!");
            return null;
        }


        //second page (user has loged in).
        public static void employeeHomePage(VacationSystemDbContext dbContext,Employee employee)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("<=================== Welcome back " + employee.name +" ===================>");
                Console.WriteLine("1. View My Information.");
                Console.WriteLine("2. Update My Information.");
                Console.WriteLine("3. Manage Vacation Requests.");
                Console.WriteLine("4. Get all employees that have pending requests.");
                Console.WriteLine("5. logout");
                Console.WriteLine("<=========>");
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SelectEmployeeDetails.showMainDetails(dbContext,employee.number);
                        break;
                    case "2":
                        Console.Clear();
                        UpdateEmployee.updateEmployeeMainInfo(dbContext,employee.number);
                        break;
                    case "3":
                        Console.Clear();
                        manageVacationRequests(dbContext,employee);
                        break;
                    case "4":
                        SelectEmployee.getEmployeesThatHasPendingRequests(dbContext);
                        break;
                    case "5":
                        Console.Clear();
                        return;//retun to the first page.
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option (1-5).");
                        break;
                }
            }
        }
        //third page (vacation request manager).
        public static void manageVacationRequests(VacationSystemDbContext dbContext, Employee employee) 
        {
         
          while(true)
            {
                Console.WriteLine("<===========================================>");
                Console.WriteLine("Please enter the Vacation Request option: ");
                Console.WriteLine();
                Console.WriteLine("1. View approved requests history.");
                Console.WriteLine("2. Submit new Vacation request.");
                Console.WriteLine("3. Manage requests for subordinates.");
                Console.WriteLine("4. Back");
                Console.WriteLine("<=========>");
                Console.Write("Enter your choice: ");
                string manageVacationOption = Console.ReadLine();
                switch (manageVacationOption)
                {
                    case "1":
                      SelectVacationRequest.showAprovedRequestsHistory(dbContext,employee);
                        break;

                    case "2":
                        SubmitVacationRequest.submitVacationRequest(dbContext, employee);
                        break;

                    case "3":
                        HandelVacationRequests.ManageRequestsForSubordinates(dbContext ,SelectVacationRequest.vacationsShouldEmployeeTakeActionOn(dbContext, employee), employee);
                        
                        break;

                    case "4":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option (1-4).");
                        break;
                }
            }

        }


    }
}//the end.

/*
 Note lists:-

    1. consol app design: 
                            frist page  :  login page based on employee name only (username) , no password requered.
                            second page :  user main menu that  include many options.
                            third page  :  vacation requests page.

    2. System design: 
              The system is at two levels of coding :

                           lvl 1 : top lvl --> - Program main class where it contains all menues and options that the system offers.
                                               - this lvl should be replaced with Frontend application in real products.

                           lvl 2 : bottom lvl --> bulit as 2 main parts :

                                                                  Part1 : Entities including dbContext class , this part is to build the database.
                                                                  Part2 : Services with three types :
                                                                                                      Insert : handels add_CRUD_Operation.
                                                                                                      update : handels update_CRUD_Operation.
                                                                                                      select : handels LINQ Operations.
 
3. Requirements achivement: 
            The Project achives requirements as follow : (as a logic, the usage of this logic is in main class)

                        First Objective: (Database Design & Migration)                                   --> At bottom lvl Part1 (Entities including dbcontext).
                        Second Objective: (CRUD Operations Using Entity Framework Core)                  --> (1 - 3) At bottom lvl Part2 Services (Insert Services).
                                                                                                             (4 , 5) At bottom lvl Part2 Services (Update Services).
                        Third Objective: Apply CRUD operation in EF core on Vacation request full cycle  --> (1) At bottom lvl Part2 Services (Insert Services).
                                                                                                             (2) At bottom lvl Part2 Services (Select Services).
                        Fourth Objective:                                                                --> (1-5) At bottom lvl Part2 Services (Select Services).

4.Other Notes :
    a) I had to add more data than the requered at Second Objective as you asked in the Fourth Objective.
    b) some Operations  and parts of the project might not be in the requirement document but it had to be added to make the system more logical.
    c) SomeTimes main menu does not show when running the system just press any key it will show :) .
    d) login is based  on  employee name  without password as the  requerment did not ask for login system but the login system was added to make the project  testable as consol app.
    e) In Fourth Objective the task askes to return data but this will not be shown in the consol app so i printed it on consol inestad (still it can easialy be retuerned).
    f) The vacation requests must be added manually.
 */