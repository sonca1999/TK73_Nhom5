using System;
using System.Collections.Generic;

namespace QLVT1.DAL.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaTg { get; set; }
        public string TenTg { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
