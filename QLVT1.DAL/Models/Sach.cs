using System;
using System.Collections.Generic;

namespace QLVT1.DAL.Models
{
    public partial class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int? MaTg { get; set; }
        public int? MaTl { get; set; }
        public DateTime? NamSx { get; set; }

        public virtual Tacgia MaTgNavigation { get; set; }
        public virtual Theloai MaTlNavigation { get; set; }
    }
}
