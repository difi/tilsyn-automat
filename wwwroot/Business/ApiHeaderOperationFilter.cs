using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class ApiHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "UserGuid",
                In = "header",
                Type = "string",
                Required = true
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Lang",
                In = "header",
                Type = "string",
                Required = true
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "ApiKey",
                In = "header",
                Type = "string",
                Required = true
            });
        }
    }
}