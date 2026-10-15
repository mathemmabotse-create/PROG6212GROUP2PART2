using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Models
{
    public class EventCategory
    {
        [Key]
        public int EventCategoryID { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventID { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        public Event Event { get; set; } = null!;

        public Category Category { get; set; } = null!;
    }
}

