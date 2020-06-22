using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV1.Common.Rep
{
   public class CtmuontraReq
    {
        public int MaSach { get; set; }
        public int MaMt { get; set; }
        public bool DaTra { get; set; }
        public DateTime Ngaytra { get; set; }
        public string GhiChu { get; set; }
    }
}
