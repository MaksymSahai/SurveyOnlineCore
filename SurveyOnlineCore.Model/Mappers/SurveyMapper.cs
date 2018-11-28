using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Mappers
{
    public static class SurveyMapper
    {
        public static ICollection<QuestionOut> MapQuestion(ICollection<Questions> questions)
        {
            var questionsOutoList = new List<QuestionOut>();
            foreach (var question in questions)
            {
                var questionOut = new QuestionOut
                {
                    QuestionId = question.QuestionId,
                    QuestionName = question.QuestionName,
                    QuestionTypeId = question.QuestionTypeId,
                    SelectedAnswer = question.SelectedAnswer
                };
                questionsOutoList.Add(questionOut);
            }
            return questionsOutoList;
        }
    }
}
