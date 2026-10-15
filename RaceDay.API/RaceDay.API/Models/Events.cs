using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        [Range(0.01, 10000)]
        public decimal Distance { get; set; }

        [Required]
        [RegularExpression("^(RUN|WALK|CYCLE)$")]
        public string EventType { get; set; } = "RUN";

        [Required]
        public string Status { get; set; } = "UPCOMING";

        public int OrganiserID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<EventCategory> EventCategories { get; set; }
            = new List<EventCategory>();
    }
}

