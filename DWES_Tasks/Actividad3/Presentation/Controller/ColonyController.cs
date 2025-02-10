using Actividad3.Common.Validators;
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
        var response = await _colonyService.AddAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPut()]
    public ActionResult Update([FromBody] ColonyDto entity){
        var response = _colonyService.UpdateAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpDelete("{key:guid}")]
    public ActionResult Delete([FromRoute] Guid key){
        var response = _colonyService.DeleteAsync(key);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}