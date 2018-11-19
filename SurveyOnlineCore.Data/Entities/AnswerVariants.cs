using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class AnswerVariants
    {
        public Guid AnswerVariantId { get; set; }
        public string AnswerVariantName { get; set; }
        public Guid QuestionId { get; set; }

        public Questions Question { get; set; }
    }
}
