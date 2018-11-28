using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Questions
    {
        public Questions()
        {
            AnswerVariants = new HashSet<AnswerVariants>();
        }

        public Guid QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string SelectedAnswer { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid SurveysId { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public Surveys Surveys { get; set; }
        public ICollection<AnswerVariants> AnswerVariants { get; set; }
    }
}
