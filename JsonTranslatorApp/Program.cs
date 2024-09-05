using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using JsonTranslatorApp;
using JsonTranslatorApp.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
    
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.RegisterServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();