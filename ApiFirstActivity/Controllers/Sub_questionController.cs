using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Sub_questionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Sub_questionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Sub_questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Sub_question>>> Get()
    {
        var Sub_questions = await _unitOfWork.Sub_questions.GetAllAsync();
        return Ok(Sub_questions);
    }

    // GET: api/Sub_questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Sub_question = await _unitOfWork.Sub_questions.GetByIdAsync(id);
        if (Sub_question == null)
            return NotFound($"Sub_question with id {id} was not found.");
        return Ok(Sub_question);
    }

    // POST: api/Sub_questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Sub_question sub_question)
    {
        if (sub_question == null)
            return BadRequest("sub_question cannot be null.");

        _unitOfWork.Sub_questions.Add(sub_question); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = sub_question.Id }, sub_question);
    }

    // PUT: api/Sub_questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Sub_question sub_question)
    {
        if (sub_question == null || id != sub_question.Id)
            return BadRequest("Invalid sub_question data.");

        var existingSub_Question = await _unitOfWork.Sub_questions.GetByIdAsync(id);
        if (existingSub_Question == null)
            return NotFound($"sub_question with id {id} not found.");

        existingSub_Question.Subquestion_id = sub_question.Subquestion_id;
        existingSub_Question.Subquestion_number = sub_question.Subquestion_number;
        existingSub_Question.Comment_subquestion = sub_question.Comment_subquestion;
        existingSub_Question.Subquestion_text = sub_question.Subquestion_text;

        existingSub_Question.Updated_at = DateTime.UtcNow;

        _unitOfWork.Sub_questions.Update(existingSub_Question);

        await _unitOfWork.SaveAsync();

        return NoContent();
    }


    // DELETE: api/Sub_questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var sub_question = await _unitOfWork.Sub_questions.GetByIdAsync(id);
        if (sub_question == null)
            return NotFound($"sub_question with id {id} not found.");

        _unitOfWork.Sub_questions.Remove(sub_question); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
