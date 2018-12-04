using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class SurveyOut
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

        public ICollection<QuestionOut> Questions { get; set; }
    }

    [JsonObject]
    public class QuestionOut
    {
        [JsonProperty("QuestionId")]
        public Guid QuestionId { get; set; }

        [JsonProperty("QuestionName")]
        public string QuestionName { get; set; }

        [JsonProperty("SelectedAnswer")]
        public string SelectedAnswer { get; set; }

        [JsonProperty("QuestionTypeId")]
        public Guid QuestionTypeId { get; set; }

        public ICollection<AnswerOut> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class AnswerOut
    {
        [JsonProperty("AnswerVariantId")]
        public Guid AnswerVariantId { get; set; }

        [JsonProperty("AnswerVariantName")]
        public string AnswerVariantName { get; set; }
    }
}
