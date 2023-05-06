using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Baocaos = new HashSet<Baocao>();
            CtKehoaches = new HashSet<CtKehoach>();
            Nguoidungs = new HashSet<Nguoidung>();
        }

        public int MaNv { get; set; }
        public string TenNv { get; set; } = null!;
        public byte GioiTinh { get; set; }
        public byte GiaDinh { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? NoiSinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Cccd { get; set; }
        public DateTime? NgayCap { get; set; }
        public string? NoiCap { get; set; }
        public string? HinhAnh { get; set; }
        public byte TinhTrang { get; set; }
        public string? MaChucVu { get; set; }
        public string? MaPhongBan { get; set; }

        public virtual Chucvu? MaChucVuNavigation { get; set; }
        public virtual Phongban? MaPhongBanNavigation { get; set; }
        public virtual ICollection<Baocao> Baocaos { get; set; }
        public virtual ICollection<CtKehoach> CtKehoaches { get; set; }
        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}
