using Proyecto2_AppWeb.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Proyecto2_AppWeb.BusinessLogic
{
    public class RequestHandler
    {
        static HttpClient httpClient = new HttpClient();

        public HttpResponseMessage AddClient(Client client)
        {
            var uri = new Uri("http://localhost:55011/api/Clients/Agregar_Cliente");
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = httpClient.PostAsJsonAsync<Client>(uri, client).Result;

            return res;

        }

        public HttpResponseMessage FindClient(string clientId)
        {
            var uri = new Uri("http://localhost:55011/api/Clients/Buscar_Cliente/" + clientId);
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = httpClient.GetAsync(uri).Result;
            return res;
        }

        public HttpResponseMessage UpdateClient(Client client)
        {
            var uri = new Uri("http://localhost:55011/api/Clients/Editar_Cliente/");
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = httpClient.PutAsJsonAsync<Client>(uri, client).Result;
            return res;
        }

        public HttpResponseMessage GetAllProspects()
        {
            var uri = new Uri("http://localhost:55011/api/Campanas_Publicitarias/Listar_Promociones_Mensuales/");
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = httpClient.GetAsync(uri).Result;
            return res;
        }

        public HttpResponseMessage GetAllBadProspects()
        {
            var uri = new Uri("http://localhost:55011/api/Campanas_Publicitarias/Lista_Peores_Clientes/");
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = httpClient.GetAsync(uri).Result;
            return res;
        }

        public HttpResponseMessage GetAllClients()
        {
            var uri = new Uri("http://localhost:55011/api/Clients/Conseguir_Clientes");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.GetAsync(uri).Result;
        }
    }
}