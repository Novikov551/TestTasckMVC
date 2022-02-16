using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTasckMVC.Models;

namespace TestTasckMVC.Controllers
{
    public class PagesController : Controller
    {
        private AppContext _appDbContext;

        public PagesController(AppContext context)
        {
            _appDbContext = context;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("AddEmployee")]
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }

        [Route("GetPositions")]
        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {
            var positions = await _appDbContext.Positions.Include(u => u.Employees).OrderByDescending(p => p.Employees.Count).ToListAsync();

            if (positions != null)
            {
                return View(positions);
            }

            return NotFound();
        }

        [Route("GetEmployees")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _appDbContext.Employees.Include(u => u.Position).Where(x => x.Position.Name == "Менеджер").OrderBy(p => p.Name).ToListAsync();

            if (employees != null)
            {

                return View(employees);
            }

            return NotFound();
        }
    }
}
