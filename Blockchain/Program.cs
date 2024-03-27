using Blockchain.Data;
using Blockchain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Radzen
builder.Services.AddRadzenComponents();
//Service
builder.Services.AddHttpClient();
builder.Services.AddTransient<IApiService,ApiService>();

//Config
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));



var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
