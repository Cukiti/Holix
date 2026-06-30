using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Holix.Data;
using Holix.Models;

namespace Holix.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Portfolio
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var projects = (await _context.Projects
                .Where(p => p.IsPublished)
                .ToListAsync())
                .OrderBy(p => Guid.NewGuid())
                .ToList();
            return View(projects);
        }

        // GET: /Portfolio/{slug}
        [AllowAnonymous]
        [Route("Portfolio/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Slug == slug && m.IsPublished);
            if (project == null)
            {
                return NotFound();
            }

            project.Views++;
            _context.Update(project);
            await _context.SaveChangesAsync();

            var relatedProjects = (await _context.Projects
                .Where(p => p.IsPublished && p.Id != project.Id)
                .ToListAsync())
                .OrderBy(_ => Guid.NewGuid())
                .Take(3)
                .ToList();
            ViewBag.RelatedProjects = relatedProjects;

            return View(project);
        }
    }
}
