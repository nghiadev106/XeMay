using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly XeMayContext _context;

        public HomeController(ILogger<HomeController> logger, XeMayContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Ds slide
            ViewBag.ListSlides = await _context.Slides.Where(a =>a.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();

            //Ds chuyên mục
            ViewBag.ListCategories =await _context.Categories.Where(a => a.ShowHome == true && a.Status == 1).OrderBy(x => x.DisplayOrder).ToListAsync();
            //SP Hot
            ViewBag.ListProductHot = await _context.Products.Where(a => a.Status == 1).OrderBy(x => x.DisplayOrder).Take(8).ToListAsync();
            //SP Mới
            ViewBag.ListProductNew = await _context.Products.Where(a => a.Status == 1&& a.IsNew==true).OrderByDescending(x => x.CreateDate).Take(5).ToListAsync();
            //Ds tin tức
            ViewBag.ListNews = await _context.News.Where(a =>a.Status == 1).OrderBy(x => x.DisplayOrder).Take(4).ToListAsync();
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
