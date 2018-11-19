using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class QuestionTypes
    {
        public QuestionTypes()
        {
            Questions = new HashSet<Questions>();
        }

        public Guid QuestionTypeId { get; set; }
        public string QuestionTypeName { get; set; }
        public string QuestionTypeDescription { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
