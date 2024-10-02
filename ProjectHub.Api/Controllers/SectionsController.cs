using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjectHub.Application.Contracts;

namespace ProjectHub.Api.Controllers;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/sections")]
[ApiController]
public class SectionsController : ControllerBase
{
    private readonly ISectionService _sectionService;

    public SectionsController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }
}
