using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class ConductSurvey
    {
        [JsonProperty("SurveysId")]
        public Guid SurveysId { get; set; }

        public ICollection<ConductQuestion> Questions { get; set; }
    }

    [JsonObject]
    public class ConductQuestion
    {
        [JsonProperty("QuestionId")]
        public Guid QuestionId { get; set; }

        public ICollection<ConductAnswer> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class ConductAnswer
    {
        [JsonProperty("AnswerVariantId")]
        public Guid AnswerVariantId { get; set; }
    }
}
