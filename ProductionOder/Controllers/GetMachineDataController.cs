using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using ProductionOrder.Data;

namespace ProductionOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMachineDataController
    {
        private const string URL = "http://14.224.131.119:8005/iotgateway/browse";
        private const string URLDetail = "http://14.224.131.119:8005/iotgateway/read";

        private readonly ProductionOrderDbContext _ProductionOderDbContext;

        // Get Machine Data
        [HttpGet("GetData")]
        public async Task<string> GetMachineData()
        {

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            byte[] cred = UTF8Encoding.UTF8.GetBytes("Administrator:Hahabab@909090");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //   System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(URL).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }
            return description;
        }



        // Get Machine Data
        [HttpGet("GetDataDetail")]
        public async Task<string> GetMachineDataDetail(String MachineNo)
        {
            string urlDetail = "http://14.224.131.119:8005/iotgateway/read?ids=" + MachineNo + "";



            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(urlDetail);
            byte[] cred = UTF8Encoding.UTF8.GetBytes("Administrator:Hahabab@909090");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //   System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(urlDetail).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }
            return description;
        }


    }
}
