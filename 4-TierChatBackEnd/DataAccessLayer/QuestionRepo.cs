using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class QuestionRepo
    {
        static ChatAppEntities context;
        static QuestionRepo()
        {
            context = new ChatAppEntities();
        }
        public static void AddQuestion(Question model)
        {
            context.Questions.Add(model);
            context.SaveChanges();
        }
        public static List<Question> GetAllQuestions()
        {
            var data = context.Questions.ToList();
            return data;
        }
        public static Question GetQuestion(int id)
        {
            var data = context.Questions.FirstOrDefault(e => e.Id == id);
            return data;
        }

        public static Question GetQuestionbyText(string qtext)
        {
            var data = context.Questions.FirstOrDefault(e => e.QuestionText == qtext);
            return data;
        }

        /* public static List<Question> GetQuestionbyCompany(int companyId)
         {
             var data = context.Questions.ToList();
             return data;
         }*/

        public static List<string> GetQuestionTexts()
        {
            var data = context.Questions.Select(e => e.QuestionText).ToList();
            return data;
        }
    }
}
