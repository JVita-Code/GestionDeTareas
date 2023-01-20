using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTareas.API.Controllers;

[Route("activities")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ActivitiesController : ControllerBase
{
    private readonly IActivitiesBusiness _activitiesService;

    public ActivitiesController(IActivitiesBusiness activitiesService)
    {
        _activitiesService = activitiesService;
    }

    [HttpGet]
    [AllowAnonymous]
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
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(StatusCodes.Status201Created)]
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

    /// <summary>
    /// Updates an activity.
    /// </summary>
    /// <param name="data"> New info.</param>
    /// <param name="id"> Id of the activity.</param>
    /// <returns></returns>
    [HttpPatch]
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

    /// <summary>
    /// Deletes an activity.
    /// </summary>
    /// <param name="id">id of the activity to delete</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


