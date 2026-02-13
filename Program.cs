using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionsDemo.Classes;
using OptionsDemo.Classes.Interfaces;
using OptionsDemo.Configuration;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetBasePath("C:\\Users\\thomas.hartman\\Documents\\Repositories\\OptionsDemo\\");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<BaseConfig>(
    BaseConfig.FirstConfig,
    builder.Configuration.GetSection("Configs:FirstConfig"));

builder.Services.Configure<BaseConfig>(
    BaseConfig.SecondConfig,
    builder.Configuration.GetSection("Configs:SecondConfig"));

builder.Services.AddOptions<ValidatedConfig>()
    .Bind(builder.Configuration.GetSection(ValidatedConfig.SectionName))
    .ValidateDataAnnotations()
    .Validate(ValidatedConfig.ValidateIsFull)
    .Validate(ValidatedConfig.ValidateShipmentCode)
    .Validate(ValidatedConfig.ValidateTrackingUrl)
    .ValidateOnStart();

builder.Services.AddScoped<ILineWriter, LineWriterService>();

using IHost host = builder.Build();

await host.Services.GetRequiredService<ILineWriter>().RunAsync();