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
    public class CompanyController : ApiController
    {
        [Route("api/Company/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return CompanyService.GetCompanyNames();
        }
        [Route("api/Company/GetAll")]
        [HttpGet]
        public List<CompanyModel> GetAllCompanies()
        {
            return CompanyService.GetCompanies();
        }
        [Route("api/Company/Add")]
        [HttpPost]
        public void Add(CompanyModel company)
        {
            CompanyService.AddCompany(company);
        }
        [Route("api/Company/All/Details")]
        [HttpGet]
        public List<CompanyDetail> GetCompanyWithDetails()
        {
            return CompanyService.GetCompanyWithDetails();
        }
        [Route("api/Company/{id}/Details")]
        [HttpGet]
        public CompanyDetail GetCompanyDetail(int id)
        {
            return CompanyService.GetCompanyDetail(id);
        }
    }
}
