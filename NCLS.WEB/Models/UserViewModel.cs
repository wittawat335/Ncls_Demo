using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter UserLogin")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}