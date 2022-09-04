using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class PaperUseagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaperUseagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaperUseages
        public IActionResult Index(DateTime? StartDate, DateTime? EndDate, string machinesearch,string? UserId)
        {
            ViewData["GetMachine"] = machinesearch;
            var users = from u in _context.Users
                        select u;

            ViewBag.User = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id,Selected=(UserId!=null&& UserId==x.Id?true:false) }).ToList();
             //var applicationDbContext = _context.PaperUseage.Include(p => p.Machine);
            var applicationDbContext = _context.PaperUseage.Include(p => p.Machine).ThenInclude(pp=> pp.Project).ThenInclude(ppp=> ppp.Customer);



            if (StartDate.HasValue && EndDate.HasValue || !String.IsNullOrEmpty(machinesearch))
            {
                //machinequery = machinequery.Where(x => x.Machine.MachineSN.Contains(machinesearch));
                return View(applicationDbContext.Where(d => d.DateCreated >= StartDate && d.DateCreated <= EndDate || d.Machine.MachineSN.Contains(machinesearch) || d.Machine.Project.Customer.CustomerName.Contains(machinesearch)||d.UserId.Contains(UserId)).AsEnumerable());

            }
            else
            {
                return View(applicationDbContext.AsEnumerable());
                //return View(applicationDbContext.AsNoTracking().AsEnumerable());
            }

            //if (StartDate.HasValue && EndDate.HasValue || !String.IsNullOrEmpty(machinesearch))
            //{
            //    //machinequery = machinequery.Where(x => x.Machine.MachineSN.Contains(machinesearch));
            //    return View(applicationDbContext.Where(d => d.DateCreated >= StartDate && d.DateCreated <= EndDate || d.Machine.MachineSN.Contains(machinesearch)).AsEnumerable());

            //}
            //else
            //{
            //    return View(applicationDbContext.AsNoTracking().AsEnumerable());
            //}


        }
        //[HttpGet]
        //public async Task<IActionResult> Index(string machinesearch)
        //{
        //    ViewData["GetMachine"] = machinesearch;
        //    var machinequery = from x in _context.PaperUseage select x;
        //    if (!String.IsNullOrEmpty(machinesearch))
        //    {
        //        machinequery = machinequery.Where(x => x.Machine.MachineSN.Contains(machinesearch));
        //    }
        //    return View(await machinequery.AsNoTracking().ToListAsync());
        //}

        //// GET: PaperUseages/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.PaperUseage == null)
        //    {
        //        return NotFound();
        //    }

        //    var paperUseage = await _context.PaperUseage
        //        .Include(p => p.Machine)
        //        .FirstOrDefaultAsync(m => m.PaperUseageID == id);
        //    if (paperUseage == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(paperUseage);
        //}

        //// GET: PaperUseages/Create
        //public IActionResult Create()
        //{
        //    ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId");
        //    return View();
        //}

        //// POST: PaperUseages/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PaperUseageID,MachineId,CurrentUses,DateCreated,CreatedBy,DateModified,ModifiedBy,IsRowDeleted")] PaperUseage paperUseage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(paperUseage);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", paperUseage.MachineId);
        //    return View(paperUseage);
        //}

        //// GET: PaperUseages/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.PaperUseage == null)
        //    {
        //        return NotFound();
        //    }

        //    var paperUseage = await _context.PaperUseage.FindAsync(id);
        //    if (paperUseage == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", paperUseage.MachineId);
        //    return View(paperUseage);
        //}

        //// POST: PaperUseages/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PaperUseageID,MachineId,CurrentUses,DateCreated,CreatedBy,DateModified,ModifiedBy,IsRowDeleted")] PaperUseage paperUseage)
        //{
        //    if (id != paperUseage.PaperUseageID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(paperUseage);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PaperUseageExists(paperUseage.PaperUseageID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", paperUseage.MachineId);
        //    return View(paperUseage);
        //}

        // GET: PaperUseages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaperUseage == null)
            {
                return NotFound();
            }

            var paperUseage = await _context.PaperUseage
                .Include(p => p.Machine)
                .FirstOrDefaultAsync(m => m.PaperUseageID == id);
            if (paperUseage == null)
            {
                return NotFound();
            }

            return View(paperUseage);
        }

        // POST: PaperUseages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaperUseage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PaperUseage'  is null.");
            }
            var paperUseage = await _context.PaperUseage.FindAsync(id);
            if (paperUseage != null)
            {
                _context.PaperUseage.Remove(paperUseage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperUseageExists(int id)
        {
          return _context.PaperUseage.Any(e => e.PaperUseageID == id);
        }
    }
}
