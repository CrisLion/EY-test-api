using Microsoft.AspNetCore.Mvc;
using Suppliers.API.DueDiligence.Domain.Models.Commands;
using Suppliers.API.DueDiligence.Domain.Models.Queries;
using Suppliers.API.DueDiligence.Domain.Services;

namespace Suppliers.API.DueDiligence.Interfaces.REST;

[ApiController]
[Route("/api/v1/suppliers")]
[Produces("application/json")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierCommandService _supplierCommandService;
    private readonly ISupplierQueryService _supplierQueryService;

    public SupplierController(ISupplierCommandService supplierCommandService, ISupplierQueryService supplierQueryService)
    {
        _supplierCommandService = supplierCommandService;
        _supplierQueryService = supplierQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSuppliers()
    {
        var query = new GetSuppliersQuery();
        var result = await _supplierQueryService.Handle(query);
        return Ok(result);
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> GetSuppliersByUserId([FromQuery] int userId)
    {
        var query = new GetSuppliersByUserId(userId);
        var result = await _supplierQueryService.Handle(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(int id)
    {
        var query = new GetSupplierByIdQuery(id);
        var result = await _supplierQueryService.Handle(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostSuppliers([FromBody] CreateSupplierCommand command)
    {
        var result = await _supplierCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSupplier(int id, [FromBody] UpdateSupplierCommand command)
    {
        var result = await _supplierCommandService.Handle(id, command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var command = new DeleteSupplierCommand(id);
        await _supplierCommandService.Handle(command);
        return Ok("Supplier with id " + id + " has been deleted successfully");
    }
}