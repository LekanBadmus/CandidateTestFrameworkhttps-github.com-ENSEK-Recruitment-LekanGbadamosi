using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAutomation.SetUp
{
    public class Context

    {

        private Context _context;
        private RestResponse _response;
        public string content = string.Empty;
        public string statusCode = string.Empty;
        public string baseUrl = "https://qacandidatetest.ensek.io/";
        public void GetMethod(string resource)

        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Get);
            var result = client.Execute(request);
            content = result.Content;
            statusCode = result.StatusCode.ToString();
        }

        public void PostMethod(string resource, object body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }

        public void PutMethod(string resource, object body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }

        public void DeleteMethod(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Delete);
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
        }
    }
}