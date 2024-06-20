using Blazored.Modal;
using Blazored.Toast;
using TerceiroSetor.WebApp.Client.Services;
using TerceiroSetor.WebApp.Client.Settings;
using TerceiroSetor.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddHttpClient<IServiceOrganizacaoSocial, ServiceOrganizacaoSocial>();
builder.Services.AddSingleton<IServiceViaCep, ServiceViaCep>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TerceiroSetor.WebApp.Client._Imports).Assembly);

app.Run();
