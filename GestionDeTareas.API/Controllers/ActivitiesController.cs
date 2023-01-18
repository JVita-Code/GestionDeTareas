using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GestionDeTareas.API.Controllers;


[Route("activities")]
[ApiController]

public class ActivitiesController : ControllerBase
{
    private readonly IActivitiesBusiness _activitiesService;

    public ActivitiesController(IActivitiesBusiness activitiesService)
    {
        _activitiesService = activitiesService;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Insert([FromForm] InsertActivityDto activityDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _activitiesService.InsertActivity(activityDto);

            return Ok(response);
        }
        catch (Exception e)
        {
            var listErrors = new string[] { e.Message };
            return StatusCode(500, new Response<InsertActivityDto>(data: null, succeeded: false, errors: listErrors, message: "Server Error"));
        }
    }

    [HttpPatch]
    //[Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromForm] UpdateActivityDto data, int id)
    {
        try
        {
            if (data.Title == null && data.Description == null)
            {
                return BadRequest(new Response<string>(null, false, null, "Please select at least one field to modify."));
            }

            var result = await _activitiesService.UpdateActivity(data, id);

            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        catch (Exception e)
        {
            var error = new Response<string>(e.Message, false, null, "Server Error");
            return StatusCode(500, error);
        }
    }
}


