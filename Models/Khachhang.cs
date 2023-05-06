﻿using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Baocaos = new HashSet<Baocao>();
            CtKehoaches = new HashSet<CtKehoach>();
        }

        public int MaKh { get; set; }
        public string? TenKh { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? DiaChiLienHe { get; set; }
        public string? TenCongty { get; set; }
        public string? DiaChiCongTy { get; set; }
        public string? MaSoThue { get; set; }

        public virtual ICollection<Baocao> Baocaos { get; set; }
        public virtual ICollection<CtKehoach> CtKehoaches { get; set; }
    }
}
