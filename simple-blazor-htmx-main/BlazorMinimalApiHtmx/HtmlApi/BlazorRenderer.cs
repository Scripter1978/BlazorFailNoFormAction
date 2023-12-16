using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.HtmlRendering;

namespace BlazorMinimalApiHtmx.HtmlApi;
// ref: https://andrewlock.net/exploring-the-dotnet-8-preview-rendering-blazor-components-to-a-string/
internal class BlazorRenderer(HtmlRenderer htmlRenderer)
{
    // Renders a component T which doesn't require any parameters
    public Task<string> RenderComponent<T>() where T : IComponent
        => RenderComponent<T>(ParameterView.Empty);

    
    private Task<string> RenderComponent<T>(ParameterView parameters) where T : IComponent
    {
        // Use the default dispatcher to invoke actions in the context of the 
        // static HTML renderer and return as a string
        return htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            HtmlRootComponent output = await htmlRenderer.RenderComponentAsync<T>(parameters);
            return output.ToHtmlString();
        });
    }
}