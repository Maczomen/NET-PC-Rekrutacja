using ContactsWebApp.Data;
using ContactsWebApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsWebApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string surname { get; set; }
        //email must contain @ and . and other symbols (no special ones)
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9]*@[a-z]+.[a-z]+)$", ErrorMessage = "Invalid email")]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        //password must contain at least 1 upper case, 1 lower case, 1 number and be 6 to 15 symbols long.
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-z]*$)(?!^[A-Z]*$)^([a-zA-Z0-9]{6,15})$"
        , ErrorMessage = "Password must contain</br>-at least 1 uppercase letter</br>-at least 1 lowercase letter</br>-at least 1 number</br>-must be 6 to 15 characters long")]
        [StringLength(9)]
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        //telephone number must be 9 numbers
        [StringLength(9)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid phone number")]
        [Required]
        [Display(Name = "Telephone number")]
        public string phoneNumber { get; set; }
        //we are only interested in date part of date of birth
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Birthday")]
        public DateTime dateOfBirth { get; set; }
        [Required]
        [Display(Name = "Category")]
        public ContactCategory category { get; set; }
        [Display(Name = "Exact category")]
        public string subCategory { get; set; }

        //this value is not mapped to database and is used to get sub cattegory for Business from forms
        [NotMapped]
        public BusinessContactCategory subCategoryBuisness { get; set; }
        public Contact()
        {
        }
    }
}
