using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantReview
{
    class ApiManager
    {
        public static string BaseUrl = "http://127.0.0.1:8686";

        public static DataTable GetRequest(string baseUrl, string subUrl)
        {
            var restClient = new RestClient(baseUrl);
            var request = new RestRequest(subUrl, Method.Get);

            var response = restClient.ExecuteGet(request);

            DataTable data = JsonConvert.DeserializeObject<DataTable>(response.Content!)!;

            return data;
        }
    }
}