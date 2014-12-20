using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public enum ApplicationStatus : byte
    {
        NotViewed,
        Viewed,
        Accepted
    }

    public enum CompanyStatus : byte
    {
        Active,
        Inactive
    }

    public enum MessageStatus : byte
    {

    }

    public enum CartStatus : byte
    {

    }

    public enum JobStatus : byte
    {
        Active,
        Inactive
    }
}
