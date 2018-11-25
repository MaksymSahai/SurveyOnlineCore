using SurveyOnlineCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    public class CustomerCreate
    {
        [Required]
        [MaxLength(250)]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(250)]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 6, ErrorMessage = "You mast specify password more then 6 characters")]
        public string CustomerPassword { get; set; }
        [Required]
        public string CustomerAbilities { get; set; }
    }
}
