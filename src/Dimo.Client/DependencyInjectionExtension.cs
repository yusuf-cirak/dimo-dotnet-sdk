using System;
using Microsoft.Extensions.DependencyInjection;
using Dimo.Client.Streamr;
using Microsoft.Extensions.Options;
using GraphEnvironment = Dimo.Client.Graphql.DimoEnvironment;
using DimoEnvironment = Dimo.Client.DimoEnvironment;
using StreamrEnvironment = Dimo.Client.Streamr.DimoEnvironment;


namespace Dimo.Client
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDimoClient(this IServiceCollection services,
            Action<DimoClientOptions> options)
        {
            var clientOptions = new DimoClientOptions();
            options(clientOptions);

            if (clientOptions.Credentials != null)
            {
                services.AddSingleton(clientOptions.Credentials);
            }
            
            services.AddCoreServices(clientOptions.Environment);
            
            return services;
        }
    }

    public class DimoClientOptions
    {
        public DimoEnvironment Environment { get; set; }
        public ClientCredentials Credentials { get; set; }
    }
}
