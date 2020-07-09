using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.models;

namespace DatabaseFirst.Controllers
{
    public class DevicePropertiesController : Controller
    {
        private readonly SQLDatabaseContext _context;

        public DevicePropertiesController(SQLDatabaseContext context)
        {
            _context = context;
        }

        // GET: DeviceProterties
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceProterties.ToListAsync());
        }

        // GET: DeviceProterties/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProterties = await _context.DeviceProterties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceProterties == null)
            {
                return NotFound();
            }

            return View(deviceProterties);
        }

        // GET: DeviceProterties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceProterties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Location")] DeviceProterties deviceProterties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceProterties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceProterties);
        }

        // GET: DeviceProterties/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProterties = await _context.DeviceProterties.FindAsync(id);
            if (deviceProterties == null)
            {
                return NotFound();
            }
            return View(deviceProterties);
        }

        // POST: DeviceProterties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Description,Location")] DeviceProterties deviceProterties)
        {
            if (id != deviceProterties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceProterties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceProtertiesExists(deviceProterties.Id))
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
            return View(deviceProterties);
        }

        // GET: DeviceProterties/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProterties = await _context.DeviceProterties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceProterties == null)
            {
                return NotFound();
            }

            return View(deviceProterties);
        }

        // POST: DeviceProterties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deviceProterties = await _context.DeviceProterties.FindAsync(id);
            _context.DeviceProterties.Remove(deviceProterties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceProtertiesExists(string id)
        {
            return _context.DeviceProterties.Any(e => e.Id == id);
        }
    }
}
