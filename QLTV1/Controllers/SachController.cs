using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLTV1.WEB.Controllers
{
    using BLL;
    using QLVT1.DAL.Models;
    using Common.Req;
    using System.Collections.Generic;
    using Common.Rsp;
    using QLTV1.Common.Rep;

    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        public SachController()
        {
            _svc = new SachSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllSach()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("get-Sach-by-id")]
        public IActionResult GetSachbyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var sach = _svc.GetSachbyid(req.Id);
            res.Data = sach;
            return Ok(res);
        }

        [HttpPost("search-sach")]
        public IActionResult SearchSach([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var sach = _svc.SearchSach(req.Keyword, req.Page, req.Size);
            res.Data = sach;
            return Ok(res);
        }

        [HttpPost("create-sach")]
        public IActionResult CreateSach([FromBody] SachReq req)
        {
            var res = _svc.CreateSach(req);
            return Ok(res);
        }

        [HttpPost("update-sach")]
        public IActionResult UpdateSach([FromBody] SachReq req)
        {
            var res = _svc.UpdateSach(req);
            return Ok(res);
        }

        [HttpPost("delete-sach")]
        public IActionResult DeleteSach([FromBody] SachReq req)
        {
            var res = _svc.DeleteSach(req);
            return Ok(res);
        }
        [HttpPost("lay-so-luong-sach-linq")]
        public IActionResult Layslsach_LinQ()
        {
            var res = new SingleRsp();
            res.Data = _svc.Layslsach_LinQ();
            return Ok(res);
        }
        private readonly SachSvc _svc;
    }
}
