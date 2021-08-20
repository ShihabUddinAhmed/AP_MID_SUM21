using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestonText { get; set; }
        public string QuestionAnswer { get; set; }
        public string Topic { get; set; }
        public int CompanyId { get; set; }
    }
}
