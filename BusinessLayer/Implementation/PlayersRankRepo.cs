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
    public class PlayersRankRepo : IPlayersRankRepo
    {
        private string CheckAllRounder(enRole role)
        {
            if (role == enRole.all_rounder)
                return enRole.all_rounder.ToString().Replace("_", "-");
            return role.ToString();
        }
        public async Task<Response> GetMensRanking(enRole role, enFormat format)
        {
            string newrole = CheckAllRounder(role);

            Response dtoResponse = new Response();
            dtoResponse.Message = "Success..";
            dtoResponse.Status = true;
            try
            {
                List<player> players = new List<player>();
            string website = $"https://feed.cricket-rankings.com/feed/{format}/{newrole}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");

            foreach (var node in nodeElement)
            {
                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                players.Add(new player
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    Country = t[2].InnerText.Trim(),
                    Rating = t[3].InnerText.Trim()
                });
            }

            

            dtoResponse.Data = players;

        }
        catch (Exception ex)
        {

            dtoResponse.Status = false;
            dtoResponse.Message = "Exception occurr..";
            dtoResponse.ErrorMessage = ex.Message;

        }
        return dtoResponse;
        }

        public async Task<Response> GetwomensRanking(enRole role, enWomenFormat format)
        {
            string newrole = CheckAllRounder(role);

            Response dtoResponse = new Response();
            dtoResponse.Message = "Success..";
            dtoResponse.Status = true;
            try
            {
                List<player> players = new List<player>();
                string website = $"https://feed.cricket-rankings.com/feed/{format}/{newrole}/";
                var web = new HtmlWeb();

                var htmldoc = web.Load(website);
                var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");

                foreach (var node in nodeElement)
                {
                    var tds = node.InnerHtml;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(tds);
                    var t = doc.DocumentNode.SelectNodes("//td");
                    players.Add(new player
                    {
                        Rank = t[0].InnerText.Trim(),
                        Name = t[1].InnerText.Trim(),
                        Country = t[2].InnerText.Trim(),
                        Rating = t[3].InnerText.Trim()
                    });
                }



                dtoResponse.Data = players;

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
