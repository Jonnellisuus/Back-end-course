﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExample.Models
{
    public partial class RATE
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(3)]
        public string Country { get; set; }
        [Column("Rate", TypeName = "money")]
        public decimal? Rate1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }
    }
}