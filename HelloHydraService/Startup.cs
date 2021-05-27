namespace ExampleHydraService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection svc)
        {
            svc.AddControllers().AddJsonOptions(jsn => jsn.JsonSerializerOptions.WriteIndented = true);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting().UseEndpoints(ept => ept.MapControllers());
        }
    }
}
