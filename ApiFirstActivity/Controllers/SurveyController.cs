using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SurveysController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/surveys
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SurveyDto>>> Get()
    {
        var survey = await _unitOfWork.Surveys.GetAllAsync();
        return _mapper.Map<List<SurveyDto>>(survey);
    }

    // GET: api/surveys/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SurveyDto>> Get(int id)
    {
        var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (survey == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<SurveyDto>(survey);
    }

    // POST: api/surveys
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Survey>> Post(SurveyDto SurveyDto)
    {
        var survey = _mapper.Map<Survey>(SurveyDto);
        _unitOfWork.Surveys.Add(survey);
        await _unitOfWork.SaveAsync();
        if (SurveyDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = SurveyDto.Id }, SurveyDto);
    }

    // PUT: api/surveys/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SurveyDto SurveyDto)
    {
        if (SurveyDto == null)
            return NotFound();

        var survey = _mapper.Map<Survey>(SurveyDto);
        //survey.Componenthtml = survey.Componenthtml;
        //survey.Componentreact = survey.Componentreact;
        //survey.Description = survey.Description;
        //survey.Instruction = survey.Instruction;
        //survey.Name = survey.Name;
        //survey.Updated_at = DateTime.UtcNow;
        survey.Updated_at = DateTime.UtcNow;

        _unitOfWork.Surveys.Update(survey);
        await _unitOfWork.SaveAsync();

        return Ok(SurveyDto);
    }

    // DELETE: api/surveys/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (survey == null)
            return NotFound();

        _unitOfWork.Surveys.Remove(survey);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}