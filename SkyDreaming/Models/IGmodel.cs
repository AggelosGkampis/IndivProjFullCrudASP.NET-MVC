using SkyDreaming.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace SkyDreaming.Models
{
    public class IGmodel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Give something ... its not that hard ffs")]
        [MaxLength(20,ErrorMessage ="LENGHT MUST BE MAXIMUM 20 NUMBERS")]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(45,75)]
        public int Kg { get; set; }

       
        public double Height { get; set; }

        public HairColor HairColor { get; set; }

        [Range(18,40)]
        public int Age { get; set; }

        public string ImageUrl { get; set; }


        // Foreign Keys
        public int RoomId { get; set; }

        // Navigation Properties

        public Room Room { get; set; }
    }
}