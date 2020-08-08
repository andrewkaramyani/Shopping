using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shooping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Friends.Models.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        public string FullName { get; set; }

        [DisplayName("Sealer Or Customer")]
        public PersonType PersonType { get; set; }

        [Required]
        [EmailAddress]
        //to use clint side 
       // [Remote("ISEmailInUse","account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Don't Match Passowrd")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
