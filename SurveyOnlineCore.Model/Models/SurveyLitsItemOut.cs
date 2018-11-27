using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Models
{
    public class SurveyLitsItemOut
    {
        public Guid SurveysId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }
        public bool SurveyStatus { get; set; }
        public string SurveyUrl { get; set; }
        public Guid CustomerId { get; set; }
    }
}
