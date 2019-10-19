using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tarefas.api.Controllers.Base;
using tarefas.business.Business;
using tarefas.business.Models.Payloads;

namespace tarefas.api.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserPayload payload)
        {
            return await RunDefaultAsync(async () =>
            {
                await _userBusiness.Create(payload);
                return Ok();
            });
        }
    }
}