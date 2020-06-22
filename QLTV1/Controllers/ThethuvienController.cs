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
    public class ThethuvienController : ControllerBase
    {
        public ThethuvienController()
        {
            _svc = new ThethuvienSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllThethuvien()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("get-the-thu-vien-by-id")]
        public IActionResult GetThethuvienbyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var thethuvien = _svc.GetThethuvienbyid(req.Id);
            res.Data = thethuvien;
            return Ok(res);
        }

        [HttpPost("search-the-thu-vien")]
        public IActionResult SearchThethuvien([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var tg = _svc.SearchThethuvien(req.Id, req.Page, req.Size);
            res.Data = tg;
            return Ok(res);
        }

        [HttpPost("create-the-thu-vien")]
        public IActionResult CreateThethuvien([FromBody] ThethuvienReq req)
        {
            var res = _svc.CreateThethuvien(req);
            return Ok(res);
        }

        [HttpPost("update-the-thu-vien")]
        public IActionResult UpdateThethuvien([FromBody] ThethuvienReq req)
        {
            var res = _svc.UpdateThethuvien(req);
            return Ok(res);
        }

        [HttpPost("delete-the-thu-vien")]
        public IActionResult DeleteThethuvien([FromBody] ThethuvienReq req)
        {
            var res = _svc.DeleteThethuvien(req);
            return Ok(res);
        }

        private readonly ThethuvienSvc _svc;
    }
}
