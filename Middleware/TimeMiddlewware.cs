
public class TimeMiddleware
{

    
    readonly RequestDelegate next; //esta propiedad nos ayuda a invocar el siguiente middleware dentro del ciclo "RequestDelegate"

    public TimeMiddleware(RequestDelegate nextRequest) // este es un constructor para poder recibir esta dependencia "next"
    {
        next = nextRequest;
    }


    // invoke es un metodo que viene por defecto en todos los middleware
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) // y este HttpContext recibe toda la informacion del request
    {
        await next(context); // hacemos el llamado del siguiente middleware "el orden afecta el resultado"

        if(context.Request.Query.Any(p => p.Key == "time")) // si la url tiene un valor de Key "time" example="https://Jhordy?time" debuelve el la hora actual
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }

        
}
public static class TimeMiddlewareExtension // esta clase nos ayuda a que podamos agregar el pequeeño middleware dentro de la secuencia example="app.UseTimeMiddleware()"
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) //resibimos un IAplicationBuilder como parametro y lo retornamos con el nuevo middleware ya agregado
        {
            return builder.UseMiddleware<TimeMiddleware>(); //agregamos el middleware que resibimos y le agregamos el nuestro para que siga el siclo de vida
        }
    }
