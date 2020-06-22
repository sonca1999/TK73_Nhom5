using QLTV1.BLL;

using QLTV1.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using QLVT1.DAL.Models;
using QLVT1.DAL;

namespace QLTV1.BLL
{
    using QLTV1.Common.Rsp;
    using QLTV1.Common.Rep;
    public class SachSvc : GenericSvc<SachRep, Sach>
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

        #region -- Methods --

        public object GetSachbyid(int id)
        {
            var sach = All.Where(x => x.MaSach == id)
                .Join(_rep.Context.Theloai, a => a.MaTl, b => b.MaTl, (a, b) => new
                {
                    a.MaSach,
                    a.MaTg,
                    a.TenSach,
                    a.NamSx,
                    TenTheLoai = b.TenTl
                })
                .Join(_rep.Context.Tacgia, a => a.MaTg, b => b.MaTg, (a, b) => new
                {
                    a.MaSach,
                    a.MaTg,
                    a.TenSach,
                    a.NamSx,
                    a.TenTheLoai,
                    TenTacGia = b.TenTg
                }).FirstOrDefault();
            return sach;
        }
        public object SearchSach(string keyword, int page, int size)
        {
            var sach = All.Where(x => x.TenSach.Contains(keyword));
            var offset = (page - 1) * size;
            var total = sach.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = sach.OrderBy(x => x.TenSach).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateSach(SachReq s)
        {
            var res = new SingleRsp();
            Sach sach = new Sach();
            sach.MaSach = s.MaSach;
            sach.TenSach = s.TenSach;
            sach.MaTg = s.MaTg;
            sach.MaTl = s.MaTl;
            sach.NamSx = s.NamSx;
            res = _rep.CreateSach(sach);
            return res;
        }
        public SingleRsp UpdateSach(SachReq s)
        {
            var res = new SingleRsp();
            Sach sach = new Sach();
            sach.MaSach = s.MaSach;
            sach.TenSach = s.TenSach;
            sach.MaTg = s.MaTg;
            sach.MaTl = s.MaTl;
            sach.NamSx = s.NamSx;
            res = _rep.UpdateSach(sach);
            return res;
        }

        public SingleRsp DeleteSach(SachReq sach)
        {
            var res = new SingleRsp();
            Sach s = new Sach();
            s.MaSach = sach.MaSach;
            s.TenSach = sach.TenSach;
            s.MaSach = sach.MaSach;
            s.MaSach = sach.MaSach;
            s.MaSach = sach.MaSach;
            res = _rep.DeleteSach(s);
            return res;

        }
        public object Layslsach_LinQ()
        {
            return _rep.Layslsach_LinQ();
        }


        public SachSvc() { }


        #endregion
    }
}
