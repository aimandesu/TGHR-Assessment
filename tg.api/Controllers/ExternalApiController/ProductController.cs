using Microsoft.AspNetCore.Mvc;
using tg.application.Features.ExternalAPI.Product;
using tg.application.Repository;

namespace tg.api.Controllers.ExternalApiController;

// [Route("api/[controller]/[action]")]
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandHandler<GetProductRequest, GetProductResponse> _getProductHandler;

    public ProductController(
        ICommandHandler<GetProductRequest, GetProductResponse> getProductHandler)
    {
        _getProductHandler = getProductHandler;
    }

    [HttpGet("get-product")]
    public async Task<IActionResult> GetProduct(
        [FromQuery] GetProductRequest request, 
        CancellationToken cancellationToken )
    {
        var result = await  _getProductHandler.Handle(request, cancellationToken);
        return Ok(result);
    }
    
}