using SkyDreaming.Models.CustomValidations;
using System;
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
        [Required(ErrorMessage ="You must give a name")]
        [CustomValidation(typeof(MyValidationMethods), "ValidateFirstCapitalLetter")]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string UrlImage { get; set; }

        public Room()
        {
            IGmodels = new HashSet<IGmodel>();
        }



        // Navigation Properties

        public ICollection<IGmodel> IGmodels { get; set; }
    }
}