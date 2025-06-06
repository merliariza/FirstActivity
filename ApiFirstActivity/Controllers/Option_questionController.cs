using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Option_questionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Option_questionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Option_questions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Option_question>>> Get()
    {
        var Option_questions = await _unitOfWork.Option_questions.GetAllAsync();
        return Ok(Option_questions);
    }

    // GET: api/Option_questions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Option_question = await _unitOfWork.Option_questions.GetByIdAsync(id);
        if (Option_question == null)
            return NotFound($"Option_question with id {id} was not found.");
        return Ok(Option_question);
    }

    // POST: api/Option_questions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Option_question option_question)
    {
        if (option_question == null)
            return BadRequest("option_question cannot be null.");

        _unitOfWork.Option_questions.Add(option_question); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = option_question.Id }, option_question);
    }

    // PUT: api/Option_questions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Option_question option_question)
    {
        if (option_question == null || id != option_question.Id)
            return BadRequest("Invalid option_question data.");

        var existingOption_Question = await _unitOfWork.Option_questions.GetByIdAsync(id);
        if (existingOption_Question == null)
            return NotFound($"option_question with id {id} not found.");

        existingOption_Question.Subquestion_id = option_question.Subquestion_id;
        existingOption_Question.Optionquestion_id = option_question.Optionquestion_id;
        existingOption_Question.Optioncatalog_id = option_question.Optioncatalog_id;
        existingOption_Question.Option_id = option_question.Option_id;
        existingOption_Question.Comment_options = option_question.Comment_options;
        existingOption_Question.Numberoption = option_question.Numberoption;
        existingOption_Question.Updated_at = DateTime.UtcNow;

        _unitOfWork.Option_questions.Update(existingOption_Question); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Option_questions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var option_question = await _unitOfWork.Option_questions.GetByIdAsync(id);
        if (option_question == null)
            return NotFound($"option_question with id {id} not found.");

        _unitOfWork.Option_questions.Remove(option_question); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
