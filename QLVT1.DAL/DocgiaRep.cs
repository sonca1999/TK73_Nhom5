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
    public class DocgiaRep : GenericRep<QLTV1Context, Docgia>
    {
        #region -- Overrides --
        public override Docgia Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaDg == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaDg == id);
            m = base.Delete(m); //TODO
            return m.MaDg;
        }
        #endregion

        #region --Method--

        public SingleRsp CreateDocgia(Docgia dg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Docgia.Add(dg);
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

        public SingleRsp UpdateDocgia(Docgia dg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Docgia.Update(dg);
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

        public SingleRsp DeleteDocgia(Docgia dg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Docgia.Remove(dg);
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
