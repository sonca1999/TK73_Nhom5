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
    public class TacgiaRep : GenericRep<QLTV1Context, Tacgia>
    {
        #region -- Overrides --
        public override Tacgia Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaTg == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaTg == id);
            m = base.Delete(m); //TODO
            return m.MaTg;
        }
        #endregion

        #region --Method--

        public SingleRsp CreateTacgia(Tacgia tg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tacgia.Add(tg);
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

        public SingleRsp UpdateTacgia(Tacgia tg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tacgia.Update(tg);
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

        public SingleRsp DeleteTacgia(Tacgia tg)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tacgia.Remove(tg);
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

