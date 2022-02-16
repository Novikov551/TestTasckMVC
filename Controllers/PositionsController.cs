using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTasckMVC.Models;

namespace TestTasckMVC.Controllers
{
    public class PositionsController : Controller
    {
        private AppContext _appDbContext;

        public PositionsController(AppContext context)
        {
            _appDbContext = context;
        }

        [Route("/Search")]
        [HttpPost]
        public async Task<IQueryable<Position>> Search(string term)
        {
            var positions = await _appDbContext.Positions
                .Where(x => x.Name.Contains(term)).ToListAsync();

            return positions.AsQueryable();
        }

        [Route("Positions/Add")]
        [HttpPost]
        public async Task<IActionResult> Add(string positionName)
        {
            await Task.Delay(3000);

            var position = new Position()
            {
                Name = positionName
            };

            if (ModelState.IsValid)
            {
                var addedPosition = await _appDbContext.Positions.AddAsync(position);
                await _appDbContext.SaveChangesAsync();

                return Ok();
            }

            return View(@"Views/Pages/AddEmployee.cshtml", position.Name);
        }
    }
}
