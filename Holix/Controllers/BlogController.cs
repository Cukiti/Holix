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
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===== PUBLIC =====

        // GET: /Blog
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt)
                .ToListAsync();
            return View(posts);
        }

        // GET: /Blog/{slug}
        [AllowAnonymous]
        [Route("Blog/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }

            var post = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Slug == slug && m.IsPublished);
            if (post == null)
            {
                return NotFound();
            }

            post.Views++;
            _context.Update(post);
            await _context.SaveChangesAsync();

            var morePosts = (await _context.BlogPosts
                .Where(p => p.IsPublished && p.Id != post.Id)
                .ToListAsync())
                .OrderBy(_ => Guid.NewGuid())
                .Take(3)
                .ToList();
            ViewBag.MorePosts = morePosts;

            return View(post);
        }

        // ===== ADMIN CRUD =====

        // GET: Blog/Admin
        [Authorize]
        [Route("Blog/Admin")]
        public async Task<IActionResult> AdminList()
        {
            return View("AdminList", await _context.BlogPosts.OrderByDescending(p => p.PublishedAt).ToListAsync());
        }

        // GET: Blog/Details/5
        [Authorize]
        [Route("Blog/Details/{id:int?}")]
        public async Task<IActionResult> AdminDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View("AdminDetail", blogPost);
        }

        // GET: Blog/Create
        [Authorize]
        [Route("Blog/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [Authorize]
        [HttpPost]
        [Route("Blog/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Excerpt,Content,ImageUrl,Author,PublishedAt,IsPublished")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminList));
            }
            return View(blogPost);
        }

        // GET: Blog/Edit/5
        [Authorize]
        [Route("Blog/Edit/{id:int?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Blog/Edit/5
        [Authorize]
        [HttpPost]
        [Route("Blog/Edit/{id:int?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Slug,Excerpt,Content,ImageUrl,Author,PublishedAt,IsPublished")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdminList));
            }
            return View(blogPost);
        }

        // GET: Blog/Delete/5
        [Authorize]
        [Route("Blog/Delete/{id:int?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Blog/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [Route("Blog/Delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminList));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}
