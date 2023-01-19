using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _activitiesService.GetActivitiesAsync(true);

        if (!result.Succeeded)
        {
            if (result.Errors.Count > 0)
            {
                return StatusCode(500, result);
            }

            return StatusCode(400, result);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _activitiesService.GetActivityAsync(id);

        if (result.Succeeded == false)
        {
            if (result.Errors.Count > 0)
            {
                return StatusCode(500, result);
            }

            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromForm] InsertActivityDto activityDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var response = await _activitiesService.InsertActivityAsync(activityDto);

        if (response.Succeeded)
        {
            return Created(Url.Action(nameof(Create)), response);
        }
        else
        {
            if (response.Errors.Count > 0)
            {
                return StatusCode(500, response);
            }

            return BadRequest(response);
        }                
    }

    [HttpPatch]
    //[Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromForm] UpdateActivityDto data, int id)
    {
        if (data.Title == null && data.Description == null)
        {
            return BadRequest(new Response<string>(null, false, null, "Please select at least one field to modify."));
        }

        var result = await _activitiesService.UpdateActivityAsync(data, id);

        if (result.Succeeded)
        {
            return Ok(result);
        }
        else
        {
            if (result.Errors.Count > 0)
            {
                return StatusCode(500, result);
            }

            return BadRequest(result);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _activitiesService.DeleteAsync(id);

        if (!result.Succeeded)
        {
            if (result.Errors.Count > 0)
            {
                return StatusCode(500, result);
            }

            return StatusCode(statusCode: 404, result);
        }

        return Ok(result);
    }
}


