using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public QuestionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Question>>> Get()
    {
        var Questions = await _unitOfWork.Questions.GetAllAsync();
        return Ok(Questions);
    }

    // GET: api/Questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (Question == null)
            return NotFound($"Question with id {id} was not found.");
        return Ok(Question);
    }

    // POST: api/Questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Question question)
    {
        if (question == null)
            return BadRequest("question cannot be null.");

        _unitOfWork.Questions.Add(question); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
    }

    // PUT: api/Questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Question question)
    {
        if (question == null || id != question.Id)
            return BadRequest("Invalid question data.");

        var existingQuestion = await _unitOfWork.Questions.GetByIdAsync(id);
        if (existingQuestion == null)
            return NotFound($"question with id {id} not found.");

        existingQuestion.Chapter_id = question.Chapter_id;
        existingQuestion.Question_number = question.Question_number;
        existingQuestion.Response_type = question.Response_type;
        existingQuestion.Comment_question = question.Comment_question;
        existingQuestion.Question_text = question.Question_text;

        existingQuestion.Updated_at = DateTime.UtcNow;

        _unitOfWork.Questions.Update(existingQuestion); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (question == null)
            return NotFound($"question with id {id} not found.");

        _unitOfWork.Questions.Remove(question); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
