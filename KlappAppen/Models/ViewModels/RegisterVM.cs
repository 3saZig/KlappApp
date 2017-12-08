using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlappAppen.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Användarnamn felaktigt/saknas")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lösenord måste anges")]
        [DataType (DataType.Password)]
        public string Password { get; set; }
    }
}
