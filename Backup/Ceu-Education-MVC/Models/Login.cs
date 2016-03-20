using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ceu_Education_MVC.Models
{
    public class Login
    {
        [Required]
        [StringLength(100,ErrorMessage="Please Enter Username")]
        public string Username { get; set; }

        [Required, StringLength(100, ErrorMessage = "Please Enter Username")]
        public string Password { get; set; }

        [Required]
        public string Captcha { get; set; }
    }
}