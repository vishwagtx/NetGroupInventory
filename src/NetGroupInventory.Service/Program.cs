using IdentityServer4.AccessTokenValidation;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Persistent;
using NetGroupInventory.Service.MediatR;
using NetGroupInventory.Service.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityUrl = builder.Configuration.GetValue<string>("IdentityServerUrl");

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
.AddIdentityServerAuthentication(options =>
{
    options.Authority = identityUrl;
    options.RequireHttpsMetadata = false;
    options.ApiName = "spa_api";
    options.EnableCaching = true;
    options.CacheDuration = TimeSpan.FromMinutes(60);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEFConfigurations(builder.Configuration);
builder.Services.AddMediatRConfiguration();
builder.Services.AddScoped<IUserIdentity, UserIdentity>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseUserIdentityMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
