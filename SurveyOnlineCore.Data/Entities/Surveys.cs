using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Surveys
    {
        public Surveys()
        {
            Questionnaires = new HashSet<Questionnaires>();
            Questions = new HashSet<Questions>();
        }

        public Guid SurveysId { get; set; }
        [Required]
        [StringLength(255)]
        public string SurveyName { get; set; }
        [Required]
        public string SurveyDescription { get; set; }
        public bool SurveyStatus { get; set; }
        [Required]
        [StringLength(50)]
        public string SurveyUrl { get; set; }
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Surveys")]
        public Customers Customer { get; set; }
        [InverseProperty("Surveys")]
        public ICollection<Questionnaires> Questionnaires { get; set; }
        [InverseProperty("Surveys")]
        public ICollection<Questions> Questions { get; set; }
    }
}
