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
    public class NhanVienController : Controller
    {
        private readonly QLNSContext _context;

        public NhanVienController(QLNSContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var qLNSContext = _context.Nhanviens.Include(n => n.MaChucVuNavigation).Include(n => n.MaPhongBanNavigation);
            return View(await qLNSContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(nv => nv.MaChucVuNavigation).Include(nv=>nv.MaPhongBanNavigation)                 
                .FirstOrDefaultAsync(nv => nv.MaNv == id);

            if (nhanvien == null)
            {
                return NotFound();
            }

            ViewBag.TenChucVu = nhanvien.MaChucVuNavigation.TenChucVu;
            ViewBag.TenPhongBan = nhanvien.MaPhongBanNavigation.TenPhongBan; // lấy tên phòng ban từ đối tượng phòng ban

            return View(nhanvien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewBag.ChucVuList = new SelectList(_context.Chucvus, "MaChucVu", "TenChucVu");
            ViewBag.PhongBanList = new SelectList(_context.Phongbans, "MaPhongBan", "TenPhongBan");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNv,TenNv,GioiTinh,GiaDinh,Sdt,Email,NgaySinh,NoiSinh,DiaChi,Cccd,NgayCap,NoiCap,HinhAnh,TinhTrang,MaChucVu,MaPhongBan")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Lấy tên chức vụ từ mã chức vụ
            ViewBag.ChucVuList = new SelectList(_context.Chucvus, "MaChucVu", "TenChucVu");
            ViewBag.PhongBanList = new SelectList(_context.Phongbans, "MaPhongBan", "TenPhongBan");
            return View(nhanvien);
        }




        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewBag.ChucVuList = new SelectList(_context.Chucvus, "MaChucVu", "TenChucVu");
            ViewBag.PhongBanList = new SelectList(_context.Phongbans, "MaPhongBan", "TenPhongBan");
            return View(nhanvien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNv,TenNv,GioiTinh,GiaDinh,Sdt,Email,NgaySinh,NoiSinh,DiaChi,Cccd,NgayCap,NoiCap,HinhAnh,TinhTrang,MaChucVu,MaPhongBan")] Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.MaNv))
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
            ViewBag.ChucVuList = new SelectList(_context.Chucvus, "MaChucVu", "TenChucVu");
            ViewBag.PhongBanList = new SelectList(_context.Phongbans, "MaPhongBan", "TenPhongBan");
            return View(nhanvien);
        }

        // GET: NhanVien/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.MaChucVuNavigation)
                .Include(n => n.MaPhongBanNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }*/

        // POST: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Nhanviens == null)
            {
                return Problem("Entity set 'QLNSContext.Nhanviens' is null.");
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool NhanvienExists(int id)
        {
          return (_context.Nhanviens?.Any(e => e.MaNv == id)).GetValueOrDefault();
        }
    }
}
