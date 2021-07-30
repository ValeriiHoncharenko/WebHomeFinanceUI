using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace WebHomeFinanceUI.Data
{
    public class RegisterTransactionService 
    {

        private readonly IConfiguration _configuration;

        public RegisterTransactionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<RootObjectRegister>> OnGetAsync()
        {
            List<RootObjectRegister> rootobject;
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string pathJson = connectionString + "registertransaction";
                rootobject = null;
                HttpResponseMessage response = await client.GetAsync(pathJson);
                if (response.IsSuccessStatusCode)
                {
                    rootobject = await response.Content.ReadAsAsync<List<RootObjectRegister>>();
                }

                return rootobject;
            }
           
        }

        public async Task<HttpResponseMessage> InsertNewTypeAsync(RootObjectRegister date)
        {
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                client.BaseAddress = new Uri(connectionString);
                string RequestURI = "registertransaction";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(RequestURI, date).Result;
                return response;
            }
        }

        public async Task DeleteTypeAsync(int Id)
        {
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                client.BaseAddress = new Uri(connectionString);
                string RequestURI = "registertransaction";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(RequestURI, Id).Result;
                await client.DeleteAsync($"registertransaction/{Id}");               
            }
        }
        public async Task UpdateTypeAsync(RootObjectRegister date)
        {
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                client.BaseAddress = new Uri(connectionString);
                string RequestURI = "registertransaction";
                await client.PutAsJsonAsync(RequestURI, date);            
            }
        }
    }
}

