using System;
using System.Collections.Generic;
using System.Text;
using QLTV1.Common.DAL;
using System.Linq;
using QLVT1.DAL.Models;
using QLTV1.Common.Rsp;
using System.Runtime.InteropServices;
using QLTV1.Common.Rep;

namespace QLVT1.DAL
{
    public class SachRep : GenericRep<QLTV1Context, Sach>
    {
        #region -- Overrides --
        public override Sach Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaSach == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaSach == id);
            m = base.Delete(m); //TODO
            return m.MaSach;
        }

        #endregion

        #region --Method--
        public SingleRsp CreateSach(Sach sach)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Sach.Add(sach);
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
        public SingleRsp UpdateSach(Sach sach)
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Sach.Update(sach);
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
        public SingleRsp DeleteSach(Sach sach)   
        {
            var res = new SingleRsp();
            using (var context = new QLTV1Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Sach.Remove(sach);
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
        public object Layslsach_LinQ()
        {
            var res = Context.Sach
                .Join(Context.Theloai, a => a.MaTl, b => b.MaTl, (a, b) => new
                {
                    a.MaTl,
                    b.TenTl,
                })
                .ToList();
            var data = res.GroupBy(x => x.MaTl)
                .Select(x => new {
                    x.First().MaTl,
                    x.First().TenTl,
                    Soluong = x.Count()
                });
            return data;
        }

        #endregion
    }
}
