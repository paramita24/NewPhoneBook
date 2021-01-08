using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneBookModel
    {
        [Required(ErrorMessage = "Entry name is required.")]
        [Display(Name = "Name")]
        public string EntryName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}