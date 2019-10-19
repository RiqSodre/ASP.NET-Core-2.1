using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.api.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected async Task<IActionResult> RunDefaultAsync(Func<Task<IActionResult>> predicate)
        {
            if (!ModelState.IsValid)
            {
                var errors = new OpenApiError(HttpContext.Request.Path, ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage);
                return BadRequest(errors);
            }

            try
            {
                return await predicate();
            }
            catch (InvalidProgramException exception)
            {
                return BadRequest(new OpenApiError(HttpContext.Request.Path, exception.Message));
            }
            catch (Exception exception)
            {
                return BadRequest(new OpenApiError(HttpContext.Request.Path, exception.Message));
            }
        }
    }
}
