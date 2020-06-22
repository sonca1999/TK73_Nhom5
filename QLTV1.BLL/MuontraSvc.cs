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
    public class MuontraSvc : GenericSvc<MuontraRep, Muontra>
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
        public object GetMuontrabyid(int id)
        {
            {
                var sach = All.Where(x => x.MaMt == id)
                    .Join(_rep.Context.Ctmuontra, a => a.MaMt, b => b.MaMt, (a, b) => new
                    {
                        a.MaThe,
                        a.Ngaymuon,
                        MaSach = b.MaSach,
                        NgayTra = b.Ngaytra
                    })
                    .Join(_rep.Context.Sach, a => a.MaSach, b => b.MaSach, (a, b) => new
                    {
                        a.MaThe,
                        a.Ngaymuon,
                        a.MaSach,
                        a.NgayTra,
                        TenSach = b.TenSach
                    }).FirstOrDefault();
                return sach;
            }
        }
        public object SearchMuontra(int id, int page, int size)
        {
            var mt = All.Where(x => x.MaMt >= id);
            var offset = (page - 1) * size;
            var total = mt.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = mt.OrderBy(x => x.MaMt).Skip(offset).Take(size).ToList();

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

        public SingleRsp CreateMuontra(MuontraReq mt)
        {
            var res = new SingleRsp();
            Muontra muontra = new Muontra();
            muontra.MaMt = mt.MaMt;
            muontra.MaThe = mt.MaThe;
            muontra.Ngaymuon = mt.Ngaymuon;
            res = _rep.CreateMuontra(muontra);
            return res;
        }
        public SingleRsp UpdateMuontra(MuontraReq mt)
        {
            var res = new SingleRsp();
            Muontra muontra = new Muontra();
            muontra.MaMt = mt.MaMt;
            muontra.MaThe = mt.MaThe;
            muontra.Ngaymuon = mt.Ngaymuon;
            res = _rep.UpdateMuontra(muontra);
            return res;
        }

        public SingleRsp DeleteMuontra(MuontraReq mt)
        {
            var res = new SingleRsp();
            Muontra muontra = new Muontra();
            muontra.MaMt = mt.MaMt;
            res = _rep.DeleteMuontra(muontra);
            return res;

        }

        #endregion
    }
}
