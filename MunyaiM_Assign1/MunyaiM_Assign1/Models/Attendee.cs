using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunyaiM_Assign1.Models
{
    public class Attendee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendeeId { get; set; }
        [Required]
        public int EventId { get; set; }

        [Required(ErrorMessage ="Please enter your name")]
        [DisplayName("Name")]
        public string AttendeeName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage ="Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@".+\\@.+\\..+", ErrorMessage = " Please enter a valid email address")]
        public string Email { get; set; }
    }
}
