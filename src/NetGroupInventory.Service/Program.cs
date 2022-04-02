using IdentityServer4.AccessTokenValidation;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Infrastructure;
using NetGroupInventory.Persistent;
using NetGroupInventory.Service.HttpHandlers;
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
    options.ApiName = "app_api";
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEFConfigurations(builder.Configuration);
builder.Services.AddInfraConfigurations();
builder.Services.AddMediatRConfiguration();
builder.Services.AddScoped<IUserIdentity, UserIdentity>();
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<CustomHttpClientHandler>();
builder.Services.AddHttpClient("authClient").AddHttpMessageHandler<CustomHttpClientHandler>();

var app = builder.Build();

app.UseCors("default");
app.ConfigureExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseUserIdentityMiddleware();

app.MapControllers();

app.Run();
