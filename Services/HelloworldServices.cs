//Inyeccionde dependensias "funciones para los amigos xd"

public class HelloWorldServices : IHelloWorldService //Generamos una clase eredando de la interfaz "IHelloWorldService" este es una manera de indicar que queremos retornar lo especificamos en la interfaz de abajo :D
{
    public string GetHelloWorld() //especificamos que que queremos hacer y lo retornamos
    {
        return "Hello world";
    }
}

public interface IHelloWorldService // aqui hacemos una interfaz para indicarle a la clase de arriba que queremos que retorne :b
{
    string GetHelloWorld(); //y el valor que vayamos a retornar
}