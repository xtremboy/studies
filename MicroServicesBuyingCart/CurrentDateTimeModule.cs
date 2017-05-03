using System;
using Nancy;

namespace MicroServicesBuyingCart{


    public class CurrentDateTimeModule: NancyModule
{
    public CurrentDateTimeModule()
    {
        Get("/", _ => DateTime.UtcNow);
    } 
}}

