using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseList.Data;
using CourseList.Models;

namespace CourseList_Demo.Controllers
{
    public class CourseListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Test()
        {
            return View();
        }
        // GET: CourseLists
        public IActionResult Index(int deegree)
        {
            List<CourseLists> courses = getCourseLists(deegree);

            return View(courses);
        }

        private List<CourseLists> getCourseLists(int deegree)
        {
            List<CourseLists> courses = new List<CourseLists>();

            foreach (var c in _context.CourseLists)
            {
                if (deegree == 1)
                {
                    courses.Add(c);
                }


            }

            return courses;
        }

        // GET: CourseLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLists = await _context.CourseLists
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseLists == null)
            {
                return NotFound();
            }

            return View(courseLists);
        }

        // GET: CourseLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName")] CourseLists courseLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(courseLists);
        }

        // GET: CourseLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLists = await _context.CourseLists.FindAsync(id);
            if (courseLists == null)
            {
                return NotFound();
            }
            return View(courseLists);
        }

        // POST: CourseLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName")] CourseLists courseLists)
        {
            if (id != courseLists.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseListsExists(courseLists.CourseId))
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
            return View(courseLists);
        }

        // GET: CourseLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseLists = await _context.CourseLists
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseLists == null)
            {
                return NotFound();
            }

            return View(courseLists);
        }

        // POST: CourseLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseLists = await _context.CourseLists.FindAsync(id);
            _context.CourseLists.Remove(courseLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseListsExists(int id)
        {
            return _context.CourseLists.Any(e => e.CourseId == id);
        }
    }
}
