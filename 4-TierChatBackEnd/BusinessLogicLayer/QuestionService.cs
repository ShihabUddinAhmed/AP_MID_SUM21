using BusinessEntityLayer;
using BusinessLogicLayer.MapperConfig;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class QuestionService
    {
        public static void AddQuestion(QuestionModel model)
        {
            //var data = AutoMapper.Mapper.Map<QuestionModel, Question>(model);
            Question data = new Question()
            {
                Id = model.Id,
                QuestionText=model.QuestonText,
                QuestionAnswer=model.QuestionAnswer,
                Topic=model.Topic,
                CompanyId=model.CompanyId
            };
            QuestionRepo.AddQuestion(data);
        }
        public static QuestionModel GetQuestion(int id)
        {
            var data = QuestionRepo.GetQuestion(id);
            var qt = AutoMapper.Mapper.Map<Question, QuestionModel>(data);
            return qt;
        }

        public static QuestionModel GetQuestionbyText(string qtext)
        {
            var data = QuestionRepo.GetQuestionbyText(qtext);
            //var qt = AutoMapper.Mapper.Map<Question, QuestionModel>(data);
            var qt = new QuestionModel()
            {
                Id = data.Id,
                QuestonText = data.QuestionText,
                QuestionAnswer = data.QuestionAnswer,
                Topic = data.Topic,
                CompanyId = data.CompanyId,
                CompanyName = CompanyRepo.GetCompanyDetail(data.CompanyId).CompanyName
            };
            return qt;
        }

        public static List<QuestionModel> GetQuestionbyCompany(int companyId)
        {
            var data = QuestionRepo.GetAllQuestions();
            //var qt = AutoMapper.Mapper.Map<Question, QuestionModel>(data);
            List<QuestionModel> questionModels = new List<QuestionModel>();
            foreach (var q in data)
            {
                if(q.CompanyId==companyId)
                {
                    var qm = new QuestionModel()
                    {
                        Id = q.Id,
                        QuestonText = q.QuestionText,
                        QuestionAnswer = q.QuestionAnswer,
                        Topic = q.Topic,
                        CompanyId = q.CompanyId,
                        CompanyName=CompanyRepo.GetCompanyDetail(q.CompanyId).CompanyName
                    };
                    questionModels.Add(qm);
                }
            }
            return questionModels;
        }
        public static List<QuestionModel> GetAllQuestions()
        {
            var data = QuestionRepo.GetAllQuestions();
            //var qt = AutoMapper.Mapper.Map<List<Question>, List<QuestionModel>>(data);
            List<QuestionModel> questionModels = new List<QuestionModel>();
            foreach (var qt in data)
            {
                var q = new QuestionModel()
                {
                    Id = qt.Id,
                    QuestonText = qt.QuestionText,
                    QuestionAnswer = qt.QuestionAnswer,
                    Topic = qt.Topic,
                    CompanyId = qt.CompanyId,
                    CompanyName = CompanyRepo.GetCompanyDetail(qt.CompanyId).CompanyName
                };
                questionModels.Add(q);
            }
            return questionModels;
        }

        public static List<string> GetQuestionTexts()
        {
            var data = QuestionRepo.GetQuestionTexts();
            return data;
        }
    }
}
