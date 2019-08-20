using SurveyOnlineCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurveyOnlineCore.Data.Entities;

namespace SurveyOnlineCore.Tests.Data
{
    internal class SurveyRepositoryFake : ISurveyRepository
    {
        public IEnumerable<Surveys> GetSurveysByUserId(Guid custonmerId)
        {
            throw new NotImplementedException();
        }

        public Surveys GetSurveyById(Guid custonmerId, Guid surveyId)
        {
            throw new NotImplementedException();
        }

        public Surveys GetSurveyStatisticById(Guid custonmerId, Guid surveyId)
        {
            throw new NotImplementedException();
        }

        public bool IsUrlUnique(Guid custonmerId, string surveyUrl)
        {
            throw new NotImplementedException();
        }

        public void CreateSurvey(Surveys surveys)
        {
            throw new NotImplementedException();
        }

        public void ConductSurvey(IEnumerable<Questionnaires> questionnaires)
        {
            throw new NotImplementedException();
        }
    }
}
