using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Guests.Include(x=>x.Student).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Student = new SelectList(
                _context.Students.Select(x => new { x.Id, x.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Guest model)
        {
            _context.Guests.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Student = new SelectList(
                _context.Students.Select(x => new { x.Id, x.Name }), "Id", "Name");

            var data = _context.Guests.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Guest model)
        {
            _context.Guests.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Guests.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Guest model)
        {
            try
            {
                var exist = _context.Guests.Include(s => s.Student).Where(x => x.Id == model.Id).FirstOrDefault();
                if (exist != null)
                {
                    _context.Guests.Remove(exist);
                    _context.SaveChanges();
                }
                return Json("success");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
    }
}
