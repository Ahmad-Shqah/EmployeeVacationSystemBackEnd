

using System.ComponentModel.DataAnnotations;

namespace EmployeeVacationSystem.Entities
{
    public class VacationType
    {
        public char code {  get; set; }

        [MaxLength(20)]
        public string name { get; set; }

        public VacationType(char code, string name)
        {
            this.code=code;
            this.name=name;
        }
    }


}
