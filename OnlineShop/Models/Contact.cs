using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Contact
    {

        public int ContactID;

        [Display(Name = "Imię")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Tylko literki")]
        [Required(ErrorMessage = "Imię jest obowiązkowe")]
        public string ContactName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string ContactEmail { get; set; }

        [Display(Name = "Wiadomość")]
        [Required]
        public string ContactMessage { get; set; }

    }
}