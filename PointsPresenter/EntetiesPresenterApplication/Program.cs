using Blazored.LocalStorage;
using Infrastructure.Hubs;
using Infrastructure.Ioc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Model.Infrastructure.Ioc;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.RegisterComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(
    options =>
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] {"application/octet-stream"}));

builder.Services.LoadConfigurations();
builder.Services.AddMudServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
     builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("NewPolicy");

app.MapBlazorHub();
app.MapHub<PointHub>("/pointhub");
app.MapFallbackToPage("/_Host");
app.UseResponseCompression();

InitializeApplicationResolver(app);

app.Run();

void InitializeApplicationResolver(WebApplication app)
{
    var applicationResolver = (IApplicationResolver)app.Services.GetService(typeof(IApplicationResolver));
    applicationResolver.Init(app.Services);
}
