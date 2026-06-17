using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModel;

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SchoolErpContext _context;

        public DashboardController(SchoolErpContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }


    }
}
