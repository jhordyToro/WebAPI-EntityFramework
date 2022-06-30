using Microsoft.AspNetCore.Mvc;
using minimalAPIef;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase // generamos todo lo necesario para los controladores 
{
    // private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldServices; // recivimos la dependencia de IHelloWorldService

    // public HelloWorldController(ILogger<HelloWorldController> logger)
    // {
    //     _logger = logger;   
    // }

    TaskContext dbContext;

    public HelloWorldController(IHelloWorldService helloWorld, TaskContext db) //la recivimos a travez de un constructor 
    {
        helloWorldServices = helloWorld; // y lo guardamos en la propiedad helloWorldServices 
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // _logger.LogInformation("Writen Hello World");
        return Ok(helloWorldServices.GetHelloWorld());

    }
    [HttpGet]
    [Route("Createdb")]
    public IActionResult CreateDataBase()
    {
        // _logger.LogInformation("Writen Hello World");
        dbContext.Database.EnsureCreated();
        return Ok();

    }
}