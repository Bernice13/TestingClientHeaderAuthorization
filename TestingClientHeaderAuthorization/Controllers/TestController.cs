using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingClientHeaderAuthorization.MiddleWare;

namespace TestingClientHeaderAuthorization.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    [HttpPost]
    public IActionResult CreateYou([FromBody]CreateUser model)
    {
      return StatusCode(200);
    }
  }
}
