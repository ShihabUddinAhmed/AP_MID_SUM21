using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4_TierChatBackEnd.Controllers
{
    public class QuestionController : ApiController
    {
        [Route("api/Qustion/GetAll")]
        public List<QuestionModel> GetAllQuestions()
        {
            return QuestionService.GetAllQuestions();
        }
        [Route("api/Question/{id}")]
        public QuestionModel GetQuestion(int id)
        {
            return QuestionService.GetQuestion(id);
        }
        [Route("api/Question/Add")]
        public void AddStudent(QuestionModel model)
        {
            QuestionService.AddQuestion(model);
        }
        [Route("api/Question/Texts")]
        public List<string> GetQuestionTexts()
        {
            return QuestionService.GetQuestionTexts();
        }
    }
}
