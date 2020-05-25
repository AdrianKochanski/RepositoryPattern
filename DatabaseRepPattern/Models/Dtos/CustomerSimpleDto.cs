﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Models.Dtos
{
    public class CustomerSimpleDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string surname { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime lastActive { get; set; }
        public int Age { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string postalcode { get; set; }
        [Required]
        public int houseNumber { get; set; }
    }
}
