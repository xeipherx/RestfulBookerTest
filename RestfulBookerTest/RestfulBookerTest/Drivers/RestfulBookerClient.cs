using RestfulBookerTest.Models;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestfulBookerTest.Drivers
{
    public static class RestfulBookerClient
    {
        static RestClient client = new RestClient();

        public static RestResponse PingHealthCheck()
        {
            var url = "https://restful-booker.herokuapp.com/ping";
            return client.Get(new RestRequest(url));
        }

        public static RestResponse GetToken(string username, string password)
        {
            var url = "https://restful-booker.herokuapp.com/auth";
            RestRequest request = new RestRequest(url);
            var userModel = new TokenRequestModel() 
            { 
                username = username, 
                password = password 
            };
            request.AddBody(JsonConvert.SerializeObject(userModel));
            return client.Post(request);
        }

        public static RestResponse GetBooking(int id)
        {
            var url = "https://restful-booker.herokuapp.com/booking/2";
            RestRequest request = new RestRequest(url);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            return client.Get(request);
        }

        public static RestResponse Createbooking(CreateBookingRequestModel model)
        {
            var url = "https://restful-booker.herokuapp.com/booking";
            RestRequest request = new RestRequest(url);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddBody(JsonConvert.SerializeObject(model));
            return client.Post(request);
        }
    }
}
