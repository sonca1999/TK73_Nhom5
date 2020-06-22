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
    public class CtmuontraController : ControllerBase
    {
        public CtmuontraController()
        {
            _svc = new CtmuontraSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllCtmuontra()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search-chi-tiet-muon-tra")]
        public IActionResult SearchCtmuontra([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var tg = _svc.SearchCtmuontra(req.Id, req.Page, req.Size);
            res.Data = tg;
            return Ok(res);
        }

        [HttpPost("create-chi-tiet-muon-tra")]
        public IActionResult CreateCtmuontra([FromBody] CtmuontraReq req)
        {
            var res = _svc.CreateCtmuontra(req);
            return Ok(res);
        }

        [HttpPost("update-chi-tiet-muon-tra")]
        public IActionResult UpdateCtmuontra([FromBody] CtmuontraReq req)
        {
            var res = _svc.UpdateCtmuontra(req);
            return Ok(res);
        }

        [HttpPost("delete-chi-tiet-muon-tra")]
        public IActionResult DeleteCtmuontra([FromBody] CtmuontraReq req)
        {
            var res = _svc.DeleteCtmuontra(req);
            return Ok(res);
        }

        private readonly CtmuontraSvc _svc;
    }
}
