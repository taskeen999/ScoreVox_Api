using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreVox.BL.Abstraction
{
    public interface ITeamRankRepo
    {
        public Task<Response> GetAllFormateRanking(enTeamRankingFormat format, enGender gender);
       
    }
}
