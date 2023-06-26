using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Enums
    {
    }
    public enum enFormat
    {
        t20 = 1,
        odi = 2,
        test = 3
    }

    public enum enTeamRankingFormat
    {
        t20i = 1,
        odi = 2,
        test = 3
    }

    public enum enWomenFormat
    {
        woment20 = 1,
        womenodi = 2,
    }
    public enum enGender
    {
        mens = 1,
        womens = 2,
    }
    public enum enRole
    {
        batting = 1,
        bowling = 2,
        all_rounder = 3
    }

}
