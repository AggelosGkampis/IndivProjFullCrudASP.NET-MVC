using SkyDreaming.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyDreaming.Models
{
    public class Angel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Kg { get; set; }

        public double Height { get; set; }

        public HairColor HairColor { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }
    }
}