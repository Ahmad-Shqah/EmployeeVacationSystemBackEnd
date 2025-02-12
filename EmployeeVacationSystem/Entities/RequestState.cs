

using System.ComponentModel.DataAnnotations;

namespace EmployeeVacationSystem.Entities
{
    public class RequestState
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string name { get; set; }

        public RequestState(string name)
        {
            this.name=name;
        }
    }
}
