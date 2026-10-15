using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models

{
    public class Registration

    {
        [Key]
        public int RegistrationID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public int EventID { get; set; }
        public Event Event { get; set; } = null!;
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public int? BibNumber { get; set; }
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

    }

}



