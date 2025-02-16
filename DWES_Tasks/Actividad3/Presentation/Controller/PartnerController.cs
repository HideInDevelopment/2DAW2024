using Actividad3.Common.Validators;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3.Presentation.Controller;

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
        try
        {
            await _partnerService.AddAsync(entity);
        }
        catch (FailOnPersistEntityException<Partner>)
        {
            return BadRequest($"Partner {entity.Name} can not be created.");
        }
        catch (EntityAlreadyExistException<Partner>)
        {
            return BadRequest($"Partner {entity.Name} already exists.");
        }
        
        return Ok("Partner stored successfully.");
    }
    
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] PartnerDto entity){
        try
        {
            await _partnerService.UpdateAsync(entity);
        }
        catch (FailOnPersistEntityException<Cat> cEx)
        {
            return BadRequest($"Changes on Partner {entity.Name} can not be saved.");
        }
        catch (EntityNotFoundException<Cat> cEx)
        {
            return BadRequest($"Partner {entity.Name} don't exist yet.");
        }
        
        return Ok("Partner updated successfully.");
    }
    
    [HttpDelete("{key:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid key){
        try
        {
            await _partnerService.DeleteAsync(key);
        }
        catch (FailOnPersistEntityException<Partner> cEx)
        {
            return BadRequest($"Partner can not be deleted.");
        }
        catch (EntityNotFoundException<Partner> cEx)
        {
            return BadRequest($"Partner doesn't exist yet.");
        }
        
        return Ok("Partner deleted successfully.");
    }
}