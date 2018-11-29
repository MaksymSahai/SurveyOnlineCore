using SurveyOnlineCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyOnlineCore.Data.Interfaces
{
    public interface ISurveyRepository
    {
        IEnumerable<Surveys> GetSurveysByUserId(Guid custonmerId);
        Surveys GetSurveyById(Guid custonmerId, Guid surveyId);
        bool IsUrlUnique(Guid custonmerId, string surveyUrl);
        void CreateSurvey(Surveys surveys);
    }
}
