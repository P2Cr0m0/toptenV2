using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using toptenV2.Data;
using toptenV2.Models;

namespace toptenV2.Controllers
{
    public class ListingController : Controller
    {
        private readonly TopTenContext _context;

        public ListingController(TopTenContext context)
        {
            _context = context;
        }

        // GET: Listing
        public async Task<IActionResult> Index(int? id)
        {
            var topTenContext = _context.Listings.Where(l=>l.SubCategoryID==id).Include(l => l.SubCategory);
            return View(await topTenContext.ToListAsync());
        }

        // GET: Listing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings
                .Include(l => l.SubCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // GET: Listing/Create
        public IActionResult Create(int? subcatID)
        {
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "ID", "Name");
            ViewData["subcatID"] = subcatID;
            return View();
        }

        // POST: Listing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SubCategoryID,Name,Creator,ReleaseDate")] Listing listing, string subcatID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listing);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "ID", "Name", listing.SubCategoryID);
            return View(listing);

            
    }

        // GET: Listing/Edit/5
        public async Task<IActionResult> Edit(int? id,int? subcatID)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings.SingleOrDefaultAsync(m => m.ID == id);
            if (listing == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "ID", "Name", listing.SubCategoryID);
            ViewData["subcatID"] = subcatID;
            return View(listing);
        }

        // POST: Listing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SubCategoryID,Name,Creator,ReleaseDate")] Listing listing,string subcatID)
        {
            if (id != listing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingExists(listing.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index","Listing",new { id = subcatID });
            }
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "ID", "Name", listing.SubCategoryID);
            return View(listing);
        }

        // GET: Listing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings
                .Include(l => l.SubCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // POST: Listing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listing = await _context.Listings.SingleOrDefaultAsync(m => m.ID == id);
            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.ID == id);
        }
    }
}
