using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Data.Interfaces;
using SurveyOnlineCore.Model.Mappers;
using SurveyOnlineCore.Model.Models;

namespace SurveyOnlineCore.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IHttpContextAccessor _context;

        public SurveysController(ISurveyRepository surveyRepository, IHttpContextAccessor context)
        {
            _surveyRepository = surveyRepository;
            _context = context;
        }

        [HttpGet("{customerId}/survey/{surveyId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<SurveyOut> GetSyrvey(Guid customerId, Guid surveyId)
        {
            try
            {
                surveyId = new Guid(surveyId.ToString().Trim());

                if (surveyId == null || surveyId.ToString() == string.Empty)
                    return BadRequest();

                var survey = _surveyRepository.GetSurveyById(customerId, surveyId);
                var surveyStat = _surveyRepository.GetSurveyStatisticById(customerId, surveyId);

                if (survey == null)
                    return NotFound();

                var syrveyOut = SurveyMapper.MapSurvey(survey);
                return syrveyOut;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{customerId}/list")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<SurveyLitsItemOut>> GetSyrveys(Guid customerId)
        {
            try
            {
                Guid customerId2 = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                if (customerId2 == null)
                    return BadRequest();

                var surveys = _surveyRepository.GetSurveysByUserId(customerId);
                if (!surveys.Any() || surveys == null)
                    return NotFound();

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
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}