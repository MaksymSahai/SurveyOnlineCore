using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    public class SurveyOut
    {
        public Guid SurveysId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }
        public bool SurveyStatus { get; set; }
        public string SurveyUrl { get; set; }

        public ICollection<QuestionOut> Questions { get; set; }
    }

    public class QuestionOut
    {
        public Guid QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string SelectedAnswer { get; set; }
        public Guid QuestionTypeId { get; set; }

        public ICollection<AnswerOut> AnswerVariants { get; set; }
    }

    public class AnswerOut
    {
        public string AnswerVariantName { get; set; }
    }
}
