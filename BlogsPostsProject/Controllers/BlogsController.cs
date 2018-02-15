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
    }
}