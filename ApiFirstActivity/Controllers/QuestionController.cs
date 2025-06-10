using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> Get()
    {
        var question = await _unitOfWork.Questions.GetAllAsync();
        return _mapper.Map<List<QuestionDto>>(question);
    }

    // GET: api/questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<QuestionDto>> Get(int id)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (question == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<QuestionDto>(question);
    }

    // POST: api/questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Question>> Post(QuestionDto QuestionDto)
    {
        var question = _mapper.Map<Question>(QuestionDto);
        _unitOfWork.Questions.Add(question);
        await _unitOfWork.SaveAsync();
        if (QuestionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = QuestionDto.Id }, QuestionDto);
    }

    // PUT: api/questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] QuestionDto QuestionDto)
    {
        if (QuestionDto == null)
            return NotFound();

        var question = _mapper.Map<Question>(QuestionDto);
        //question.Chapter_id = question.Chapter_id;
        //question.Question_number = question.Question_number;
        //question.Response_type = question.Response_type;
        //question.Comment_question = question.Comment_question;
        //question.Question_text = question.Question_text;
        question.Updated_at = DateTime.UtcNow;

        _unitOfWork.Questions.Update(question);
        await _unitOfWork.SaveAsync();

        return Ok(QuestionDto);
    }

    // DELETE: api/questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (question == null)
            return NotFound();

        _unitOfWork.Questions.Remove(question);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}