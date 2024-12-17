using Actividad2.Domain.Dto;
using Actividad2.Domain.Generic.Interface;
using Actividad2.Functions;
using Microsoft.AspNetCore.Mvc;

namespace Actividad2.Controller;

[ApiController]
[Route("[controller]")]
public class CatController(IEntityService<Guid, CatDto> catService) : ControllerBase
{
    [HttpGet()]
    public ActionResult GetCats()
    {
        var response = catService.Get();
        if (ExtensionFunctions.IsNullOrEmpty(response))
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public ActionResult GetCat([FromRoute] Guid id)
    {
        var response = catService.Get(id);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPost()]
    public ActionResult CreateCat([FromBody] CatDto cat){
        var response = catService.Create(cat);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPut()]
    public ActionResult UpdateCat([FromBody] CatDto cat){
        var response = catService.Update(cat);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteCat([FromRoute] Guid id){
        var response = catService.Delete(id);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}