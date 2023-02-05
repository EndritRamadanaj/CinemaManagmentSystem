using CinemaManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;
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

        public IActionResult Index()
        {
            var allMovies = _context.Movies.Include(n=> n.Cinema).OrderBy(n => n.Name).ToList();
            return View(allMovies);
        }
    }
}
