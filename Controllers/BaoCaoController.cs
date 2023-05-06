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
    public class BaoCaoController : Controller
    {
        private readonly QLNSContext _context;

        public BaoCaoController(QLNSContext context)
        {
            _context = context;
        }

        // GET: BaoCao
        public async Task<IActionResult> Index()
        {
            var qLNSContext = _context.Baocaos.Include(b => b.IdlhNavigation).Include(b => b.MaKhNavigation).Include(b => b.MaNvNavigation);
            return View(await qLNSContext.ToListAsync());

        }

        // GET: BaoCao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Baocaos == null)
            {
                return NotFound();
            }

            var baocao = await _context.Baocaos
                .Include(b => b.IdlhNavigation)
                .Include(b => b.MaKhNavigation)
                .Include(b => b.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.IdbaoCao == id);
            if (baocao == null)
            {
                return NotFound();
            }

            ViewBag.TenKhachHang = baocao.MaKhNavigation.TenKh;
            ViewBag.SoLienHe = baocao.IdlhNavigation.SoKhlh;
           /* ViewBag.TenNhanVien = baocao.MaNvNavigation.TenNv;*/

            return View(baocao);
        }

        // GET: BaoCao/Create
        public IActionResult Create()
        {
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
            ViewBag.NhanVienList = new SelectList(_context.Nhanviens, "MaNv", "TenNv");
            return View();
        }

        // POST: BaoCao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdbaoCao,MaNv,MaKh,NgayLap,KhtimKiem,MoTaCv,KhchamSoc,Idlh,DongNghiep,HocTap,DuDinh")] Baocao baocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "idlh", "SoKhlh");
            ViewBag.NhanVienList = new SelectList(_context.Nhanviens, "MaNv", "TenNv");
            return View(baocao);
        }

        // GET: BaoCao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Baocaos == null)
            {
                return NotFound();
            }

            var baocao = await _context.Baocaos.FindAsync(id);
            if (baocao == null)
            {
                return NotFound();
            }
            ViewBag.KhachHangList = new SelectList(_context.Khachhangs, "MaKh", "TenKh");
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "Idlh", "SoKhlh");
            /*ViewBag.NhanVienList = new SelectList(_context.Nhanviens, "MaNv", "TenNv");*/
            return View(baocao);
        }

        // POST: BaoCao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdbaoCao,MaNv,MaKh,NgayLap,KhtimKiem,MoTaCv,KhchamSoc,Idlh,DongNghiep,HocTap,DuDinh")] Baocao baocao)
        {
            if (id != baocao.IdbaoCao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaocaoExists(baocao.IdbaoCao))
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
            ViewBag.LienHeList = new SelectList(_context.Lienhes, "idlh", "SoKhlh");
           /* ViewBag.NhanVienList = new SelectList(_context.Nhanviens, "MaNv", "TenNv");*/
            return View(baocao);
        }

        // GET: BaoCao/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Baocaos == null)
            {
                return Problem("Entity set 'QLNSContext.Baocaos'  is null.");
            }
            var baocao = await _context.Baocaos.FindAsync(id);
            if (baocao == null)
            {
                return NotFound();
            }
            _context.Baocaos.Remove(baocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool BaocaoExists(int id)
        {
          return (_context.Baocaos?.Any(e => e.IdbaoCao == id)).GetValueOrDefault();
        }
    }
}
