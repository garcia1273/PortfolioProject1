using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AJWebsite
{
    public class Customer
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [MaxLength(5)]
        public string Zip { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Key]
        [DisplayName("Client")]
        public int ClientId { get; set; }

        public string email { get; set; }
    }
}