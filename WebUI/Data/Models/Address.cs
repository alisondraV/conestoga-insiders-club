﻿using System;
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

        [StringLength(50)]
        public string Address1 { get; set; }
        
        [StringLength(25)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string Province { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        public ICollection<ApplicationUser> ShippingUsers { get; set; }
        public ICollection<ApplicationUser> MailingUsers { get; set; }
    }
}
