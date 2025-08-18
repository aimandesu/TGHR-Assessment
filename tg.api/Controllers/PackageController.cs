using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.Package.Create;
using tg.application.Features.Package.GetAll;
using tg.application.Repository;

namespace tg.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly ICommandHandler<CreatePackageRequest, CreatePackageResponse> _createPackageHandler;
    private readonly ICommandHandler<GetAllPackageRequest, Pagination<PackageModelDto>> _getAllPackageHandler;

    public PackageController(
        ICommandHandler<CreatePackageRequest, CreatePackageResponse> createPackageHandler,
        ICommandHandler<GetAllPackageRequest, Pagination<PackageModelDto>> getAllPackageHandler)
    {
        _createPackageHandler = createPackageHandler;
        _getAllPackageHandler = getAllPackageHandler;
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

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPackages(
        [FromQuery]  GetAllPackageRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _getAllPackageHandler.Handle(request, cancellationToken);
        
        return Ok(result);
    }
    
    
}