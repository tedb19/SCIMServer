﻿namespace SCIMServer.Resources
{
    public class AddressResource
    {
        public string Country { get; set; } // TODO: Should be an enum
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
    }
}
