using DIS_Project.Data;
using DIS_Project.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DIS_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
