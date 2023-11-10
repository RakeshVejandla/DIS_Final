using DIS_Project.Data;
using DIS_Project.DataModels;
using DIS_Project.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIS_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ContactController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactDto contactDto)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact()
                {
                    Name = contactDto.Name,
                    Email = contactDto.Email,
                    Subject = contactDto.Subject,
                    Message = contactDto.Message,
                    CreatedBy = contactDto.Email,
                    CreatedDate = DateTime.Now,
                };
                dbContext.Contact.Add(contact);
                await dbContext.SaveChangesAsync();
                ViewBag.InformationMessage = "Your message has been sent. Thank you!";
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
