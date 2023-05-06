using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class KeHoachController : Controller
    {
        private readonly QLNSContext _context;

        public KeHoachController(QLNSContext context)
        {
            _context = context;
        }

        // GET: KeHoach
        public async Task<IActionResult> Index()
        {
            var qLNSContext = _context.CtKehoaches.Include(c => c.IdlhNavigation).Include(c => c.MaKhNavigation).Include(c => c.MaNvNavigation);
            return View(await qLNSContext.ToListAsync());
        }

        // GET: KeHoach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CtKehoaches == null)
            {
                return NotFound();
            }

            var ctKehoach = await _context.CtKehoaches
                .Include(c => c.IdlhNavigation)
                .Include(c => c.MaKhNavigation)
                .Include(c => c.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.IdkeHoach == id);
            if (ctKehoach == null)
            {
                return NotFound();
            }
            ViewBag.SoLienHe = ctKehoach.IdlhNavigation.SoKhlh;
            ViewBag.TenKH = ctKehoach.MaKhNavigation.TenKh;
            return View(ctKehoach);
        }

        // GET: KeHoach/Create
        public IActionResult Create()
        {
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
           /* ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv");*/
            return View();
        }

        // POST: KeHoach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdkeHoach,NgayLap,MoTaCv,MaNv,MaKh,KhchamSoc,SoKhtn,DongNghiep,HocTap,CamKet,Idlh")] CtKehoach ctKehoach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctKehoach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
           /* ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv", ctKehoach.MaNv);*/
            return View(ctKehoach);
        }

        // GET: KeHoach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CtKehoaches == null)
            {
                return NotFound();
            }

            var ctKehoach = await _context.CtKehoaches.FindAsync(id);
            if (ctKehoach == null)
            {
                return NotFound();
            }
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
            /*ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv", ctKehoach.MaNv);*/
            return View(ctKehoach);
        }

        // POST: KeHoach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdkeHoach,NgayLap,MoTaCv,MaNv,MaKh,KhchamSoc,SoKhtn,DongNghiep,HocTap,CamKet,Idlh")] CtKehoach ctKehoach)
        {
            if (id != ctKehoach.IdkeHoach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctKehoach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtKehoachExists(ctKehoach.IdkeHoach))
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
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
           /* ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv", ctKehoach.MaNv);*/
            return View(ctKehoach);
        }

   
        

        // POST: KeHoach/Delete/5
       
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.CtKehoaches == null)
            {
                return Problem("Entity set 'QLNSContext.CtKehoaches'  is null.");
            }
            var ctKehoach = await _context.CtKehoaches.FindAsync(id);
            if (ctKehoach == null)
            {
                return NotFound();
            }
            _context.CtKehoaches.Remove(ctKehoach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtKehoachExists(int id)
        {
          return (_context.CtKehoaches?.Any(e => e.IdkeHoach == id)).GetValueOrDefault();
        }
    }
}
