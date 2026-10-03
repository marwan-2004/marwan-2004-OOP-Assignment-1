using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public bool IsVip { get; set; }

        public Customer(int Id, string Name, string Email, string City, bool IsVip)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.City = City;
            this.IsVip = IsVip;
        }
        public override string ToString()
        {
            return $"Customer Id: {Id}, Name: {Name}, Email: {Email}, City: {City}, Is VIP: {IsVip}";
        }
    }
}
