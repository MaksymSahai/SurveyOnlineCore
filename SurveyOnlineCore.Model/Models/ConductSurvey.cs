using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class ConductSurvey
    {
        [JsonProperty("surveysId")]
        public Guid SurveysId { get; set; }

        public ICollection<ConductQuestion> Questions { get; set; }
    }

    [JsonObject]
    public class ConductQuestion
    {
        [JsonProperty("questionId")]
        public Guid QuestionId { get; set; }

        public ICollection<ConductAnswer> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class ConductAnswer
    {
        [JsonProperty("answerVariantId")]
        public Guid AnswerVariantId { get; set; }
    }
}
