using System;
using System.Collections.Generic;
using System.Text;
using QLTV1.Common.DAL;
using System.Linq;
using QLVT1.DAL.Models;
using QLTV1.Common.Rsp;
using System.Runtime.InteropServices;

namespace QLVT1.DAL
{
    public class MuontraRep : GenericRep<QLTV1Context, Muontra>
    {
        #region -- Overrides --
        public override Muontra Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaMt == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaMt == id);
            m = base.Delete(m); //TODO
            return m.MaMt;
        }
        #endregion

        #region --Method--

        public SingleRsp CreateMuontra(Muontra mt)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Muontra.Add(mt);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateMuontra(Muontra mt)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Muontra.Update(mt);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteMuontra(Muontra mt)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Muontra.Remove(mt);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;

        }
        #endregion
    }
}