using Domain_Layer.Models;
using HtmlAgilityPack;
using ScoreVox.BL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreVox.BL.Implementation
{
    public class TeamRankRepo: ITeamRankRepo
    {
        //private readonly ApplicationDBContext _context;
        //public TeamRank(ApplicationDBContext context)
        //{
        //    _context = context;
        //}
        public async Task<Response> GetAllFormateRanking(enTeamRankingFormat format, enGender gender)
    {
        Response dtoResponse = new Response();
        dtoResponse.Message = "Success..";
        dtoResponse.Status = true;
        try
        {
            List<TeamStatus> teamsStatus = new List<TeamStatus>();
            dtoResponse.Data = new List<TeamStatus>();
            int iter = 0;

            string website = $"https://www.icc-cricket.com/rankings/{gender.ToString()}/team-rankings/{format.ToString()}";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table/tbody" +
                "//tr");

            foreach (var node in nodeElement)
            {

                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");

                teamsStatus.Add(new TeamStatus
                {
                    Position = t[0].InnerText.Trim(),
                    flag = t[1].InnerHtml.Trim().Replace("\n", "").Remove(50).Trim().Remove(20, 11),
                    Name = t[1].InnerText.Trim().Replace("\n", "").Remove(15).Trim(),
                    Matches = t[2].InnerText.Trim(),
                    Points = t[3].InnerText.Trim(),
                    Rating = t[4].InnerText.Trim()
                });

                if (iter > 8)
                    break;
                iter++;
            }

            dtoResponse.Data = teamsStatus;


        }
        catch (Exception ex)
        {

            dtoResponse.Status = false;
            dtoResponse.Message = "Exception occurr..";
            dtoResponse.ErrorMessage = ex.Message;

        }
        return dtoResponse;
    }
    








    }
}
