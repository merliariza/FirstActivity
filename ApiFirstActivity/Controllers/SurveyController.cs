using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public SurveysController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Surveys
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Survey>>> Get()
    {
        var Surveys = await _unitOfWork.Surveys.GetAllAsync();
        return Ok(Surveys);
    }

    // GET: api/Surveys/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (Survey == null)
            return NotFound($"Survey with id {id} was not found.");
        return Ok(Survey);
    }

    // POST: api/Surveys
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Survey survey)
    {
        if (survey == null)
            return BadRequest("survey cannot be null.");

        _unitOfWork.Surveys.Add(survey); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = survey.Id }, survey);
    }

    // PUT: api/Surveys/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Survey survey)
    {
        if (survey == null || id != survey.Id)
            return BadRequest("Invalid survey data.");

        var existingSurvey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (existingSurvey == null)
            return NotFound($"survey with id {id} not found.");

        existingSurvey.Componenthtml = survey.Componenthtml;
            existingSurvey.Componentreact = survey.Componentreact;
            existingSurvey.Description = survey.Description;
            existingSurvey.Instruction = survey.Instruction;
            existingSurvey.Name = survey.Name;
            existingSurvey.Updated_at = DateTime.UtcNow;

        _unitOfWork.Surveys.Update(existingSurvey); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Surveys/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (survey == null)
            return NotFound($"survey with id {id} not found.");

        _unitOfWork.Surveys.Remove(survey); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
