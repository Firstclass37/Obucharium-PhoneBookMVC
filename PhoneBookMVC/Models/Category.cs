using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a name pls")]
        [MinLength(3,ErrorMessage = "Lenght must be more than 3")]
        public string Name { get; set; }
    }
}