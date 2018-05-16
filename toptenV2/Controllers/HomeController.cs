using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toptenV2.Data;
using toptenV2.Models;

namespace toptenV2.Controllers
{
    public class HomeController : Controller
    {

        //nav dropdown
        //private readonly ApplicationDbContext _context;
        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.SubCategoryID.OrderBy(g => g.GenreType).ToListAsync());
        //}

        //nav dropdown end



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
