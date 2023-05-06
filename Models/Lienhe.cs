using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    public partial class Lienhe
    {
        public Lienhe()
        {
            Baocaos = new HashSet<Baocao>();
            CtKehoaches = new HashSet<CtKehoach>();
        }

        public int Idlh { get; set; }
        public int? SoKhlh { get; set; }

        public virtual ICollection<Baocao> Baocaos { get; set; }
        public virtual ICollection<CtKehoach> CtKehoaches { get; set; }
    }
}
