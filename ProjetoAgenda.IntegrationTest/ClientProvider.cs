using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ProjetoAgendaAPI;
using System;
using System.Net.Http;

namespace ProjetoAgenda.IntegrationTest
{
    public class ClientProvider : IDisposable
    {
        private TestServer Server;
        public HttpClient Client;

        public ClientProvider()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
