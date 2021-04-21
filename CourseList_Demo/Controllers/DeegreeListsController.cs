using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseList.Data;
using CourseList_Demo.Models;

namespace CourseList_Demo.Controllers
{
    public class DeegreeListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeegreeListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeegreeLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeegreeLists.ToListAsync());
        }

        // GET: DeegreeLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deegreeList = await _context.DeegreeLists
                .FirstOrDefaultAsync(m => m.DeegreeId == id);
            if (deegreeList == null)
            {
                return NotFound();
            }

            return View(deegreeList);
        }

        // GET: DeegreeLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeegreeLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeegreeId,DeegreeName")] DeegreeList deegreeList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deegreeList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deegreeList);
        }

        // GET: DeegreeLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deegreeList = await _context.DeegreeLists.FindAsync(id);
            if (deegreeList == null)
            {
                return NotFound();
            }
            return View(deegreeList);
        }

        // POST: DeegreeLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeegreeId,DeegreeName")] DeegreeList deegreeList)
        {
            if (id != deegreeList.DeegreeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deegreeList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeegreeListExists(deegreeList.DeegreeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deegreeList);
        }

        // GET: DeegreeLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deegreeList = await _context.DeegreeLists
                .FirstOrDefaultAsync(m => m.DeegreeId == id);
            if (deegreeList == null)
            {
                return NotFound();
            }

            return View(deegreeList);
        }

        // POST: DeegreeLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deegreeList = await _context.DeegreeLists.FindAsync(id);
            _context.DeegreeLists.Remove(deegreeList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeegreeListExists(int id)
        {
            return _context.DeegreeLists.Any(e => e.DeegreeId == id);
        }
    }
}
