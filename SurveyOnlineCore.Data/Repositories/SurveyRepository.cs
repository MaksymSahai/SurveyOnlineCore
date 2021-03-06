﻿using Microsoft.EntityFrameworkCore;
using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyOnlineCore.Data.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyOnlineContext _surveyOnlineContext;

        public SurveyRepository(SurveyOnlineContext surveyOnlineContext)
        {
            _surveyOnlineContext = surveyOnlineContext;
        }

        /// <summary>
        /// Return customer survey by id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="surveyId">Survey Id </param>
        /// <returns>Survey by id</returns>
        public  Surveys GetSurveyById(Guid customerId, Guid surveyId)
        {
            return _surveyOnlineContext.Surveys.Where(s => s.SurveysId == surveyId)
                .Include(s => s.Questions).ThenInclude(s => s.AnswerVariants).FirstOrDefault();
        }

        /// <summary>
        /// Returns list of customer survey
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <returns>List of survey</returns>
        public IEnumerable<Surveys> GetSurveysByUserId(Guid customerId)
        {
            return _surveyOnlineContext.Customers.Where(c => c.CustomerId == customerId)
                .Include(customers => customers.Surveys).FirstOrDefault().Surveys.ToList();
        }

        /// <summary>
        /// Returns true or false if exists survey with url in user surveys
        /// </summary>
        /// <param name="custonmerId">Customer id</param>
        /// <param name="surveyUrl">Survey Url</param>
        /// <returns>Returns true or false if exists survey with url in user surveys</returns>
        public bool IsUrlUnique(Guid custonmerId, string surveyUrl)
        {
            var survey = _surveyOnlineContext.Customers.Where(c => c.CustomerId == custonmerId).Include(c => c.Surveys)
                .Where(s => s.Surveys.Any(su => su.SurveyUrl == surveyUrl));

            if (survey != null || survey.Any())
                return false;
            return true;
        }

        /// <summary>
        /// Create a new survey
        /// </summary>
        /// <param name="surveys">Survey to create</param>
        public void CreateSurvey(Surveys surveys)
        {
            try
            {
                using (var transaction = _surveyOnlineContext.Database.BeginTransaction())
                {
                    try
                    {
                        _surveyOnlineContext.Add(surveys);
                        foreach (var question in surveys.Questions)
                        {
                            _surveyOnlineContext.Add(question);
                            foreach (var answer in question.AnswerVariants)
                            {
                                _surveyOnlineContext.Add(answer);
                            }
                        }
                        _surveyOnlineContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Return customer survey with statistic by id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="surveyId">Survey Id </param>
        /// <returns>Survey by id</returns>
        public Surveys GetSurveyStatisticById(Guid custonmerId, Guid surveyId)
        {
            return _surveyOnlineContext.Surveys.Where(s => s.SurveysId == surveyId)
                .Include(s => s.Questions)
                .ThenInclude(s => s.AnswerVariants)
                .ThenInclude(s => s.Questionnaires)
                .FirstOrDefault();
        }

        /// <summary>
        /// Create questionnaires of survey
        /// </summary>
        /// <param name="questionnaires">Survey questionnaires</param>
        public void ConductSurvey(IEnumerable<Questionnaires> questionnaires)
        {
            try
            {
                using (var transaction = _surveyOnlineContext.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var questionnairy in questionnaires)
                        {
                            _surveyOnlineContext.Add(questionnairy);
                        }
                        _surveyOnlineContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
