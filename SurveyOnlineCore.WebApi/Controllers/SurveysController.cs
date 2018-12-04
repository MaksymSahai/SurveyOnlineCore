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
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveysController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        [HttpGet("{customerId}/survey/{surveyId}")]
        public SurveyOut GetSyrvey(Guid customerId, Guid surveyId)
        {
            var survey = _surveyRepository.GetSurveyById(customerId, surveyId);
            var syrveyOut = SurveyMapper.MapSurvey(survey);
            return syrveyOut;
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
                var identity = User.Identity as ClaimsIdentity;
                var email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (identity == null)
                    return BadRequest();

                var cId = identity.Claims;



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