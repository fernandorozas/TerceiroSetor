using Microsoft.AspNetCore.Mvc;
using TerceiroSetor.Api.Configurations;
using TerceiroSetor.Api.Middlewares;
using TerceiroSetor.Application;
using TerceiroSetor.Data;
using TerceiroSetor.Emails;
using TerceiroSetor.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(c =>
{
    c.Filters.Add(typeof(AuthorizationFilter));

}).AddJsonOptions(opt => opt.JsonSerializerOptions.AllowTrailingCommas = true);

var identitySettings = new IdentitySettings();
builder.Configuration.GetSection("IdentitySettings").Bind(identitySettings);

builder.Services.Configure<ApiBehaviorOptions>
    (opts => opts.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationLayer();
builder.Services.AddEmail();
builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddKeycloack(identitySettings);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Total",
        builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }