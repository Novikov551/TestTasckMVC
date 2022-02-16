using Bots.Telegram.Bots;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTasckMVC.Models;

namespace TestTasckMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private AppContext _appDbContext;
        private readonly ITelegramBot _telegramBot;

        public EmployeesController(AppContext context, ITelegramBot telegramBot)
        {
            _appDbContext = context;
            _telegramBot = telegramBot;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Employee employee)
        {
            await Task.Delay(3000);

            var pos = await _appDbContext.Positions.FirstOrDefaultAsync(x => x.Name == employee.Position.Name);

            if (pos == null && employee.Position.Name != null)
            {
                ModelState.AddModelError("Position", "PositionNotFound");
            }

            if (ModelState.IsValid)
            {
                employee.Position = pos;

                await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();

                var employees = await _appDbContext.Employees.Include(u => u.Position).Where(x => x.SurName.ToLower() == employee.SurName.ToLower()).ToListAsync();
                var message = "";

                foreach (var item in employees)
                {
                    message += "Сотрудник: " + item.Name + " " + item.SurName + " Должность: " + item.Position.Name + "\n";
                }

                await _telegramBot.SendMessageAsync(message);

                return RedirectToRoute(new { controller = "Pages", action = "Index" });
            }

            return View(@"Views/Pages/AddEmployee.cshtml", employee);
        }
    }
}

