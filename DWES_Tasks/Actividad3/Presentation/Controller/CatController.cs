using Actividad3.Common.Validators;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Exceptions;
using Actividad3.Domain.Services;
using Actividad3.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3.Presentation.Controller;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    private readonly ICatService _catService;

    public CatController(ICatService catService)
    {
        _catService = catService;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        var response = await _catService.GetAllAsync();

        if (ListValidator.IsNullOrEmpty(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpGet("{key:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid key)
    {
        var response = await _catService.GetByIdAsync(key);

        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] CatDto entity)
    {
        try
        {
            await _catService.AddAsync(entity);
        }
        catch (FailOnPersistEntityException<Cat> cEx)
        {
            return BadRequest($"Cat {entity.Name} can not be stored.");
        }
        catch (EntityAlreadyExistException<Cat> cEx)
        {
            return BadRequest($"Cat {entity.Name} already exists.");
        }
        
        return Ok("Cat stored successfully.");
    }
    
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] CatDto entity){
        try
        {
            await _catService.UpdateAsync(entity);
        }
        catch (FailOnPersistEntityException<Cat> cEx)
        {
            return BadRequest($"Changes on Cat {entity.Name} can not be saved.");
        }
        catch (EntityNotFoundException<Cat> cEx)
        {
            return BadRequest($"Cat {entity.Name} doesn't exist yet.");
        }
        
        return Ok("Cat updated successfully.");
    }
    
    [HttpDelete("{key:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid key){
        try
        {
            await _catService.DeleteAsync(key);
        }
        catch (FailOnPersistEntityException<Cat> cEx)
        {
            return BadRequest($"Cat can not be deleted.");
        }
        catch (EntityNotFoundException<Cat> cEx)
        {
            return BadRequest($"Cat doesn't exist yet.");
        }
        
        return Ok("Cat deleted successfully.");
    }
}
