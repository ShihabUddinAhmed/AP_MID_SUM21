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
            var data = AutoMapper.Mapper.Map<List<Company>, List<CompanyModel>>(companies);
            return data;
        }
        public static void AddCompany(CompanyModel company)
        {
            var c = AutoMapper.Mapper.Map<CompanyModel, Company>(company);
            CompanyRepo.AddCompany(c);
        }

        public static CompanyDetail GetCompanyDetail(int id)
        {
            var c = CompanyRepo.GetCompanyDetail(id);
            var compdetail = AutoMapper.Mapper.Map<Company, CompanyDetail>(c);
            return compdetail;
        }

        public static List<CompanyDetail> GetCompanyWithDetails()
        {
            var data = CompanyRepo.GetCompanies();
            var cDetails = AutoMapper.Mapper.Map<List<Company>, List<CompanyDetail>>(data);
            return cDetails;

        }
    }
}
