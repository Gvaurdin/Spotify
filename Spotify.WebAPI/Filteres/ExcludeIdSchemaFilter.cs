using Microsoft.OpenApi.Models;
using Spotify.Database.Entities;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Spotify.WebAPI.Filteres
{
    public class ExcludeIdSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Song))
            {
                schema.Properties.Remove("Id"); // Удаляет поле "Id" из схемы Swagger
            }
        }
    }
}
