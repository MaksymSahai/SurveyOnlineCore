using SurveyOnlineCore.Data.Entities;
using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Interfaces
{
    public interface ISurveyRepository
    {
        IEnumerable<Surveys> GetSurveysByUserId(Guid custonmerId);
        Surveys GetSurveyById(Guid custonmerId, Guid surveyId);
        Surveys GetSurveyStatisticById(Guid custonmerId, Guid surveyId);
        bool IsUrlUnique(Guid custonmerId, string surveyUrl);
        void CreateSurvey(Surveys surveys);
        void ConductSurvey(IEnumerable<Questionnaires> questionnaires);
    }
}
