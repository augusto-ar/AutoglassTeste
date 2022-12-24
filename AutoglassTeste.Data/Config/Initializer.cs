using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using AutoglassTeste.Data.Interface;
using System.Linq;
using AutoglassTeste.Data.BLL;

namespace AutoglassTeste.Data.Config
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ConfigDBContext>(options => options.UseSqlServer(conection, b => b.MigrationsAssembly("AutoglassTeste.Api")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(ProdutoBLL));
        }
    }
}
