using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CompanyRepo
    {
        static ChatAppEntities context;

        static CompanyRepo()
        {
            context = new ChatAppEntities();
        }

        public static List<string> GetCompanyNames()
        {
            var data = context.Companies.Select(e => e.CompanyName).ToList();
            return data;
        }
        public static List<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }
        public static void AddCompany(Company c)
        {
            context.Companies.Add(c);
            context.SaveChanges();
        }

        public static Company GetCompanyDetail(int id)
        {
            return context.Companies.FirstOrDefault(e => e.Id == id);
        }
    }
}
