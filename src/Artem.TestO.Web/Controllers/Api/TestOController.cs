using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permissions = Artem.TestO.Core.ModuleConstants.Security.Permissions;

namespace Artem.TestO.Web.Controllers.Api;

[Authorize]
[Route("api/test-o")]
public class TestOController : Controller
{
    // GET: api/test-o
    /// <summary>
    /// Get message
    /// </summary>
    /// <remarks>Return "Hello world!" message</remarks>
    [HttpGet]
    [Route("")]
    [Authorize(Permissions.Read)]
    public ActionResult<string> Get()
    {
        return Ok(new { result = "Hello world!" });
    }
}
