using LeaveManagementSystem.UI;
using LeaveManagementSystem.UI.Services;
using LeaveManagementSystem.UI.Services.Base;
using LeaveManagementSystem.UI.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7232"));

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();  
builder.Services.AddScoped<ILeaveTypeRequestService, LeaveTypeRequestService>();  
builder.Services.AddScoped<ILeaveTypeAllocationService, LeaveTypeAllocationService>();  

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
