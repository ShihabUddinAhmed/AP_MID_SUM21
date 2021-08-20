using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperConfig
{
    public class AutoMapperSettings:Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<CompanyModel, Company>().ForMember(e => e.Questions, c => c.Ignore());
            CreateMap<Company, CompanyDetail>();
            CreateMap<QuestionModel, Question>().ForMember(e => e.Company, qt => qt.Ignore());
        }
    }
}
