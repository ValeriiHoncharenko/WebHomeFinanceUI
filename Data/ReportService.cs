using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace WebHomeFinanceUI.Data
{
    public class ReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<RootObjectReport>> OnGetAsync(string date)
        {
            if (date == null)
            {
                date = DateTime.Now.ToString("MM.dd.yyyy");
            }
            List<RootObjectReport> rootObjectReport;
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string pathJson = connectionString + "report?date1=" + date;
                rootObjectReport = null;
                HttpResponseMessage response = await client.GetAsync(pathJson);
                if (response.IsSuccessStatusCode)
                {
                    rootObjectReport = await response.Content.ReadAsAsync<List<RootObjectReport>>();
                }
                return rootObjectReport;
            }
        }
    }
}
