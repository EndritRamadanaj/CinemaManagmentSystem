using CinemaManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View();
        }
    }
}
