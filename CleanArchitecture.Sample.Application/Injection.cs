using CleanArchitecture.Sample.Application.ApplicationServices;
using CleanArchitecture.Sample.Application.AutoMapper;
using CleanArchitecture.Sample.Application.Interfaces.ApplicationServices;
using CleanArchitecture.Sample.Application.Interfaces.Services;
using CleanArchitecture.Sample.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Sample.Application
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service)
        {
            service.RegisterAutoMapper();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductApplicationService, ProductApplicationService>();
            return service;
        }
    }
}