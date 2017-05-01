using System;
using Nancy;

namespace MicroServicesHelloWorld{


public class CurrentDateTimeModule: NancyModule
{
    public CurrentDateTimeModule()
    {
        Get("/", _ => DateTime.UtcNow);
    }
}
}