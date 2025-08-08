using Microsoft.Extensions.Configuration;

IConfiguration initialRoot = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();