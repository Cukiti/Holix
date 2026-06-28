using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holix.Data;
using Holix.Models;
using Microsoft.AspNetCore.Authorization;

namespace Holix.Controllers
{
    [Authorize]
    public class FaqsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FaqsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Faqs
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaqItems.ToListAsync());
        }

        // GET: Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqItem = await _context.FaqItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqItem == null)
            {
                return NotFound();
            }

            return View(faqItem);
        }

        // GET: Faqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer,Order,IsActive")] FaqItem faqItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faqItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faqItem);
        }

        // GET: Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqItem = await _context.FaqItems.FindAsync(id);
            if (faqItem == null)
            {
                return NotFound();
            }
            return View(faqItem);
        }

        // POST: Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer,Order,IsActive")] FaqItem faqItem)
        {
            if (id != faqItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faqItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqItemExists(faqItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faqItem);
        }

        // GET: Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqItem = await _context.FaqItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqItem == null)
            {
                return NotFound();
            }

            return View(faqItem);
        }

        // POST: Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faqItem = await _context.FaqItems.FindAsync(id);
            if (faqItem != null)
            {
                _context.FaqItems.Remove(faqItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqItemExists(int id)
        {
            return _context.FaqItems.Any(e => e.Id == id);
        }
    }
}
