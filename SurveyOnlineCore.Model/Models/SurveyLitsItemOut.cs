using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class SurveyLitsItemOut
    {
        [JsonProperty("surveysId")]
        public Guid SurveysId { get; set; }

        [JsonProperty("surveyName")]
        public string SurveyName { get; set; }

        [JsonProperty("surveyDescription")]
        public string SurveyDescription { get; set; }

        [JsonProperty("surveyStatus")]
        public bool SurveyStatus { get; set; }

        [JsonProperty("surveyUrl")]
        public string SurveyUrl { get; set; }
    }
}
