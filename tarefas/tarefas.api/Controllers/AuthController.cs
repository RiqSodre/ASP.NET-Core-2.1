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
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly UserBusiness _userBusiness;

        public AuthController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] LoginPayload payload)
        {
            return await RunDefaultAsync(async () =>
            {
                var user = await _userBusiness.Login(payload);
                return Ok(user);
            });
        }
    }
}