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
    public class DocgiaController : ControllerBase
    {
        public DocgiaController()
        {
            _svc = new DocgiaSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllDocgia()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("get-doc-gia-by-id")]
        public IActionResult GetDocgiabyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var docgia = _svc.GetDocgiabyid(req.Id);
            res.Data = docgia;
            return Ok(res);
        }

        [HttpPost("search-doc-gia")]
        public IActionResult SearchDocgia([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var dg = _svc.SearchDocgia(req.Keyword, req.Page, req.Size);
            res.Data = dg;
            return Ok(res);
        }

        [HttpPost("create-doc-gia")]
        public IActionResult CreateDocgia([FromBody] DocgiaReq req)
        {
            var res = _svc.CreateDocgia(req);
            return Ok(res);
        }

        [HttpPost("update-doc-gia")]
        public IActionResult UpdateDocgia([FromBody] DocgiaReq req)
        {
            var res = _svc.UpdateDocgia(req);
            return Ok(res);
        }

        [HttpPost("delete-doc-gia")]
        public IActionResult DeleteDocgia([FromBody] DocgiaReq req)
        {
            var res = _svc.DeleteDocgia(req);
            return Ok(res);
        }

        private readonly DocgiaSvc _svc;
    }
}
