using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class AddressBuilder
    {
        private string _street = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _zipCode = string.Empty;
        private string _country = string.Empty;

        public AddressBuilder WithStreet(string street) { _street = street; return this; }
        public AddressBuilder WithCity(string city) { _city = city; return this; }
        public AddressBuilder WithState(string state) { _state = state; return this; }
        public AddressBuilder WithZipCode(string zipCode) { _zipCode = zipCode; return this; }
        public AddressBuilder WithCountry(string country) { _country = country; return this; }

        public Address Build()
        {
            if (string.IsNullOrWhiteSpace(_street))
                throw new InvalidOperationException("Address validation failed: 'Street' is required.");

            if (string.IsNullOrWhiteSpace(_city))
                throw new InvalidOperationException("Address validation failed: 'City' is required.");

            if (string.IsNullOrWhiteSpace(_country))
                throw new InvalidOperationException("Address validation failed: 'Country' is required.");

            return new Address(_street, _city, _state, _zipCode, _country);
        }
    }
}
