using System.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace WebHomeFinanceUI.Data
{
    public class ReportMonthlyService
    {
        private readonly IConfiguration _configuration;

        public ReportMonthlyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<RootObjectReport>> OnGetMonthlyAsync(string dateStart, string dateEnd)
        {
            if (dateStart == null)
            {
                dateStart = DateTime.Now.ToString("MM.dd.yyyy");
            }
            if (dateEnd == null)
            {
                dateEnd = DateTime.Now.ToString("MM.dd. yyyy");
            }

           List<RootObjectReport> rootObjectReportMonthly;
            using (var client = new HttpClient())
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string pathJson = connectionString + "report?date1=" + dateStart + "&date2=" + dateEnd;
                rootObjectReportMonthly = null;
                HttpResponseMessage response = await client.GetAsync(pathJson);
                if (response.IsSuccessStatusCode)
                {
                    rootObjectReportMonthly = await response.Content.ReadAsAsync<List<RootObjectReport>>();
                }
                return rootObjectReportMonthly;
            }
        }
    }
}
