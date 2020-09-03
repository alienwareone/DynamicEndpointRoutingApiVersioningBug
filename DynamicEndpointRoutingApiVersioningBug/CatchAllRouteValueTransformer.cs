using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace DynamicEndpointRoutingApiVersioningBug
{
    public class CatchAllRouteValueTransformer : DynamicRouteValueTransformer
    {
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            await Task.CompletedTask;

            if (httpContext.Request.Path == "/Test")
            {
                return new RouteValueDictionary(new { controller = "Home", action = "CatchAll" });
            }

            return null;
        }
    }
}