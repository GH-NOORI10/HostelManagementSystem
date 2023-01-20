using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Rooms.Include(x=>x.Floor).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Floor = new SelectList(
                _context.Floors.Select(x => new { x.Id, x.FloorLocation }), "Id", "FloorLocation");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room model)
        {
            _context.Rooms.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Floor = new SelectList(
                _context.Floors.Select(x => new { x.Id, x.FloorLocation }), "Id", "FloorLocation");

            var data = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Room model)
        {
            _context.Rooms.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Floor model)
        {
            try
            {
                var exist = _context.Rooms.Include(s => s.Floor).Where(x => x.Id == model.Id).FirstOrDefault();
                if (exist != null)
                {
                    _context.Rooms.Remove(exist);
                    _context.SaveChanges();
                }
                return Json("success");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);

            }
        }
    }
}
