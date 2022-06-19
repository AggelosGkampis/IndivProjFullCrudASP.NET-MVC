﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkyDreaming.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string UrlImage { get; set; }

        public Room()
        {
            Angels = new HashSet<Angel>();
        }



        // Navigation Properties

        public ICollection<Angel> Angels { get; set; }
    }
}