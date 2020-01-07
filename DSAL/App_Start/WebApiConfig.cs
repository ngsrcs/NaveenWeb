using DSAL.Models;
using DSAL.Resolver;
using System.Web.Http;
using Unity;

namespace DSAL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            var container = new UnityContainer();
            //container.RegisterType<IRepository<Employee>, EntitySqlRepository<Employee>>();
            container.RegisterType<IRepository, EntityMongoRepository>();            
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
