using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comments/Details/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        [Route("Comments/Create/{postId}")]
        public IActionResult Create(int postId)
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Comments/Create/{postId}")]
        public async Task<IActionResult> Create([Bind("Id,Content,CreationDate")] Comment comment, int postId)
        {
            comment.post = _context.Posts.FirstOrDefault(p => p.Id == postId);
            comment.applicationUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Posts", new { id = postId });
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.Include("applicationUser").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);
            if (comment == null)
            {
                return NotFound();
            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result || comment.applicationUser.Id == user.Id)
            {
                return View(comment);
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var commentDb = await _context.Comments.Include("applicationUser").Include("post").FirstOrDefaultAsync(p => p.Id == id);
                var user = await _userManager.GetUserAsync(User);
                if (commentDb == null)
                {
                    return NotFound();
                }
                try
                {
                    if (_userManager.IsInRoleAsync(user, "Admin").Result || commentDb.applicationUser.Id == user.Id)
                    {
                        commentDb.Content = comment.Content;
                        _context.Update(commentDb);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return Forbid();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (_userManager.IsInRoleAsync(user, "Admin").Result)
                {
                    return RedirectToAction("List", "Posts");
                }
                return RedirectToAction("Index", "Posts", new { id = commentDb.post.Id });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.Include("applicationUser").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);
            if (comment == null)
            {
                return NotFound();
            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result || comment.applicationUser.Id == user.Id)
            {
                return View(comment);
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Comments'  is null.");
            }
            var comment = await _context.Comments.Include("applicationUser").Include("post").FirstOrDefaultAsync(p => p.Id == id);
            var user = await _userManager.GetUserAsync(User);
            if (comment == null)
            {
                return NotFound();
            }
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }

            await _context.SaveChangesAsync();
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return RedirectToAction("List", "Posts");
            }
            return RedirectToAction("Index", "Posts", new { id = comment.post.Id });
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
