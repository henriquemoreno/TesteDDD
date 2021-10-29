using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteDDD.Application.AutoMapper;

namespace TesteDDD.UI.Site.Configurations
{
    public static class MapperConfig
    {
        public static IServiceCollection MapperConfiguration(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
