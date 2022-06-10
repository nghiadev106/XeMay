using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly XeMayContext _context;

        public MenuViewComponent(XeMayContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return View("Index", new MenuViewModel{
                Categories=categories
            });
        }

    }
}
