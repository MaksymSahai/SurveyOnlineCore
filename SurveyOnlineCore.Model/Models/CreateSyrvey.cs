using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    [JsonObject]
    public class CreateSurvey
    {
        [Required]
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("surveyName")]
        public string SurveyName { get; set; }

        [Required]
        [MaxLength(500)]
        [JsonProperty("surveyDescription")]
        public string SurveyDescription { get; set; }

        [JsonProperty("surveyStatus")]
        public bool SurveyStatus { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("surveyUrl")]
        public string SurveyUrl { get; set; }

        [JsonProperty("questions")]
        public IList<QuestionOut> Questions { get; set; }
    }

    [JsonObject]
    public class CreateQuestion
    {
        [Required]
        [MaxLength(250)]
        [JsonProperty("questionName")]
        public string QuestionName { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("selectedAnswer")]
        public string SelectedAnswer { get; set; }

        [JsonProperty("questionTypeId")]
        public Guid QuestionTypeId { get; set; }

        [JsonProperty("answerVariants")]
        public IList<AnswerOut> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class CreateAnswer
    {
        [Required]
        [MaxLength(250)]
        [JsonProperty("answerVariantName")]
        public string AnswerVariantName { get; set; }
    }
}
