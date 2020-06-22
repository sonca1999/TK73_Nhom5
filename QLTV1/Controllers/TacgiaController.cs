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
    public class TacgiaController : ControllerBase
    {
        public TacgiaController()
        {
            _svc = new TacgiaSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllTacgia()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-tac-gia-by-id")]
        public IActionResult GetTacgiabyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var tacgia = _svc.GetTacgiabyid(req.Id);
            res.Data = tacgia;
            return Ok(res);
        }

        [HttpPost("search-tac-gia")]
        public IActionResult SearchTacgia([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var tg = _svc.SearchTacgia(req.Keyword, req.Page, req.Size);
            res.Data = tg;
            return Ok(res);
        }

        [HttpPost("create-tac-gia")]
        public IActionResult CreateTacgia([FromBody] TacgiaReq req)
        {
            var res = _svc.CreateTacgia(req);
            return Ok(res);
        }

        [HttpPost("update-tac-gia")]
        public IActionResult UpdateTacgia([FromBody] TacgiaReq req)
        {
            var res = _svc.UpdateTacgia(req);
            return Ok(res);
        }

        [HttpPost("delete-tac-gia")]
        public IActionResult DeleteTacgia([FromBody] TacgiaReq req)
        {
            var res = _svc.DeleteTacgia(req);
            return Ok(res);
        }

        private readonly TacgiaSvc _svc;
    }
}
