using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunyaiM_Assign1.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public string EventTitle { get; set; }
        //Add display name
        [Required]
        [DisplayName("Description")]
        public string EventDescription { get; set; }
        [Required]
        [DisplayName("Start date")]
        public DateTime EventStartDate { get; set; }

        [DisplayName("End date")]
        public DateTime? EventEndDate { get; set; }

        [Required]
        [DisplayName("Location")]
        public string EventLocation { get; set; }

        [Required]
        public  int EventMaxAttendees { get; set; }

        public int EventRegistrations { get; set; } = 0;

        public ICollection<Attendee> Attendees { get; set; }   //Navigation property

    }
}
