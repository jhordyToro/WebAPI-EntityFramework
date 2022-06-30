using Microsoft.AspNetCore.Mvc;
using minimalAPIef.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService categoryservice;

    public CategoryController(ICategoryService category)
    {
        categoryservice = category;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryservice.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        categoryservice.Save(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id , [FromBody] Category category)
    {
        categoryservice.Update(id,category);
        return Ok();
    }
    
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryservice.Delete(id);
        return Ok();
    }
}