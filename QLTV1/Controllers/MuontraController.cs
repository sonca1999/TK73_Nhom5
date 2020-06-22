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
    public class MuontraController : ControllerBase
    {
        public MuontraController()
        {
            _svc = new MuontraSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllMuontra()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("get-muon-tra-by-id")]
        public IActionResult GetMuontrabyid([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            var muontra = _svc.GetMuontrabyid(req.Id);
            res.Data = muontra;
            return Ok(res);
        }

        [HttpPost("search-muon-tra")]
        public IActionResult SearchMuontra([FromBody] SearchTacgiaReq req)
        {
            var res = new SingleRsp();
            var mt = _svc.SearchMuontra(req.Id, req.Page, req.Size);
            res.Data = mt;
            return Ok(res);
        }

        [HttpPost("create-muon-tra")]
        public IActionResult CreateMuontra([FromBody] MuontraReq req)
        {
            var res = _svc.CreateMuontra(req);
            return Ok(res);
        }

        [HttpPost("update-muon-tra")]
        public IActionResult UpdateMuontra([FromBody] MuontraReq req)
        {
            var res = _svc.UpdateMuontra(req);
            return Ok(res);
        }

        [HttpPost("delete-muon-tra")]
        public IActionResult DeleteMuontra([FromBody] MuontraReq req)
        {
            var res = _svc.DeleteMuontra(req);
            return Ok(res);
        }

        private readonly MuontraSvc _svc;
    }
}
