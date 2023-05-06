using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class CtKehoach
    {
        public int IdkeHoach { get; set; }
        public DateTime NgayLap { get; set; }
        public string? MoTaCv { get; set; }
        public int? MaNv { get; set; }
        public int? MaKh { get; set; }
        public string? KhchamSoc { get; set; }
        public int? SoKhtn { get; set; }
        public string? DongNghiep { get; set; }
        public string? HocTap { get; set; }
        public string? CamKet { get; set; }
        public int? Idlh { get; set; }

        public virtual Lienhe? IdlhNavigation { get; set; }
        public virtual Khachhang? MaKhNavigation { get; set; }
        public virtual Nhanvien? MaNvNavigation { get; set; }
    }
}
