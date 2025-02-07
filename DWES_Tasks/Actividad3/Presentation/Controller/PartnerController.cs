using Actvidad3.Common.Validators;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Actvidad3.Presentation.Controller;

[ApiController]
[Route("[controller]")]
public class PartnerController : ControllerBase
{
    private readonly IPartnerService _partnerService;

    public PartnerController(IPartnerService partnerService)
    {
        _partnerService = partnerService;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        var response = await _partnerService.GetAllAsync();

        if (ListValidator.IsNullOrEmpty(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpGet("{key:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid key)
    {
        var response = await _partnerService.GetByIdAsync(key);

        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] PartnerDto entity){
        var response = await _partnerService.AddAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] PartnerDto entity){
        var response = await _partnerService.UpdateAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpDelete("{key:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid key){
        var response = await _partnerService.DeleteAsync(key);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}