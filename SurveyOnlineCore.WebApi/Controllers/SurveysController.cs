using Microsoft.AspNetCore.Mvc;
using SurveyOnlineCore.Data.Interfaces;
using SurveyOnlineCore.Model.Mappers;
using SurveyOnlineCore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SurveyOnlineCore.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveysController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        [HttpGet("survey/{surveyId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<SurveyOut> GetSyrvey(Guid surveyId)
        {
            try
            {
                var customerId = GetCurrentCustomerId();
                surveyId = new Guid(surveyId.ToString().Trim());

                if (surveyId.ToString() == string.Empty)
                    return BadRequest();

                var survey = _surveyRepository.GetSurveyById(customerId, surveyId);

                if (survey == null)
                    return NotFound();

                var syrveyOut = SurveyMapper.MapSurvey(survey);
                return syrveyOut;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("survey/{surveyId}/stat")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<SurveyStatOut> GetSyrveyStatistic( Guid surveyId)
        {
            try
            {
                var customerId = GetCurrentCustomerId();
                surveyId = new Guid(surveyId.ToString().Trim());

                if (surveyId.ToString() == string.Empty)
                    return BadRequest();

                var survey = _surveyRepository.GetSurveyStatisticById(customerId, surveyId);

                if (survey == null)
                    return NotFound();

                var syrveyOut = SurveyMapper.MapSurveyStat(survey);
                return syrveyOut;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("list")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<SurveyLitsItemOut>> GetSyrveys()
        {
            try
            {
                var customerId = GetCurrentCustomerId();
                var surveys = _surveyRepository.GetSurveysByUserId(customerId).ToList();

                if (surveys == null || !surveys.Any())
                    return null;

                var syrveysOut = new List<SurveyLitsItemOut>();
                foreach (var syrvey in surveys)
                {
                    var syrveyOut = new SurveyLitsItemOut
                    {
                        CustomerId = syrvey.CustomerId,
                        SurveyDescription = syrvey.SurveyDescription,
                        SurveyName = syrvey.SurveyName,
                        SurveysId = syrvey.SurveysId,
                        SurveyStatus = syrvey.SurveyStatus,
                        SurveyUrl = syrvey.SurveyUrl
                    };
                    syrveysOut.Add(syrveyOut);
                }
                return syrveysOut;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult CreateSurvey([FromBody]CreateSurvey createSurvey)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest();

            try
            {
                var survey = SurveyMapper.MapSurvey(createSurvey);
                _surveyRepository.CreateSurvey(survey);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult ConductSurvey([FromBody]ConductSurvey conductSurvey)
        {
            try
            {
                var questionaries = SurveyMapper.MapQuestionnaires(conductSurvey);
                _surveyRepository.ConductSurvey(questionaries);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private Guid GetCurrentCustomerId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}