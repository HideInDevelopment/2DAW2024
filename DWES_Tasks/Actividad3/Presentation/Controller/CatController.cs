using Actvidad3.Common.Validators;
using Actvidad3.Domain.Services;
using Actvidad3.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Actvidad3.Presentation.Controller;

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
        //var response = await _catService.GetAllAsync();
        var response = await _catService.GetStoredCatItems();

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
        var response = await _catService.AddAsync(entity);
        if (EntityValidator.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
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
