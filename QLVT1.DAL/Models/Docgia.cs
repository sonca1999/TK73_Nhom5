using System;
using System.Collections.Generic;

namespace QLVT1.DAL.Models
{
    public partial class Docgia
    {
        public int MaDg { get; set; }
        public string TenDg { get; set; }
        public string Sdt { get; set; }
        public int? MaThe { get; set; }

        public virtual Thethuvien MaTheNavigation { get; set; }
    }
}
