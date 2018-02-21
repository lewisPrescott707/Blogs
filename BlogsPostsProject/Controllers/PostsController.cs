using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogsPostsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsPostsProject.Controllers
{
    public class PostsController : Controller
    {
        protected IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _postRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _postRepository.GetAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public ActionResult Create()
        {
            Post post = new Post { };
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BlogId,Title,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Add(post);
                _postRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.DeleteAsync(await _postRepository.GetAsync(id));
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _postRepository.GetAsync(id);
            _postRepository.Delete(post);
            await _postRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}