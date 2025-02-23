using Actividad3.Common.Validators;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3.Presentation.Controller;

[ApiController]
[Route("[controller]")]
public class ColonyController: ControllerBase
{
    private readonly IColonyService _colonyService;

    public ColonyController(IColonyService colonyService)
    {
        _colonyService = colonyService;
    }
    
    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        var response = await _colonyService.GetAllAsync();

        if (ListValidator.IsNullOrEmpty(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpGet("{key:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid key)
    {
        var response = await _colonyService.GetByIdAsync(key);

        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] ColonyDto entity){
        try
        {
            await _colonyService.AddAsync(entity);
        }
        catch (FailOnPersistEntityException<Colony>)
        {
            return BadRequest($"Colony {entity.Name} can not be created.");
        }
        catch (EntityAlreadyExistException<Colony>)
        {
            return BadRequest($"Colony {entity.Name} already exists.");
        }
        
        return Ok("Colony stored successfully.");
    }
    
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] ColonyDto entity){
        try
        {
            await _colonyService.UpdateAsync(entity);
        }
        catch (FailOnPersistEntityException<Colony> cEx)
        {
            return BadRequest($"Changes on Colony {entity.Name} can not be saved.");
        }
        catch (EntityNotFoundException<Colony> cEx)
        {
            return BadRequest($"Colony {entity.Name} don't exist yet.");
        }
        
        return Ok("Colony updated successfully.");
    }
    
    [HttpDelete("{key:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid key){
        try
        {
            await _colonyService.DeleteAsync(key);
        }
        catch (FailOnPersistEntityException<Colony> cEx)
        {
            return BadRequest($"Colony can not be deleted.");
        }
        catch (EntityNotFoundException<Colony> cEx)
        {
            return BadRequest($"Colony doesn't exist yet.");
        }
        
        return Ok("Colony deleted successfully.");
    }
}