using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
   public interface ICompanyAdapter
    {
       List<Company> GetCompanies();
       CompanyVM GetCompany(int id, string userID);
       Company PostNewCompany(CompanyVM newCompany);
       Company PatchCompany(int id, string userID, CompanyVM newCompany);
       Company DeleteCompany(int id);
       bool PutNewCompanyUser(CompanyVM existingCompany);
    }
}
