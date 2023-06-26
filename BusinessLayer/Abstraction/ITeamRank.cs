using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstraction
{
    public interface ITeamRank
    {
        public Task<Response> GetAllFormateRanking(enTeamRankingFormat format, enGender gender);

    }
}
