using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.Service.Create;
using tg.application.Features.Service.Delete;
using tg.application.Repository;

namespace tg.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly ICommandHandler<CreateServiceRequest, Result<CreateServiceResponse>> _createServiceHandler;
    private readonly ICommandHandler<DeleteServiceRequest, Result<DeleteServiceResponse>> _deleteServiceHandler;
    
    public ServiceController(
        ICommandHandler<CreateServiceRequest, Result<CreateServiceResponse>> createServiceHandler,
        ICommandHandler<DeleteServiceRequest, Result<DeleteServiceResponse>> deleteServiceHandler)
    {
        _createServiceHandler = createServiceHandler;
        _deleteServiceHandler = deleteServiceHandler;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("add-service")]
    public async Task<IActionResult> AddService(
        [FromForm]  CreateServiceRequest request,
        CancellationToken cancellationToken
        )
    {
        var result = await _createServiceHandler.Handle(request, cancellationToken);

        if (result.IsFailure)
        {
            return Ok(result.Error);
        }
        
        return Ok(result.Value);
        
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("delete-service")]
    public async Task<IActionResult> DeleteService(
        [FromQuery] DeleteServiceRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _deleteServiceHandler.Handle(request, cancellationToken);

        if (result.IsFailure)
        {
            return Ok(result.Error);
        }
        
        return Ok(result.Value);
    }
    
}