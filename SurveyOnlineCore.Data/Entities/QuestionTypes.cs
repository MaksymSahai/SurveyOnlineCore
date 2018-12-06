using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class QuestionTypes
    {
        public QuestionTypes()
        {
            Questions = new HashSet<Questions>();
        }

        [Key]
        public Guid QuestionTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string QuestionTypeName { get; set; }
        [Required]
        public string QuestionTypeDescription { get; set; }

        [InverseProperty("QuestionType")]
        public ICollection<Questions> Questions { get; set; }
    }
}
