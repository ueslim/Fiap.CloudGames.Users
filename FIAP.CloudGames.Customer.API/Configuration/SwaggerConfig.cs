using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FIAP.CloudGames.Customer.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Customer API",
                    Version = "v1",
                    Description = "This API is part of the FIAP Cloud Games Application.",
                    Contact = new OpenApiContact { Name = "FIAP GAMES", Email = "example@gmail.com" },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

                // Ensure OpenAPI 3.0.1 format for Azure API Management compatibility
                c.CustomSchemaIds(type => type.Name.Replace("[]", "Array"));
                
                // Ensure nullable types are handled correctly for OpenAPI 3.0.1
                c.SchemaFilter<MakeNullableSchemaFilter>();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Cole apenas o token JWT. O prefixo 'Bearer ' será adicionado automaticamente.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API v1");
                c.RoutePrefix = "swagger";
            });
        }
    }

    /// <summary>
    /// Schema filter to ensure nullable properties are marked correctly for OpenAPI 3.0.1
    /// </summary>
    public class MakeNullableSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // Ensure proper nullable handling for OpenAPI 3.0.1 compatibility
            if (context.Type.IsGenericType && context.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                schema.Nullable = true;
            }
            else if (context.Type == typeof(string) || context.Type == typeof(DateTime) || context.Type == typeof(DateTime?))
            {
                schema.Nullable = false;
            }
        }
    }
}