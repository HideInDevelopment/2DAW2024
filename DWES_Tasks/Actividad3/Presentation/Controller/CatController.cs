using Actividad3.Common.Validators;
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
    public async Task<ActionResult> Create([FromBody] CatDto entity){
        try
        {
            await _catService.AddAsync(entity);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpPut()]
    public async Task<ActionResult> Update([FromBody] CatDto entity){
        var response = await _catService.UpdateAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpDelete("{key:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid key){
        var response = await _catService.DeleteAsync(key);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}
