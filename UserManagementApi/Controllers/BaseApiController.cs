using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("/usermanagmentapi/v1/[controller]")]
    public abstract class BaseApiController : ControllerBase { }
}