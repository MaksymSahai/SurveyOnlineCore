using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class SurveyLitsItemOut
    {
        [JsonProperty("SurveysId")]
        public Guid SurveysId { get; set; }

        [JsonProperty("SurveyName")]
        public string SurveyName { get; set; }

        [JsonProperty("SurveyDescription")]
        public string SurveyDescription { get; set; }

        [JsonProperty("SurveyStatus")]
        public bool SurveyStatus { get; set; }

        [JsonProperty("SurveyUrl")]
        public string SurveyUrl { get; set; }

        [JsonProperty("CustomerId")]
        public Guid CustomerId { get; set; }
    }
}
