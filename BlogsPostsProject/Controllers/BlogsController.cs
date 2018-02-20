using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogsPostsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsPostsProject.Controllers
{
    public class BlogsController : Controller
    {
        protected IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _blogRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogRepository.GetAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public ActionResult Create()
        {
            Blog blog = new Blog { };
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BlogId,Title,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.Add(blog);
                _blogRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogRepository.DeleteAsync(await _blogRepository.GetAsync(id));
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _blogRepository.GetAsync(id);
            _blogRepository.Delete(blog);
            await _blogRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}