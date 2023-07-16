using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using TechTalk.SpecFlow;
using RestfulBookerTest.Drivers;
using TechTalk.SpecFlow.Assist;
using RestfulBookerTest.Models;

namespace RestfulBookerTest.Steps
{
    [Binding]
    public class RestfulBookerStepDefinitions
    {
        [Given(@"I ping the restful booker healthcheck service")]
        public void GivenIPingTheRestfulBookerHealthcheckService()
        {
            RestfulBookerGeneral.GetHealthCheck();
        }

        [Given(@"I login with the faulty user")]
        public void GivenILoginWithTheFaultyUser()
        {
            RestfulBookerGeneral.GetToken("PietPiraat","SchipAhoy");
        }

        [Given(@"I request for booking ID '(.*)'")]
        public void GivenIRequestForBookingID(int id)
        {
            RestfulBookerGeneral.GetBookingId(id);
        }

        [Given(@"I login with the default user")]
        public void GivenILoginWithTheDefaultUser()
        {
            RestfulBookerGeneral.GetToken();
        }

        [Given(@"I create a new booking with these data")]
        public void GivenICreateANewBookingWithTheseData(Table table)
        {
            var booking = table.CreateInstance<CreateBookingRequestModel>();
            booking.bookingdates.checkin = table.Rows[0]["checkin"];
            booking.bookingdates.checkout = table.Rows[0]["checkout"];
            RestfulBookerGeneral.Createbooking(booking);
        }

        [Then(@"I expect a '(.*)' response")]
        public void ThenIExpectAResponse(int statusCode)
        {
            RestfulBookerGeneral.CheckStatusCode(statusCode);
        }

        [Then(@"The response model should match the model")]
        public void ThenTheResponseModelShouldMatchTheModel()
        {
            RestfulBookerGeneral.CheckGetBookingResponseModel();
        }

        [Then(@"The response has a booking id")]
        public void ThenTheResponseHasABookingId()
        {
            RestfulBookerGeneral.CheckBookingIdFromResponse();
        }

    }
}
