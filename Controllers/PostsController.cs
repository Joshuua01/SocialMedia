using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Posts
        [HttpGet]
        [Route("Posts/Index/{PostId}")]
        public async Task<IActionResult> Index(int PostId)
        {
            var post = await _context.Posts
                .Include(p => p.Comments)
                .ThenInclude(p => p.applicationUser)
                .Include(p => p.applicationUser)
                .FirstOrDefaultAsync(m => m.Id == PostId);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            return View(await _context.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        [Route("Posts/Create/{CategoryId}")]
        public IActionResult Create(int CategoryId)
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Posts/Create/{CategoryId}")]
        public async Task<IActionResult> Create(Post post, int CategoryId)
        {
            post.applicationUser = await _userManager.GetUserAsync(User);
            post.category = await _context.Categories.FindAsync(CategoryId);
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Categories", new { id = CategoryId });
            }
            else
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        //Error details listed in var error
                    }
                }
            }
            return View(post);
        }

        // GET: Posts/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include("applicationUser").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);
            if (post == null)
            {
                return NotFound();
            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result || post.applicationUser.Id == user.Id)
            {
                return View(post);
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            var postDb = await _context.Posts.Include("applicationUser").Include("category").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);
            var CategoryId = postDb.category.Id;
            if (ModelState.IsValid)
            {
                if (_userManager.IsInRoleAsync(user, "Admin").Result || postDb.applicationUser.Id == user.Id)
                {
                    try
                    {
                        postDb.Title = post.Title;
                        postDb.Content = post.Content;
                        _context.Posts.Update(postDb);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PostExists(post.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    return Forbid();
                }

                if (_userManager.IsInRoleAsync(user, "Admin").Result)
                {
                    return RedirectToAction("List", "Posts");
                }
                return RedirectToAction("Index", "Posts", new { id = postDb.Id });
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include("applicationUser").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);

            if (post == null || user == null)
            {
                return NotFound();
            }

            if (_userManager.IsInRoleAsync(user, "Admin").Result || post.applicationUser.Id == user.Id)
            {
                return View(post);
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Posts'  is null.");
            }

            var post = await _context.Posts.Include("applicationUser").Include("category").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);

            if (post == null || user == null)
            {
                return NotFound();
            }
            var CategoryId = post.category.Id;
            if (_userManager.IsInRoleAsync(user, "Admin").Result || post.applicationUser.Id == user.Id)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();

            }
            else
            {
                return Forbid();
            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return RedirectToAction("List", "Posts");
            }
            return RedirectToAction("Index", "Categories", new { id = CategoryId });
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
