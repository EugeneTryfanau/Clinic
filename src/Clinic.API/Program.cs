using Clinic.API.Middlewares;
using Clinic.BLL;
using Clinic.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins(configuration["ClientSide:ClientBase"]!)
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDALDependencies(configuration);
builder.Services.AddBLLDependencies();

var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = builder.Configuration["Auth0:Audience"];
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("receptionist", policy => policy.Requirements.Add(new HasScopeRequirement("receptionist", domain)));
    options.AddPolicy("doctor", policy => policy.Requirements.Add(new HasScopeRequirement("doctor", domain)));
    options.AddPolicy("patient", policy => policy.Requirements.Add(new HasScopeRequirement("patient", domain)));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();