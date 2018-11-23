using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(12,MinimumLength =6,ErrorMessage ="Password must be from 6 to 12 digit")]
        public string Password { get; set; }
    }
}
