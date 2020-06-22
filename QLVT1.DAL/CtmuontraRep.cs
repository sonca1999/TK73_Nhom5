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
    public class CtmuontraRep : GenericRep<QLTV1Context, Ctmuontra>
    {
        #region -- Overrides --
        public override Ctmuontra Read(int id)
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

        public SingleRsp CreateCtmuontra(Ctmuontra ct)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Ctmuontra.Add(ct);
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

        public SingleRsp UpdateCtmuontra(Ctmuontra ct)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Ctmuontra.Update(ct);
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

        public SingleRsp DeleteCtmuontra(Ctmuontra ct)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Ctmuontra.Remove(ct);
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