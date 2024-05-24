using System.Security.Cryptography.X509Certificates;
using Notifications.BLL;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("secrets.json")
                .Build();

builder.Services.AddBLLDependencies(configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(options =>
{
    var certPath = Path.Combine(
        configuration["Kestrel:Certificates:Default:Path"]!,
        configuration["Kestrel:Certificates:Default:Cert"]!);
    var certPassword = configuration["Kestrel:Certificates:Default:Password"];
    
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        httpsOptions.ServerCertificate = new X509Certificate2(certPath, certPassword);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
