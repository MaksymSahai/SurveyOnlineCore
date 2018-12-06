using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Mappers
{
    public static class SurveyMapper
    {
        public static SurveyOut MapSurvey(Surveys surveys)
        {
            var surveyOut = new SurveyOut
            {
                SurveyName = surveys.SurveyName,
                SurveyDescription = surveys.SurveyDescription,
                SurveyStatus = surveys.SurveyStatus,
                SurveysId = surveys.SurveysId,
                SurveyUrl = surveys.SurveyUrl,
                Questions = MapQuestion(surveys.Questions)
            };
            return surveyOut;
        }

        public static ICollection<QuestionOut> MapQuestion(ICollection<Questions> questions)
        {
            var questionsOutList = new List<QuestionOut>();
            foreach (var question in questions)
            {
                var questionOut = new QuestionOut
                {
                    QuestionId = question.QuestionId,
                    QuestionName = question.QuestionName,
                    QuestionTypeId = question.QuestionTypeId,
                    AnswerVariants = MapAnswerVariants(question.AnswerVariants)
                };
                questionsOutList.Add(questionOut);
            }
            return questionsOutList;
        }

        private static ICollection<AnswerOut> MapAnswerVariants(ICollection<AnswerVariants> answerVariants)
        {
            var answerVariantsOutList = new List<AnswerOut>();
            foreach (var answerVariant in answerVariants)
            {
                var answerVariantsOut = new AnswerOut
                {
                    AnswerVariantId = answerVariant.AnswerVariantId,
                    AnswerVariantName = answerVariant.AnswerVariantName
                };
                answerVariantsOutList.Add(answerVariantsOut);
            }
            return answerVariantsOutList;
        }

        public static Surveys MapSurvey(CreateSurvey createSurvey)
        {
            var surveyGuid = Guid.NewGuid();
            Surveys survey = new Surveys
            {
                SurveysId = surveyGuid,
                SurveyName = createSurvey.SurveyName,
                SurveyDescription = createSurvey.SurveyDescription,
                SurveyStatus = true,
                SurveyUrl = createSurvey.SurveyUrl,
                CustomerId = new Guid(createSurvey.CustomerId),
                Questions = MapQuestion(createSurvey.Questions, surveyGuid)

            };

            return survey;
        }

        private static ICollection<Questions> MapQuestion(ICollection<QuestionOut> questionsToCreate, Guid surveyGuid)
        {
            try
            {
                var questions = new List<Questions>();
                foreach (var questionToCreate in questionsToCreate)
                {
                    var questionGuid = Guid.NewGuid();
                    var question = new Questions
                    {
                        QuestionId = questionGuid,
                        QuestionName = questionToCreate.QuestionName,
                        QuestionTypeId = questionToCreate.QuestionTypeId,
                        SurveysId = surveyGuid,
                        AnswerVariants = MapAnswerVariants(questionToCreate.AnswerVariants, questionGuid)
                    };

                    questions.Add(question);
                }
                return questions;
            }
            catch
            {
                throw;
            }
        }

        private static ICollection<AnswerVariants> MapAnswerVariants(ICollection<AnswerOut> answerVariantsToCreate, Guid questionId)
        {
            try
            {
                var answers = new List<AnswerVariants>();
                foreach (var answerToCreate in answerVariantsToCreate)
                {
                    var answerGuid = Guid.NewGuid();
                    var answer = new AnswerVariants
                    {
                        AnswerVariantId = answerGuid,
                        AnswerVariantName = answerToCreate.AnswerVariantName,
                        QuestionId = questionId
                    };

                    answers.Add(answer);
                }
                return answers;
            }
            catch
            {
                throw;
            }
        }
    }
}
