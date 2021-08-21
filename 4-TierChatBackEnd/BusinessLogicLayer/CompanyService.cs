using BusinessLogicLayer.MapperConfig;
using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CompanyService
    {
        public static List<string> GetCompanyNames()
        {
            return CompanyRepo.GetCompanyNames();
        }
        public static List<CompanyModel> GetCompanies()
        {
            var companies = CompanyRepo.GetCompanies();
            //var data = AutoMapper.Mapper.Map<List<Company>, List<CompanyModel>>(companies);
            List<CompanyModel> data = new List<CompanyModel>();
            foreach (var c in companies)
            {
                var companyModel = new CompanyModel()
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName
                };
                data.Add(companyModel);
            }
            return data;
        }
        public static void AddCompany(CompanyModel company)
        {
            //var c = AutoMapper.Mapper.Map<CompanyModel, Company>(company);
            Company data = new Company()
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
            CompanyRepo.AddCompany(data);
        }

        public static CompanyDetail GetCompanyDetail(int id)
        {
            var c = CompanyRepo.GetCompanyDetail(id);
            //var compdetail = AutoMapper.Mapper.Map<Company, CompanyDetail>(c);
            var companyDetail = new CompanyDetail()
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Questions = QuestionService.GetQuestionbyCompany(c.Id)
            };
            return companyDetail;
        }

        public static List<CompanyDetail> GetCompanyWithDetails()
        {
            var data = CompanyRepo.GetCompanies();
            //var cDetails = AutoMapper.Mapper.Map<List<Company>, List<CompanyDetail>>(data);
            List<CompanyDetail> companyDetails = new List<CompanyDetail>();
            foreach (var comp in data)
            {
                var companyDetail = new CompanyDetail()
                {
                    Id = comp.Id,
                    CompanyName = comp.CompanyName,
                    Questions = QuestionService.GetQuestionbyCompany(comp.Id)
                };
                companyDetails.Add(companyDetail);
            }
            return companyDetails;

        }
    }
}
