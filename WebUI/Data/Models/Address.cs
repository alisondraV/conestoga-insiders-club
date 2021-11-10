using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class Address
    {
        public Address()
        {
            ShippingUsers = new HashSet<ApplicationUser>();
            MailingUsers = new HashSet<ApplicationUser>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        
        public ICollection<ApplicationUser> ShippingUsers { get; set; }
        public ICollection<ApplicationUser> MailingUsers { get; set; }
    }
}
