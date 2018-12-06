using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class AnswerVariants
    {
        public AnswerVariants()
        {
            Questionnaires = new HashSet<Questionnaires>();
        }

        [Key]
        public Guid AnswerVariantId { get; set; }
        [Required]
        [StringLength(255)]
        public string AnswerVariantName { get; set; }
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        [InverseProperty("AnswerVariants")]
        public Questions Question { get; set; }
        [InverseProperty("AnswerVariant")]
        public ICollection<Questionnaires> Questionnaires { get; set; }
    }
}
