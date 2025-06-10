using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Summary_optionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Summary_optionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/Summary_options
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SummaryOptionDto>>> Get()
    {
        var Summary_option = await _unitOfWork.Summary_options.GetAllAsync();
        return _mapper.Map<List<SummaryOptionDto>>(Summary_option);
    }

    // GET: api/Summary_options/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SummaryOptionDto>> Get(int id)
    {
        var Summary_option = await _unitOfWork.Summary_options.GetByIdAsync(id);
        if (Summary_option == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<SummaryOptionDto>(Summary_option);
    }

    // POST: api/Summary_options
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Summary_option>> Post(SummaryOptionDto SummaryOptionDto)
    {
        var Summary_option = _mapper.Map<Summary_option>(SummaryOptionDto);
        _unitOfWork.Summary_options.Add(Summary_option);
        await _unitOfWork.SaveAsync();
        if (SummaryOptionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = SummaryOptionDto.Id }, SummaryOptionDto);
    }

    // PUT: api/Summary_options/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SummaryOptionDto SummaryOptionDto)
    {
        if (SummaryOptionDto == null)
            return NotFound();

        var Summary_option = _mapper.Map<Summary_option>(SummaryOptionDto);
        //Summary_Option.Id_survey = summary_Option.Id_survey;
        //Summary_Option.Code_number = summary_Option.Code_number;
        //Summary_Option.Idquestion = summary_Option.Idquestion;
        //Summary_Option.Valuerta = summary_Option.Valuerta;
        //Summary_option.Updated_at = DateTime.UtcNow;

        _unitOfWork.Summary_options.Update(Summary_option);
        await _unitOfWork.SaveAsync();

        return Ok(SummaryOptionDto);
    }

    // DELETE: api/Summary_options/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Summary_option = await _unitOfWork.Summary_options.GetByIdAsync(id);
        if (Summary_option == null)
            return NotFound();

        _unitOfWork.Summary_options.Remove(Summary_option);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}