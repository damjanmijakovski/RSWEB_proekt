using FeedbackPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.ViewModels
{
    public class FeedbackFilterViewModel
    {
        public IList<Feedback> Feedbacks { get; set; }
        public SelectList Types { get; set; }
        public string FeedbackType { get; set; }
        public string SearchString { get; set; }
    }
}
