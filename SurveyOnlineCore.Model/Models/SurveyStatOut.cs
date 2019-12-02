using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class SurveyStatOut
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

        [JsonProperty("questionnairesCount")]
        public int QuestionnairesCount { get; set; }

        public ICollection<QuestionStatOut> Questions { get; set; }
    }

    [JsonObject]
    public class QuestionStatOut
    {
        [JsonProperty("questionId")]
        public Guid QuestionId { get; set; }

        [JsonProperty("questionName")]
        public string QuestionName { get; set; }

        [JsonProperty("questionTypeId")]
        public Guid QuestionTypeId { get; set; }

        public ICollection<AnswerStatOut> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class AnswerStatOut
    {
        [JsonProperty("answerVariantId")]
        public Guid AnswerVariantId { get; set; }

        [JsonProperty("answerVariantName")]
        public string AnswerVariantName { get; set; }

        [JsonProperty("questionnairesCount")]
        public int QuestionnairesCount { get; set; }
    }
}
