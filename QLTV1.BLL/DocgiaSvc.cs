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
    public class DocgiaSvc : GenericSvc<DocgiaRep, Docgia>
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
        public object GetDocgiabyid(int id)
        {
            var docgia = All.Where(x => x.MaDg == id)
                .Join(_rep.Context.Thethuvien, a => a.MaThe, b => b.MaThe, (a, b) => new
                {
                    a.MaDg,
                    a.TenDg,
                    a.Sdt,
                    NgayHetHan = b.NgayHh,
                    NgayBatDau = b.NgayBd

                }).FirstOrDefault();

            return docgia;
        }
        public object SearchDocgia(string keyword, int page, int size)
        {
            var dg = All.Where(x => x.TenDg.Contains(keyword));
            var offset = (page - 1) * size;
            var total = dg.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = dg.OrderBy(x => x.TenDg).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateDocgia(DocgiaReq dg)
        {
            var res = new SingleRsp();
            Docgia docgia = new Docgia();
            docgia.MaDg = dg.MaDg;
            docgia.TenDg = dg.TenDg;
            docgia.Sdt = dg.Sdt;
            docgia.MaThe = dg.MaThe;
            res = _rep.CreateDocgia(docgia);
            return res;
        }
        public SingleRsp UpdateDocgia(DocgiaReq dg)
        {
            var res = new SingleRsp();
            Docgia docgia = new Docgia();
            docgia.MaDg = dg.MaDg;
            docgia.TenDg = dg.TenDg;
            docgia.Sdt = dg.Sdt;
            docgia.MaThe = dg.MaThe;
            res = _rep.UpdateDocgia(docgia);
            return res;
        }

        public SingleRsp DeleteDocgia(DocgiaReq dg)
        {
            var res = new SingleRsp();
            Docgia docgia = new Docgia();
            docgia.MaDg = dg.MaDg;
            docgia.TenDg = dg.TenDg;
            docgia.Sdt = dg.Sdt;
            docgia.MaThe = dg.MaThe;
            res = _rep.DeleteDocgia(docgia);
            return res;

        }

        #endregion
    }
}
