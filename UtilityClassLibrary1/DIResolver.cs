using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentData.Core.IRepository;
using StudentData.Core.IServices;
using StudentDetail.Repository;
using StudentDetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IServices, Services>();
            services.AddScoped<IRepository, Repository>();
        }
    }
}
