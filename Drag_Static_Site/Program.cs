using Blazored.LocalStorage;
using Drag_Static_Site;
using Drag_Static_Site.Constants;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddMudMarkdownServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<PostCollection>();

await builder.Build().RunAsync();

