using QLTV1.BLL;
using QLTV1.Common.Rsp;
using QLTV1.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using QLVT1.DAL.Models;
using QLVT1.DAL;

namespace QLTV1.BLL
{
    using QLTV1.Common.Rep;
    public class ThethuvienSvc : GenericSvc<ThethuvienRep, Thethuvien>
    {
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        #endregion

        #region --Method--
        public object GetThethuvienbyid(int id)
        {
            var thethuvien = All.Where(x => x.MaThe == id)
                .Join(_rep.Context.Docgia, a => a.MaThe, b => b.MaThe, (a, b) => new
                {
                    a.MaThe,
                    a.NgayBd,
                    a.NgayHh,
                    Madocgia = b.MaDg,
                    Tendocgia = b.TenDg
                }).FirstOrDefault();

            return thethuvien;
        }
        public object SearchThethuvien(int id, int page, int size)
        {
            var ttv = All.Where(x => x.MaThe >= id);
            var offset = (page - 1) * size;
            var total = ttv.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = ttv.OrderBy(x => x.MaThe).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalPage,
                Page = page,
                Size = size
            };
            return res;
        }

        public SingleRsp CreateThethuvien(ThethuvienReq ttv)
        {
            var res = new SingleRsp();
            Thethuvien thethuvien = new Thethuvien();
            thethuvien.MaThe = ttv.MaThe;
            thethuvien.NgayBd = ttv.NgayBd;
            thethuvien.NgayHh = ttv.NgayHh;
            thethuvien.GhiChu = ttv.GhiChu;
            res = _rep.CreateThethuvien(thethuvien);
            return res;
        }
        public SingleRsp UpdateThethuvien(ThethuvienReq ttv)
        {
            var res = new SingleRsp();
            Thethuvien thethuvien = new Thethuvien();
            thethuvien.MaThe = ttv.MaThe;
            thethuvien.NgayBd = ttv.NgayBd;
            thethuvien.NgayHh = ttv.NgayHh;
            thethuvien.GhiChu = ttv.GhiChu;
            res = _rep.UpdateThethuvien(thethuvien);
            return res;
        }

        public SingleRsp DeleteThethuvien(ThethuvienReq ttv)
        {
            var res = new SingleRsp();
            Thethuvien thethuvien = new Thethuvien();
            thethuvien.MaThe = ttv.MaThe;
            thethuvien.NgayBd = ttv.NgayBd;
            thethuvien.NgayHh = ttv.NgayHh;
            thethuvien.GhiChu = ttv.GhiChu;
            res = _rep.DeleteThethuvien(thethuvien);
            return res;

        }

        #endregion
    }
}
