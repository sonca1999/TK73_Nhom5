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
    public class ThethuvienRep : GenericRep<QLTV1Context, Thethuvien>
    {
        #region -- Overrides --
        public override Thethuvien Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaThe == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaThe == id);
            m = base.Delete(m); //TODO
            return m.MaThe;
        }
        #endregion

        #region --Method--

        public SingleRsp CreateThethuvien(Thethuvien thethuvien)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Thethuvien.Add(thethuvien);
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

            public SingleRsp UpdateThethuvien(Thethuvien ttv)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Thethuvien.Update(ttv);
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

        public SingleRsp DeleteThethuvien(Thethuvien ttv)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Thethuvien.Remove(ttv);
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


