using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Features.Package.Create;
using tg.application.Repository;

namespace tg.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly ICommandHandler<CreatePackageRequest, CreatePackageResponse> _createPackageHandler;

    public PackageController(
        ICommandHandler<CreatePackageRequest, CreatePackageResponse> createPackageHandler)
    {
        _createPackageHandler = createPackageHandler;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("add-package")]
    public async Task<IActionResult> CreatePackage(
        [FromForm] CreatePackageRequest request,
        CancellationToken cancellationToken)
    {
        var result = await  _createPackageHandler.Handle(request, cancellationToken);
        return Ok(result);
    }
    
    
}