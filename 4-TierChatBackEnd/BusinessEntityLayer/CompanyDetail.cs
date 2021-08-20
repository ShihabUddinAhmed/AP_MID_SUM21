using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class CompanyDetail
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
