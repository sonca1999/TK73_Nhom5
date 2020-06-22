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
    public class TacgiaSvc : GenericSvc<TacgiaRep, Tacgia>
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
        public object GetTacgiabyid(int id)
        {
            var tacgia = All.Where(x => x.MaTg == id)
                .Join(_rep.Context.Sach, a => a.MaTg, b => b.MaTg, (a, b) => new
                {
                    a.MaTg,
                    a.TenTg,
                    TenSach = b.TenSach
                }).FirstOrDefault();
            return tacgia;
        }
        public object SearchTacgia(string keyword, int page, int size)
        {
            var tg = All.Where(x => x.TenTg.Contains(keyword));
            var offset = (page - 1) * size;
            var total = tg.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = tg.OrderBy(x => x.TenTg).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateTacgia(TacgiaReq tg)
        {
            var res = new SingleRsp();
            Tacgia tacgia = new Tacgia();
            tacgia.MaTg = tg.MaTg;
            tacgia.TenTg = tg.TenTg;
            tacgia.GhiChu = tg.GhiChu;
            res = _rep.CreateTacgia(tacgia);
            return res;
        }
        public SingleRsp UpdateTacgia(TacgiaReq tg)
        {
            var res = new SingleRsp();
            Tacgia tacgia = new Tacgia();
            tacgia.MaTg = tg.MaTg;
            tacgia.TenTg = tg.TenTg;
            tacgia.GhiChu = tg.GhiChu;
            res = _rep.UpdateTacgia(tacgia);
            return res;
        }

        public SingleRsp DeleteTacgia(TacgiaReq tg)
        {
            var res = new SingleRsp();
            Tacgia tacgia = new Tacgia();
            tacgia.MaTg = tg.MaTg;
            tacgia.TenTg = tg.TenTg;
            tacgia.GhiChu = tg.GhiChu;
            res = _rep.DeleteTacgia(tacgia);
            return res;

        }

        #endregion
    }
}
