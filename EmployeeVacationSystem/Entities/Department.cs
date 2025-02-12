

using System.ComponentModel.DataAnnotations;

namespace EmployeeVacationSystem.Entities
{
    public class Department
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public Department(string name)
        {
            Name=name;
        }
    }
}
