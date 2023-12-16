using BlazorMinimalApiHtmx.HtmlApi.Components;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMinimalApiHtmx.HtmlApi;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/fail",
            async (BlazorRenderer renderer) =>
            {
                await Task.Delay(2000);
                return Results.Content(await renderer.RenderComponent<FormNoAction>(), "text/html");
            });
               

        app.MapGet("/success",
            async (BlazorRenderer renderer) =>
            {
                await Task.Delay(2000);
                return Results.Content(await renderer.RenderComponent<FormWithAction>(), "text/html");
            });

    }
}