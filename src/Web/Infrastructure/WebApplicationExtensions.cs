using System.Reflection;

namespace WindCrane.Web.Infrastructure;

public static class WebApplicationExtensions
{
    // Finds every IEndpointGroup in the assembly and maps it under its route prefix.
    public static WebApplication MapEndpoints(this WebApplication app, Assembly assembly)
    {
        var groupTypes = assembly.GetExportedTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t.IsAssignableTo(typeof(IEndpointGroup)));

        foreach (var type in groupTypes)
        {
            var prefix = (string)type.GetProperty(nameof(IEndpointGroup.RoutePrefix))!.GetValue(null)!;
            var group = app.MapGroup(prefix).WithTags(type.Name);
            type.GetMethod(nameof(IEndpointGroup.Map))!.Invoke(null, [group]);
        }

        return app;
    }
}
