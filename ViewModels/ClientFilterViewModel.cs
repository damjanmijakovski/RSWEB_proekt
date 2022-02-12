using FeedbackPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.ViewModels
{
    public class ClientFilterViewModel
    {
        public IList<Client> Clients { get; set; }
        public string SearchString { get; set; }
    }
}
