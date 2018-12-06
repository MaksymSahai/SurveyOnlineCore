using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Questionnaires
    {
        public Guid QuestionnairesId { get; set; }
        public Guid SurveysId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerVariantId { get; set; }

        [ForeignKey("AnswerVariantId")]
        [InverseProperty("Questionnaires")]
        public AnswerVariants AnswerVariant { get; set; }
        [ForeignKey("QuestionId")]
        [InverseProperty("Questionnaires")]
        public Questions Question { get; set; }
        [ForeignKey("SurveysId")]
        [InverseProperty("Questionnaires")]
        public Surveys Surveys { get; set; }
    }
}
