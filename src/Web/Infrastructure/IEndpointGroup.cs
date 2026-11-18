namespace WindCrane.Web.Infrastructure;

// Implement this in Web/Endpoints to add a group of routes. No change to Program.cs is needed.
public interface IEndpointGroup
{
    static abstract string RoutePrefix { get; }

    static abstract void Map(RouteGroupBuilder group);
}
