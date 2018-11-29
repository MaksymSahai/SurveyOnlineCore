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
        [JsonProperty("CustomerId")]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("SurveyName")]
        public string SurveyName { get; set; }

        [Required]
        [MaxLength(500)]
        [JsonProperty("SurveyDescription")]
        public string SurveyDescription { get; set; }

        [JsonProperty("SurveyStatus")]
        public bool SurveyStatus { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("SurveyUrl")]
        public string SurveyUrl { get; set; }

        [JsonProperty("Questions")]
        public IList<QuestionOut> Questions { get; set; }
    }

    [JsonObject]
    public class CreateQuestion
    {
        [Required]
        [MaxLength(250)]
        [JsonProperty("QuestionName")]
        public string QuestionName { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("SelectedAnswer")]
        public string SelectedAnswer { get; set; }

        [JsonProperty("QuestionTypeId")]
        public Guid QuestionTypeId { get; set; }

        [JsonProperty("AnswerVariants")]
        public IList<AnswerOut> AnswerVariants { get; set; }
    }

    [JsonObject]
    public class CreateAnswer
    {
        [Required]
        [MaxLength(250)]
        [JsonProperty("AnswerVariantName")]
        public string AnswerVariantName { get; set; }
    }
}
