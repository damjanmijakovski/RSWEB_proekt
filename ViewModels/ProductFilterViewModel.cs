using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using FeedbackPortal.Models;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.ViewModels
{
    public class ProductFilterViewModel
    {
        public IList<Product> Products { get; set; }
        public SelectList Types { get; set; }
        public string ProductType { get; set; }
        public string SearchString { get; set; }
    }
}
