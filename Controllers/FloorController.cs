using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostelManagementSystem.Controllers
{
    public class FloorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FloorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Floors.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Floor model)
        {
            _context.Floors.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
      
            var data = _context.Floors.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Floor model)
        {
            _context.Floors.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Floors.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Floor model)
        {
            var exist = _context.Floors.Where(x => x.Id == model.Id).FirstOrDefault();
            if (exist != null)
            {
                _context.Floors.Remove(exist);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
