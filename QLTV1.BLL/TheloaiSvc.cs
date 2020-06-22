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
    public class TheloaiSvc : GenericSvc<TheloaiRep, Theloai>
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

        public object GetTheloaibyid(int id)
        {
            var theloai = All.Where(x => x.MaTl == id)
                .Join(_rep.Context.Sach, a => a.MaTl, b => b.MaTl, (a, b) => new
                {
                    a.MaTl,
                    a.TenTl,
                    MaSach = b.MaSach,
                    TenSach = b.TenSach
                })
                .FirstOrDefault();
            return theloai;
        }
        public object SearchTheloai(string keyword, int page, int size)
        {
            var tl = All.Where(x => x.TenTl.Contains(keyword));
            var offset = (page - 1) * size;
            var total = tl.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = tl.OrderBy(x => x.TenTl).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateTheloai(TheloaiReq tl)
        {
            var res = new SingleRsp();
            Theloai theloai = new Theloai();
            theloai.MaTl = tl.MaTl;
            theloai.TenTl = tl.TenTl;
            res = _rep.CreateTheloai(theloai);
            return res;
        }
        public SingleRsp UpdateTheloai(TheloaiReq tl)
        {
            var res = new SingleRsp();
            Theloai theloai = new Theloai();
            theloai.MaTl = tl.MaTl;
            theloai.TenTl = tl.TenTl;
            res = _rep.UpdateTheloai(theloai);
            return res;
        }

        public SingleRsp DeleteTheloai(TheloaiReq tl)
        {
            var res = new SingleRsp();
            Theloai theloai = new Theloai();
            theloai.MaTl = tl.MaTl;
            theloai.TenTl = tl.TenTl;
            res = _rep.DeleteTheloai(theloai);
            return res;

        }
        public TheloaiSvc() { }


        #endregion
    }
}
