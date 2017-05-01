using System;
using Nancy;

namespace MicroServicesHelloWorld{


public class CurrentDateTimeModule: NancyModule
{
    public CurrentDateTimeModule()
    {
        Get("/", _ => {
            
            var response = (Response)("\""+DateTime.UtcNow.ToString()+"\"");

        response.ContentType = "application/json";
        

        return response;


            });
    }
}
}