using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Number { get; set; }

        [Required]
        [Display(Name = "E-mail Address")]
        [StringLength(50)]
        public string Email { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
