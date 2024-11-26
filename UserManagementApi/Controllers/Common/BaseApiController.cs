using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public abstract class BaseApiController : ControllerBase { }
}