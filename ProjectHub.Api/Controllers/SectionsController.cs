using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ProjectHub.Api.Controllers;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/sections")]
[ApiController]
public class SectionsController : ControllerBase
{

}
