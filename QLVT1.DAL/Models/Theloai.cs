using System;
using System.Collections.Generic;

namespace QLVT1.DAL.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaTl { get; set; }
        public string TenTl { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
