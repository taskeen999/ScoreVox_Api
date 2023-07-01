using App_layer.models;
using Azure;
using ScoreVox.BL.Abstraction;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Response = Domain_Layer.Models.Response;

namespace App_layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {

        private readonly ITeamRankRepo _iteamRanks;
        private readonly IPlayersRankRepo _playersRankRepo;
        public MainController(ITeamRankRepo iteamRanks, IPlayersRankRepo playersRankRepo)
        {
            _iteamRanks = iteamRanks;
            _playersRankRepo = playersRankRepo;
        }

        [HttpGet("Team/Rankings")]
        public async Task<IActionResult> TeamsRanking(enTeamRankingFormat format, enGender gender)
        {
            Response dtoResponse = new Response();
            dtoResponse.Status = true;
            dtoResponse.Message = "record found successsfully.....////";
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

        [HttpGet("MensRankings")]
        public async Task<IActionResult> MensRanking(enRole role, enFormat format)
        {
            Response dtoResponse = new Response();
            dtoResponse.Status = true;
            dtoResponse.Message = "record found successsfully.....////";
            try
            {
                dtoResponse = await _playersRankRepo.GetMensRanking(role, format);

            }
            catch (Exception ex)
            {
                dtoResponse.Status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);
        }

        [HttpGet("WomRankings")]
        public async Task<IActionResult> WomensRanking(enRole role, enWomenFormat format)
        {
            Response dtoResponse = new Response();
            dtoResponse.Status = true;
            dtoResponse.Message = "record found successsfully.....////";
            try
            {
                dtoResponse = await _playersRankRepo.GetwomensRanking(role, format);

            }
            catch (Exception ex)
            {
                dtoResponse.Status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);
        }



    }
}