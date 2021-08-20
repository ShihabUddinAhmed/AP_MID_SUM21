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
            var data = AutoMapper.Mapper.Map<QuestionModel, Question>(model);
            QuestionRepo.AddQuestion(data);
        }
        public static QuestionModel GetQuestion(int id)
        {
            var data = QuestionRepo.GetQuestion(id);
            var qt = AutoMapper.Mapper.Map<Question, QuestionModel>(data);
            return qt;
        }
        public static List<QuestionModel> GetAllQuestions()
        {
            var data = QuestionRepo.GetAllQuestions();
            var qt = AutoMapper.Mapper.Map<List<Question>, List<QuestionModel>>(data);
            return qt;
        }

        public static List<string> GetQuestionTexts()
        {
            var data = QuestionRepo.GetQuestionTexts();
            return data;
        }
    }
}
