using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    public class CustomerLogin
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPassword { get; set; }
    }
}
