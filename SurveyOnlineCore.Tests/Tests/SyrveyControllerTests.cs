using System;
using System.Collections.Generic;
using System.Text;
using SurveyOnlineCore.Data.Interfaces;
using SurveyOnlineCore.Tests.Data;
using SurveyOnlineCore.WebApi.Controllers;
using Xunit;

namespace SurveyOnlineCore.Tests.Tests
{
    public class SyrveyControllerTests
    {
        private readonly ISurveyRepository _repository;
        private readonly SurveysController _controller;
        public SyrveyControllerTests()
        {
            _repository = new SurveyRepositoryFake();
            _controller = new SurveysController(_repository);
        }

        [Fact]
        public void Tests()
        {
            _controller.GetSyrveys(new Guid());
        }
    }
}
