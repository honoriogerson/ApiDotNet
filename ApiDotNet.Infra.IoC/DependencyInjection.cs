using ApiDotNet.Application.Mappings;
using ApiDotNet.Application.Services;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using ApiDotNet.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Infra.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Injeção do bd
            services.AddDbContext<ApplicationDBContext>(options =>
                                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //Injeção dos repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IItensRepository, ItensRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //injeção de serviços
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IItensService, ItensService>();
            services.AddScoped<IPedidoService, PedidoService>();
            return services;
        }
    }
}
