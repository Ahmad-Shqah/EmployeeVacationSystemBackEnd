The backend of the first project (Employee Vacation System), the frontEnd of this app was built earliar and now this is the backend. 
 
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
