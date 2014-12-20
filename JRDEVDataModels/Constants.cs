using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public static class UserRoles
    {
        public const string SITEADMIN = "SiteAdmin";
        public const string COMPANYADMIN = "CompanyAdmin";
        public const string COMPANYUSER = "CompanyUser";
        public const string TALENTUSER = "TalentUser";
        
        //combos
        public const string COMPANYADMIN_SITEADMIN = "CompanyAdmin, SiteAdmin";
        public const string TALENTUSER_COMPANYADMIN_SITEADMIN = "TalentUser, CompanyAdmin, SiteAdmin";
        public const string TALENTUSER_SITEADMIN = "TalentUser, SiteAdmin";
        public const string COMPANYADMIN_COMPANYUSER_SITEADMIN = "CompanyAdmin, CompanyUser, SiteAdmin";
        public const string TALENTUSER_COMPANYADMIN_COMPANYUSER_SITEADMIN = "TalentUser, CompanyAdmin, CompanyUser, SiteAdmin";
    }
}
