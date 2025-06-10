using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Options_responsesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Options_responsesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
  // GET: api/options_responses
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionsResponseDto>>> Get()
    {
        var options_response = await _unitOfWork.Options_responses.GetAllAsync();
        return _mapper.Map<List<OptionsResponseDto>>(options_response);
    }

    // GET: api/options_responses/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponseDto>> Get(int id)
    {
        var options_response = await _unitOfWork.Options_responses.GetByIdAsync(id);
        if (options_response == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<OptionsResponseDto>(options_response);
    }

    // POST: api/options_responses
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Options_response>> Post(OptionsResponseDto OptionsResponseDto)
    {
        var options_response = _mapper.Map<Options_response>(OptionsResponseDto);
        _unitOfWork.Options_responses.Add(options_response);
        await _unitOfWork.SaveAsync();
        if (OptionsResponseDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = OptionsResponseDto.Id }, OptionsResponseDto);
    }

    // PUT: api/options_responses/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionsResponseDto OptionsResponseDto)
    {
        if (OptionsResponseDto == null)
            return NotFound();

        var options_response = _mapper.Map<Options_response>(OptionsResponseDto);
        //options_response.Optiontext = options_Response.Optiontext;
        options_response.Updated_at = DateTime.UtcNow;

        _unitOfWork.Options_responses.Update(options_response);
        await _unitOfWork.SaveAsync();

        return Ok(OptionsResponseDto);
    }

    // DELETE: api/options_responses/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var options_response = await _unitOfWork.Options_responses.GetByIdAsync(id);
        if (options_response == null)
            return NotFound();

        _unitOfWork.Options_responses.Remove(options_response);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}