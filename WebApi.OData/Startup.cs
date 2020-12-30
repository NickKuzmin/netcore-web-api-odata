using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using WebApi.OData.Models;

namespace WebApi.OData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseMvc(p => p.MapODataServiceRoute("RouteName", "Route Prefix", GetEdmModel()));
            // /Cms/News
            // /Shop/Order
            // /Shop/Product
            app.UseMvc(p => p.MapODataServiceRoute("CmsRoute", "Cms", GetEdmCmsModel()));
            app.UseMvc(p => p.MapODataServiceRoute("ShopRoute", "Shop", GetEdmShopModel()));
        }

        private static IEdmModel GetEdmCmsModel()
        {
            var builder = new ODataConventionModelBuilder();
            var orderApiModel = builder.EntitySet<NewsApiModel>("News");
            orderApiModel.EntityType.Count().Filter().OrderBy().Expand().Select();

            return builder.GetEdmModel();
        }

        private static IEdmModel GetEdmShopModel()
        {
            var builder = new ODataConventionModelBuilder();
            var orderApiModel = builder.EntitySet<OrderApiModel>("Order");
            orderApiModel.EntityType.Count().Filter().OrderBy().Expand().Select();

            var productApiModel = builder.EntitySet<ProductApiModel>("Product");
            productApiModel.EntityType.Count().Filter().OrderBy().Expand().Select();

            return builder.GetEdmModel();
        }
    }
}
