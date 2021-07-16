using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MoodApp.Models
{
    public class UsersModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(12)]
        [Display(Name = "Üye Adı")]
        public string txtUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string txtPassword { get; set; }
        public string roleName { get; set; }
        
        [Required]
        [Display(Name = "Rol")]
        public int roleId { get; set; }
        public List<SelectListItem> roles { set; get; }
        
        public string Result { get; set; }
        public bool resultCode {get; set;}

        public int roleValue { get; set; }


    }
}