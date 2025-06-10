using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Option_questionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Option_questionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
 // GET: api/option_questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionQuestionDto>>> Get()
    {
        var option_question = await _unitOfWork.Option_questions.GetAllAsync();
        return _mapper.Map<List<OptionQuestionDto>>(option_question);
    }

    // GET: api/option_questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionQuestionDto>> Get(int id)
    {
        var option_question = await _unitOfWork.Option_questions.GetByIdAsync(id);
        if (option_question == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<OptionQuestionDto>(option_question);
    }

    // POST: api/option_questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Option_question>> Post(OptionQuestionDto OptionQuestionDto)
    {
        var option_question = _mapper.Map<Option_question>(OptionQuestionDto);
        _unitOfWork.Option_questions.Add(option_question);
        await _unitOfWork.SaveAsync();
        if (OptionQuestionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = OptionQuestionDto.Id }, OptionQuestionDto);
    }

    // PUT: api/option_questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionQuestionDto OptionQuestionDto)
    {
        if (OptionQuestionDto == null)
            return NotFound();

        var option_question = _mapper.Map<Option_question>(OptionQuestionDto);
        //option_question.Subquestion_id = option_question.Subquestion_id;
        //option_question.Optionquestion_id = option_question.Optionquestion_id;
        //option_question.Optioncatalog_id = option_question.Optioncatalog_id;
        //option_question.Option_id = option_question.Option_id;
        //option_question.Comment_options = option_question.Comment_options;
        //option_question.Numberoption = option_question.Numberoption;
        option_question.Updated_at = DateTime.UtcNow;

        _unitOfWork.Option_questions.Update(option_question);
        await _unitOfWork.SaveAsync();

        return Ok(OptionQuestionDto);
    }

    // DELETE: api/option_questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var option_question = await _unitOfWork.Option_questions.GetByIdAsync(id);
        if (option_question == null)
            return NotFound();

        _unitOfWork.Option_questions.Remove(option_question);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}