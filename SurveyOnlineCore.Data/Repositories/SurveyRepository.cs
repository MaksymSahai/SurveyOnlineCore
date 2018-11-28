using Microsoft.EntityFrameworkCore;
using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyOnlineCore.Data.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyOnlineContext _surveyOnlineContext;

        public SurveyRepository(SurveyOnlineContext surveyOnlineContext)
        {
            _surveyOnlineContext = surveyOnlineContext;
        }
        public  Surveys GetSurveyById(Guid custonmerId, Guid surveyId)
        {
            return _surveyOnlineContext.Surveys.Where(s => s.SurveysId == surveyId).Include(s => s.Questions).Include(s => s.Questions.Select(q => q.AnswerVariants)).FirstOrDefault();
        }

        public async Task<Surveys> GetSurveysByUrl(Guid customerId, string surveyUrl)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Surveys> GetSurveysByUserId(Guid customerId)
        {
            return _surveyOnlineContext.Customers.Where(c => c.CustomerId == customerId)
                .Include(Customers => Customers.Surveys).FirstOrDefault().Surveys.ToList();
        }
    }
}
