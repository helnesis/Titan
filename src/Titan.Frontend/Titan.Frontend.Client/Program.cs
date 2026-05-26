using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Diagnostics;
using Titan.Frontend.Client.Services.Titan;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
await builder.Build().RunAsync();


