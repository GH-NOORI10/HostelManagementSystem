using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Students.Include(x=>x.Room).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Room = new SelectList(
                _context.Rooms.Select(x => new { x.Id, x.RoomNo }), "Id", "RoomNo");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Room = new SelectList(
                _context.Rooms.Select(x => new { x.Id, x.RoomNo }), "Id", "RoomNo");

            var data = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            _context.Students.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Students.Include(s => s.Room).Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Student model)
        {
            var exist = _context.Students.Where(x => x.Id == model.Id).FirstOrDefault();
            if (exist != null)
            {
                _context.Students.Remove(exist);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
