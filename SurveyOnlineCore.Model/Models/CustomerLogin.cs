using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class CustomerLogin
    {
        [Required]
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [Required]
        [JsonProperty("customerPassword")]
        public string CustomerPassword { get; set; }
    }
}
