using Newtonsoft.Json;
using NJsonSchema;
using NUnit.Framework;
using RestfulBookerTest.Drivers;
using RestfulBookerTest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulBookerTest
{
    public static class RestfulBookerGeneral
    {
        static RestResponse response = new RestResponse() { StatusCode = System.Net.HttpStatusCode.Gone}; // where is my statuscode 418 damnit microsoft

        public static void GetHealthCheck()
        {
            response = RestfulBookerClient.PingHealthCheck();
        }

        public static void CheckStatusCode(int statusCode)
        {
            Assert.AreEqual((int)response.StatusCode, statusCode);
        }

        public static void GetToken(string username = "admin", string password = "password123")
        {
            response = RestfulBookerClient.GetToken(username, password);
        }

        public static void GetBookingId(int id)
        {
            response = RestfulBookerClient.GetBooking(id);
        }

        public static void Createbooking(CreateBookingRequestModel booking)
        {
            response = RestfulBookerClient.Createbooking(booking);
        }

        public static void CheckBookingIdFromResponse()
        {
            var bookingResponse = JsonConvert.DeserializeObject<CreateBookingResponseModel>(response.Content);
            Assert.IsNotNull(bookingResponse.bookingid);
        }

        public static void CheckGetBookingResponseModel()
        {
            var schema = JsonSchema.FromType<GetBookingResponseModel>();
            var errors = schema.Validate(response.Content);
            Assert.IsEmpty(errors);
        }
    }
}
