using ClientApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiUrl"] ?? string.Empty;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5063/") });

await builder.Build().RunAsync();
