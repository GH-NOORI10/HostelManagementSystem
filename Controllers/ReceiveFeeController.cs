using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class ReceiveFeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiveFeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.ReceiveFees.Include(x => x.StudentMonthlyFee).ThenInclude(s => s.Student).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StudentMonthlyFee = new SelectList(
                _context.StudentMonthlyFee.Where(s=>s.ReceiveFee.Count()==0).Select(x => new { x.Id, x.Student.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReceiveFee model)
        {
            var exist = _context.StudentMonthlyFee.Where(x => x.Id == model.StudentMonthlyFeeId).FirstOrDefault();
            model.Month = exist.Month;
            _context.ReceiveFees.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.StudentMonthlyFee = new SelectList(
                _context.StudentMonthlyFee.Select(x => new { x.Id, x.Fee }), "Id", "Fee");

            var data = _context.ReceiveFees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ReceiveFee model)
        {
            _context.ReceiveFees.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.ReceiveFees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Student model)
        {
            try
            {
                var exist = _context.ReceiveFees.Include(s => s.StudentMonthlyFee).Where(x => x.Id == model.Id).FirstOrDefault();
                if (exist != null)
                {
                    _context.ReceiveFees.Remove(exist);
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
