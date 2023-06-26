using App_layer.models;
using Azure;
using Business_Layer.Abstraction;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Response = Domain_Layer.Models.Response;

namespace App_layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {

        private readonly ITeamRank _iteamRanks;
        public MainController(ITeamRank iteamRanks)
        {
            _iteamRanks = iteamRanks;              
        }

        [HttpGet("Team/Rankings")]
        public async Task<IActionResult> TeamsRanking(enTeamRankingFormat format, enGender gender)
        {
            Response dtoResponse = new Response();
            try
            {
                dtoResponse = await _iteamRanks.GetAllFormateRanking(format, gender);
                
            }
            catch (Exception ex)
            {
                dtoResponse.Status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage= ex.Message;
            }

            return Ok(dtoResponse);
        }





    }
}