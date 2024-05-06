using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gateway.API
{
    public static class AlterUpstream
    {
        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            return swagger.ToString(Formatting.Indented);
        }
    }
}
