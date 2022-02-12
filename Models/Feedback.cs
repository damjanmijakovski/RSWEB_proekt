using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.Models
{
    public class Feedback
    {
        public int Id { get;set;}

        [Required]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Details")]
        [StringLength(300)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Feedback Type")]
        [StringLength(50)]
        public string Type { get; set; }

        public int ClientId { get; set; }
        [Display(Name = "Feedback By")]
        public Client Client { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product")]
        public Product Product { get; set; }
      
        [Display(Name = "Checked")]
        [StringLength(10)]
        public string IsChecked { get; set; }
    }
}
