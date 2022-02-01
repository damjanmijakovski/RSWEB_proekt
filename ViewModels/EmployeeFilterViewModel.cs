using Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.ViewModels
{
    public class EmployeeFilterViewModel
    {
        public IList<Employee> Employees { get; set; }
        public string SearchString { get; set; }
    }
}
