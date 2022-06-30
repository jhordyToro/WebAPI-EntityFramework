using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForcast = new List<WeatherForecast>(); // Generamos una lista en la cual se van a guardar los objetos que se generen

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        

        // en este if vemos si la lista si la lista es nula o si no tiene ningun registo para agregarle los valores iniciales
        if (ListWeatherForcast == null || !ListWeatherForcast.Any()) // Any si tiene algun registro
        {
            ListWeatherForcast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    // este httpGet funciona como los decoradores de Django o FastApi los cules le indica que queremos hacer este viene de REST, con el Get buscamos obtener algo de la pagina 
    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("get")] // esta el la forma para asignar rutas en webapi
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("returning the list weatherForecast");
        return ListWeatherForcast;
    }

    // con este httpPost buscamos postear o subir algo a la "base de datos" con los mismos parametros predeterminados
    [HttpPost]
    // [Route("post")]
    // [Route("[action]")] // este metodo de Route toma el nombre del la accion que en este caso seria "post"
    public IActionResult Post(WeatherForecast WeatherForecast)
    {
        ListWeatherForcast.Add(WeatherForecast);

        return Ok();
    }

    // Este httpDelete buscamos Eliminar un elemento de la lista, le indicamos que le vamos a pasar un numero por la url que va a ser el index por el cual se va a guiar el programa para eliminar el valor de la lista
    [HttpDelete("{index}")]
    // [Route("delete")]
    public IActionResult Delete(int index)
    {
        ListWeatherForcast.RemoveAt(index);
        return Ok();
    }

}
