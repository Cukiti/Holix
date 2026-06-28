using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Holix.Models;
using Holix.Data;
using Microsoft.EntityFrameworkCore;

namespace Holix.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Seed initial data if empty
        if (!await _context.Services.AnyAsync())
        {
            _context.Services.AddRange(
                new Service { Title = "UI/UX Creative Design", Description = "Designing intuitive and stunning user interfaces.", Icon = "fa-solid fa-palette" },
                new Service { Title = "App Development", Description = "Native and cross-platform mobile applications.", Icon = "fa-solid fa-mobile-screen" },
                new Service { Title = "Professional Content Writer", Description = "Compelling copy that drives conversions.", Icon = "fa-solid fa-pen-nib" },
                new Service { Title = "Graphic Design", Description = "Visual identities that leave a lasting mark.", Icon = "fa-solid fa-vector-square" }
            );
            _context.FaqItems.AddRange(
                new FaqItem { Question = "What does a UX strategy include?", Answer = "Research, wireframing, user testing, and final high-fidelity design.", Order = 1 },
                new FaqItem { Question = "How long does app development take?", Answer = "Depending on complexity, an app can take anywhere from 2 to 6 months.", Order = 2 },
                new FaqItem { Question = "Do you provide ongoing support?", Answer = "Yes, we offer maintenance packages to keep your platform updated.", Order = 3 }
            );
            _context.Projects.AddRange(
                new Project { Title = "Fintech Dashboard", ClientName = "BankCorp", Category = "Web App", Description = "Modern banking analytics dashboard.", ImageUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?q=80&w=2070&auto=format&fit=crop", Technologies = "React, C#" },
                new Project { Title = "E-Commerce App", ClientName = "ShopifyStore", Category = "Mobile App", Description = "A seamless shopping experience for iOS and Android.", ImageUrl = "https://images.unsplash.com/photo-1512428559087-560fa5ceab42?q=80&w=2070&auto=format&fit=crop", Technologies = "Flutter, Firebase" }
            );
            _context.Testimonials.AddRange(
                new Testimonial { ClientName = "Sarah Jenkins", Company = "TechFlow", Content = "Holix transformed our digital presence completely. Outstanding work!", Rating = 5, AvatarUrl = "https://i.pravatar.cc/150?img=47" },
                new Testimonial { ClientName = "Mark Stevenson", Company = "LogixCorp", Content = "Their team is incredibly professional and delivered beyond expectations.", Rating = 5, AvatarUrl = "https://i.pravatar.cc/150?img=11" }
            );
            await _context.SaveChangesAsync();
        }

        var vm = new HomeViewModel
        {
            Services = await _context.Services.ToListAsync(),
            Projects = await _context.Projects.ToListAsync(),
            Testimonials = await _context.Testimonials.ToListAsync(),
            Faqs = await _context.FaqItems.Where(f => f.IsActive).OrderBy(f => f.Order).ToListAsync()
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitContact(HomeViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.ContactMessages.Add(model.Contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { success = true });
        }
        return RedirectToAction(nameof(Index), new { error = true });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
