using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Scrunity.Learning.Persistance;
using Scrunity.Learning.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var connectionString = "Host=localhost;Port=5432;Database=scrunity-db;Username=postgres;Password=1111";
builder.Services.AddPersistence(connectionString);
builder.Services.AddApplication();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
