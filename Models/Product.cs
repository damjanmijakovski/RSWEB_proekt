using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Product Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        [StringLength(50)]
        public string Type { get; set; }

        [Display(Name = "Project Manager")]
        public int EmployeeId { get; set; }
        [Display(Name = "Project Manager")]
        public Employee Employee { get; set; }

        public ICollection <Feedback> Feedbacks { get; set; }
    }
}
