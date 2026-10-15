using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }

        public int EventID { get; set; }

        public int UserID { get; set; }

        public int Position { get; set; }

        public TimeSpan FinishTime { get; set; }

        public string Status { get; set; } = "Completed";
    }
}