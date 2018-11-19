using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Surveys
    {
        public Surveys()
        {
            Questions = new HashSet<Questions>();
        }

        public Guid SurveysId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }
        public bool SurveyStatus { get; set; }
        public string SurveyUrl { get; set; }
        public Guid CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
