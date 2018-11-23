using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
   public class Car : EntityBase
    {
        public int? UserID { get; set; }
        [Required(ErrorMessage ="Please specify the Mark")]
        public string Mark { get; set; }
        [Required(ErrorMessage ="Please specify the Model")]
        public string CarModel { get; set; }
        [Required(ErrorMessage ="Please specify Year of Production")]
        public int? Year { get; set; }
        [Required(ErrorMessage ="Please Enter Valid VIN code")]
        [StringLength(17, MinimumLength =17, ErrorMessage = "VIN code must be 17 character expression")]
        public string Vin { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
