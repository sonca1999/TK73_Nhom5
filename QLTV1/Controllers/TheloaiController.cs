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
    public class TheloaiController : ControllerBase
    {
            public TheloaiController()
            {
                _svc = new TheloaiSvc();
            }

        

        [HttpPost("get-all")]
            public IActionResult getAllTheloai()
            {
                var res = new SingleRsp();
                res.Data = _svc.All;
                return Ok(res);
            }
        [HttpPost("get-the-loai-by-id")]
        public IActionResult GetTheloaibyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var tacgia = _svc.GetTheloaibyid(req.Id);
            res.Data = tacgia;
            return Ok(res);
        }

        [HttpPost("search-the-loai")]
        public IActionResult SearchTheloai([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var tg = _svc.SearchTheloai(req.Keyword, req.Page, req.Size);
            res.Data = tg;
            return Ok(res);
        }

        [HttpPost("create-the-loai")]
        public IActionResult CreateTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.CreateTheloai(req);
            return Ok(res);
        }

        [HttpPost("update-the-loai")]
        public IActionResult UpdateTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.UpdateTheloai(req);
            return Ok(res);
        }

        [HttpPost("delete-the-loai")]
        public IActionResult DeleteTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.DeleteTheloai(req);
            return Ok(res);
        }

        private readonly TheloaiSvc _svc;

    }
       
    
}
