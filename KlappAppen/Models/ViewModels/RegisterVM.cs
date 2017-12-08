using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Användarnamn felaktigt/saknas")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lösenord måste anges")]
        [Display(Name = "Lösenord")]
        [DataType (DataType.Password)]
        public string Password { get; set; }
    }
}
