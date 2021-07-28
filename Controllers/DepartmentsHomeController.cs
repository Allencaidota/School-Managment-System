using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Controllers
{
    public class DepartmentsHomeController : Controller
    {
        public string List()
        {
            return "DepartmentsController in the List() method";
        }
        public string Details()
        {
            return "DepartmentsController in the Details() method~";
        }
    }
}
