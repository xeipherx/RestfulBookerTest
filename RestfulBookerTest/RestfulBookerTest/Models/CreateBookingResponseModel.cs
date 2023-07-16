﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulBookerTest.Models
{
    class CreateBookingResponseModel
    {
        public int bookingid { get; set; }
        public Booking booking { get; set; }
    }

    public class Booking
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public Bookingdates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }

    public class Bookingdates
    {
        public string checkin { get; set; }
        public string checkout { get; set; }
    }
}
