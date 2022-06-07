using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Controllers
{
    public class BlogsController : Controller
    {
        private readonly XeMayContext _context;

        public BlogsController(XeMayContext context)
        {      
            _context = context;
        }
        public async Task<IActionResult> ListBlogs(int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var blogs = await _context.News.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = blogs.Count();
            var sanphams = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<News>()
            {
                Items = sanphams,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            ViewBag.ListCate = await _context.CategoriesNews.ToListAsync();
            ViewBag.ListNews = await _context.News.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> ListBlogCategories(long id, int page = 1)
        {
            int totalRow = 0;
            var pageSize = 1;
            var blogs = await _context.News.Where(x => x.Status == 1 && x.CategoryId == id).OrderBy(x => x.DisplayOrder).ToListAsync();
            totalRow = blogs.Count();
            var sanphams = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<News>()
            {
                Items = sanphams,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            ViewBag.category = await _context.CategoriesNews.Where(x => x.Status == 1 && x.Id == id).SingleOrDefaultAsync();
            ViewBag.ListCate = await _context.CategoriesNews.ToListAsync();
            ViewBag.ListNews = await _context.News.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            return View(paginationSet);
        }

        public async Task<IActionResult> DetailBlog(long id)
        {
            var blog = await _context.News.Where(x => x.Status == 1&& x.Id==id).SingleOrDefaultAsync();
            ViewBag.ListNews = await _context.News.Where(x => x.Status == 1).OrderBy(x => x.CreateDate).ToListAsync();
            ViewBag.relatedNews = await _context.News.Where(x => x.CategoryId == blog.CategoryId && x.Id != id && x.Status == 1).OrderBy(x => x.DisplayOrder).Take(5).ToListAsync();
            ViewBag.categories = await _context.CategoriesNews.ToListAsync();
            return View(blog);
        }
    }
}
