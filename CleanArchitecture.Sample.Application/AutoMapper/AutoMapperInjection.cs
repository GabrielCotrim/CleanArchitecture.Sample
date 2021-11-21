using AutoMapper;
using CleanArchitecture.Sample.Application.DTOs.Requests;
using CleanArchitecture.Sample.Application.DTOs.Responses;
using CleanArchitecture.Sample.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Sample.Application.AutoMapper
{
    public static class AutoMapperInjection
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection service)
        {
            var mapperConfig = new MapperConfiguration(config =>
           {
               config.CreateMap<CreateProductRequest, Product>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Stock,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );

               config.CreateMap<UpdateProductRequest, Product>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );

               config.CreateMap<Product, ProductResponse>();
           });
            var mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
}
