using System.ComponentModel.DataAnnotations;

namespace EmployeeVacationSystem.Entities
{
    public class VacationRequest
    {
        public int ID {  get; set; }

        [Required]
        public DateTime requestSubmissionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string description {  get; set; }

        public string employeeNumber { get; set; }

        public char vacationTypeCode {  get; set; }

        [Required]
        public DateOnly startDate { get; set; }

        [Required]
        public DateOnly endDate { get; set; }

        [Required]
        public int totalVacationDays {  get; set; }

        [Required]
        public int requestStateID {  get; set; }

        public string? approvedByEmployeeNumber  {  get; set; }

        public string? declinedByEmployeeNumber { get; set; }

        public VacationRequest(DateTime requestSubmissionDate, string description, string employeeNumber, char vacationTypeCode, DateOnly startDate, DateOnly endDate, int totalVacationDays)
        {
            this.requestSubmissionDate=requestSubmissionDate;
            this.description=description;
            this.employeeNumber=employeeNumber;
            this.vacationTypeCode=vacationTypeCode;
            this.startDate=startDate;
            this.endDate=endDate;
            this.totalVacationDays=totalVacationDays;
            this.requestStateID=1;//submeted, (pending) as a default value.
            this.approvedByEmployeeNumber=null;
            this.declinedByEmployeeNumber=null;
        }
    }
}
