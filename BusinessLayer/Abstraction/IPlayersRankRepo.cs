using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreVox.BL.Abstraction
{
    public interface IPlayersRankRepo
    {
        public Task<Response> GetMensRanking(enRole role, enFormat format);
        public Task<Response> GetwomensRanking(enRole role, enWomenFormat format);
    }
}
