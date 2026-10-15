using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentID { get; set; }

        public int UserID { get; set; }

        public int EventCategoryID { get; set; }

        public DateTime EnrolmentDate { get; set; }
            = DateTime.Now;

        public string Status { get; set; } = "Registered";
    }
}
