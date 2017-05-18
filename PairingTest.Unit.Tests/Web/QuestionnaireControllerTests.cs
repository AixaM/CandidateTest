using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().AsyncState;

            //Assert
            Assert.IsNotNull(result);            
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        } 

    }
}