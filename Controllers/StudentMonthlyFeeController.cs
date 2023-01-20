using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class StudentMonthlyFeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentMonthlyFeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.StudentMonthlyFee.Include(x => x.Student).ToList();
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
        public IActionResult Create(StudentMonthlyFee model)
        {
            _context.StudentMonthlyFee.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Student = new SelectList(
                _context.Students.Select(x => new { x.Id, x.Name }), "Id", "Name");

            var data = _context.StudentMonthlyFee.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(StudentMonthlyFee model)
        {
            _context.StudentMonthlyFee.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.StudentMonthlyFee.Include(s => s.Student).Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(StudentMonthlyFee model)
        {
            var exist = _context.StudentMonthlyFee.Where(x => x.Id == model.Id).FirstOrDefault();
            if (exist != null)
            {
                _context.StudentMonthlyFee.Remove(exist);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
