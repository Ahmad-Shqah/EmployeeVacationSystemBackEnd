using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVacationSystem.Entities
{
    public class Employee
    {
        [Required]
        [MaxLength(6)]
        public string number { get; set; }

        [Required]
        [MaxLength(20)]
        public string name { get; set; }

        public int departmentID { get; set; }

        public int positionID { get; set; }

        [Required]
        public char genderCode  { get; set; }

      
        [MaxLength(6)]
        public string? reportedToEmployeeNumber { get; set; }

        [Range(0, 24)]
        public int vacationDaysLeft { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal salary { get; set; }

        public Employee(string number, string name, int departmentID, int positionID, char genderCode, string? reportedToEmployeeNumber, decimal salary)
        {
            this.number=number;
            this.name=name;
            this.departmentID=departmentID;
            this.positionID=positionID;
            this.genderCode=genderCode;
            this.reportedToEmployeeNumber=reportedToEmployeeNumber;
            this.vacationDaysLeft=24;
            this.salary=salary;
        }
    }
}
