using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data
{
    public enum Gender
    {
        NotSet,
        Male,
        Female,
        Other
    }

    public enum OrderStatus
    {
        Pending,
        Processed
    }

    public enum OrderType
    {
        Online,
        Physical
    }
}
