using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Questions
    {
        public Questions()
        {
            AnswerVariants = new HashSet<AnswerVariants>();
            Questionnaires = new HashSet<Questionnaires>();
        }

        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        [StringLength(255)]
        public string QuestionName { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid SurveysId { get; set; }

        [ForeignKey("QuestionTypeId")]
        [InverseProperty("Questions")]
        public QuestionTypes QuestionType { get; set; }
        [ForeignKey("SurveysId")]
        [InverseProperty("Questions")]
        public Surveys Surveys { get; set; }
        [InverseProperty("Question")]
        public ICollection<AnswerVariants> AnswerVariants { get; set; }
        [InverseProperty("Question")]
        public ICollection<Questionnaires> Questionnaires { get; set; }
    }
}
