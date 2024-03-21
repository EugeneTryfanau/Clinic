using Auth0.AspNetCore.Authentication;
using Clinic.BLL;
using Clinic.DAL;

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

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = configuration["Auth0:Domain"]!;
    options.ClientId = configuration["Auth0:ClientId"]!;
});

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