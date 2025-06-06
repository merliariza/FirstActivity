using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Options_responsesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Options_responsesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Options_responses
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Options_response>>> Get()
    {
        var Options_responses = await _unitOfWork.Options_responses.GetAllAsync();
        return Ok(Options_responses);
    }

    // GET: api/Options_responses/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Options_response = await _unitOfWork.Options_responses.GetByIdAsync(id);
        if (Options_response == null)
            return NotFound($"Options_response with id {id} was not found.");
        return Ok(Options_response);
    }

    // POST: api/Options_responses
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Options_response options_Response)
    {
        if (options_Response == null)
            return BadRequest("options_Response cannot be null.");

        _unitOfWork.Options_responses.Add(options_Response); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = options_Response.Id }, options_Response);
    }

    // PUT: api/Options_responses/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<IActionResult> Put(int id, [FromBody] Options_response options_Response)
{
    if (options_Response == null || id != options_Response.Id)
        return BadRequest("Invalid options_Response data.");

    var existingOptions_Response = await _unitOfWork.Options_responses.GetByIdAsync(id);
    if (existingOptions_Response == null)
        return NotFound($"options_Response with id {id} not found.");

    existingOptions_Response.Optiontext = options_Response.Optiontext;
    existingOptions_Response.Updated_at = DateTime.UtcNow;

    _unitOfWork.Options_responses.Update(existingOptions_Response);
    await _unitOfWork.SaveAsync();

    return NoContent();
}


    // DELETE: api/Options_responses/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var options_Response = await _unitOfWork.Options_responses.GetByIdAsync(id);
        if (options_Response == null)
            return NotFound($"options_Response with id {id} not found.");

        _unitOfWork.Options_responses.Remove(options_Response); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
