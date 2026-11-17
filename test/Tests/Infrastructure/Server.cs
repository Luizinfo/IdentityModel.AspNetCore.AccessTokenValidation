using System;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using IdentityModel.AspNetCore.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests.Infrastructure
{
    public class Server
    {
        public string ForwardScheme { get; set; }
        
        public bool AddForwarder { get; set; }
        
        public TestServer CreateServer()
        {
            var host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            var builder = services.AddAuthentication("test");
                            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("test", o =>
                            {
                                if (AddForwarder)
                                {
                                    o.ForwardDefaultSelector = !string.IsNullOrEmpty(ForwardScheme)
                                        ? Selector.ForwardReferenceToken(ForwardScheme)
                                        : Selector.ForwardReferenceToken();
                                }
                            });
                        })
                        .Configure(app =>
                        {
                            app.UseAuthentication();

                            app.Run(context =>
                            {
                                var user = context.User;

                                context.Response.StatusCode = user.Identity.IsAuthenticated ? 200 : 401;

                                return Task.CompletedTask;
                            });
                        });
                })
                .Start();

            return host.GetTestServer();
        }
        
        public HttpClient CreateClient()
        {
            return CreateServer().CreateClient();
        }
    }
}
