﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("addresses")]
    public partial class Address
    {
        [Key]
        [Column("nickname")]
        [StringLength(50)]
        public string Nickname { get; set; }
        [Column("address1")]
        [StringLength(50)]
        public string Address1 { get; set; }
        [Column("address2")]
        [StringLength(25)]
        public string Address2 { get; set; }
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Column("province")]
        [StringLength(2)]
        public string Province { get; set; }
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [ForeignKey(nameof(Nickname))]
        [InverseProperty(nameof(User.Address))]
        public virtual User NicknameNavigation { get; set; }
    }
}
