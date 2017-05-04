using System;
using Nancy;

namespace MicroServicesBase{


    public class CurrentDateTimeModule: NancyModule
{
    public CurrentDateTimeModule()
    {
        Get("/", _ => DateTime.UtcNow);
    } 
}}

