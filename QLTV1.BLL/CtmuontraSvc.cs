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
    public class CtmuontraSvc : GenericSvc<CtmuontraRep, Ctmuontra>
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

        public object SearchCtmuontra(int id, int page, int size)
        {
            var ct = All.Where(x => x.MaSach >= id);
            var offset = (page - 1) * size;
            var total = ct.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = ct.OrderBy(x => x.MaSach).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateCtmuontra(CtmuontraReq ct)
        {
            var res = new SingleRsp();
            Ctmuontra chitiet = new Ctmuontra();
            chitiet.MaMt = ct.MaMt;
            chitiet.MaSach = ct.MaSach;
            chitiet.DaTra = ct.DaTra;
            chitiet.Ngaytra = ct.Ngaytra;
            chitiet.GhiChu = ct.GhiChu;
            res = _rep.CreateCtmuontra(chitiet);
            return res;
        }

        public SingleRsp UpdateCtmuontra(CtmuontraReq ct)
        {
            var res = new SingleRsp();
            Ctmuontra chitiet = new Ctmuontra();
            chitiet.MaMt = ct.MaMt;
            chitiet.MaSach = ct.MaSach;
            chitiet.DaTra = ct.DaTra;
            chitiet.Ngaytra = ct.Ngaytra;
            chitiet.GhiChu = ct.GhiChu;
            res = _rep.UpdateCtmuontra(chitiet);
            return res;
        }

        public SingleRsp DeleteCtmuontra(CtmuontraReq ct)
        {
            var res = new SingleRsp();
            Ctmuontra chitiet = new Ctmuontra();
            chitiet.MaMt = ct.MaMt;
            chitiet.MaSach = ct.MaSach;
            chitiet.DaTra = ct.DaTra;
            chitiet.Ngaytra = ct.Ngaytra;
            chitiet.GhiChu = ct.GhiChu;
            res = _rep.DeleteCtmuontra(chitiet);
            return res;

        }

        #endregion
    }
}
