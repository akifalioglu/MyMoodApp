using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MoodApp.Models
{
    public class RoleAttributesModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Üye Adı")]
        public string txtUsername { get; set; }
        public string roleName { get; set; }
        
        [Required]
        public int roleId { get; set; }
        public List<SelectListItem> roles { set; get; }
        
        public string Result { get; set; }
        public bool resultCode {get; set;}

        public int roleValue { get; set; }


    }
}