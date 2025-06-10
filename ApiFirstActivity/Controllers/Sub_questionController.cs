using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Sub_questionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Sub_questionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/sub_questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubQuestionDto>>> Get()
    {
        var sub_question = await _unitOfWork.Sub_questions.GetAllAsync();
        return _mapper.Map<List<SubQuestionDto>>(sub_question);
    }

    // GET: api/sub_questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubQuestionDto>> Get(int id)
    {
        var sub_question = await _unitOfWork.Sub_questions.GetByIdAsync(id);
        if (sub_question == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<SubQuestionDto>(sub_question);
    }

    // POST: api/sub_questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Sub_question>> Post(SubQuestionDto SubQuestionDto)
    {
        var sub_question = _mapper.Map<Sub_question>(SubQuestionDto);
        _unitOfWork.Sub_questions.Add(sub_question);
        await _unitOfWork.SaveAsync();
        if (SubQuestionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = SubQuestionDto.Id }, SubQuestionDto);
    }

    // PUT: api/sub_questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SubQuestionDto SubQuestionDto)
    {
        if (SubQuestionDto == null)
            return NotFound();

        var sub_question = _mapper.Map<Sub_question>(SubQuestionDto);
        
        //sub_question.Subquestion_id = sub_question.Subquestion_id;
        //sub_question.Subquestion_number = sub_question.Subquestion_number;
        //sub_question.Comment_subquestion = sub_question.Comment_subquestion;
        //sub_question.Subquestion_text = sub_question.Subquestion_text;

        sub_question.Updated_at = DateTime.UtcNow;

        _unitOfWork.Sub_questions.Update(sub_question);
        await _unitOfWork.SaveAsync();

        return Ok(SubQuestionDto);
    }

    // DELETE: api/sub_questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var sub_question = await _unitOfWork.Sub_questions.GetByIdAsync(id);
        if (sub_question == null)
            return NotFound();

        _unitOfWork.Sub_questions.Remove(sub_question);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}