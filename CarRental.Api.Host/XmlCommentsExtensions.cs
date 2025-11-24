using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CarRental.Api.Host;
public static class XmlCommentsExtensions
{
    public static void IncludeXmlComments(this SwaggerGenOptions options, Assembly assembly)
    {
        try
        {
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        }
        catch (Exception) { }
    }

    public static void IncludeAllXmlComments(this SwaggerGenOptions options, Assembly assembly)
    {
        options.IncludeXmlComments(assembly);

        foreach (var refAssembly in assembly.GetReferencedAssemblies())
        {
            if (refAssembly.Name!.StartsWith("System.") || refAssembly.Name.StartsWith("Microsoft."))
                continue;

            try
            {
                var loadedAssembly = Assembly.Load(refAssembly);
                options.IncludeXmlComments(loadedAssembly);
            }
            catch (Exception)
            { }
        }
    }
}