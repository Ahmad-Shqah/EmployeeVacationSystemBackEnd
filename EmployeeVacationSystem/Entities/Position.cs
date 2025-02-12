

using System.ComponentModel.DataAnnotations;

namespace EmployeeVacationSystem.Entities
{
    public class Position
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public Position(string name)
        {
            Name=name;
        }
    }
}
