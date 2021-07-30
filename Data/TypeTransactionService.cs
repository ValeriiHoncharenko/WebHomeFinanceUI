using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Configuration;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
namespace WebHomeFinanceUI.Data
{
    public class TypeTransactionService
    {
        private readonly IConfiguration _configuration;

        public TypeTransactionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<RootObjectType>> OnGetAsync()
        {
            List<RootObjectType> rootobject;
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string pathJson = connectionString + "typetransaction";
                rootobject = null;
                HttpResponseMessage response = await client.GetAsync(pathJson);
                if (response.IsSuccessStatusCode)
                {
                    rootobject = await response.Content.ReadAsAsync<List<RootObjectType>>();
                }

                return rootobject;
            }
        }
    }
}
