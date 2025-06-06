using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Summary_optionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Summary_optionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Summary_options
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Summary_option>>> Get()
    {
        var Summary_options = await _unitOfWork.Summary_options.GetAllAsync();
        return Ok(Summary_options);
    }

    // GET: api/Summary_options/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Summary_option = await _unitOfWork.Summary_options.GetByIdAsync(id);
        if (Summary_option == null)
            return NotFound($"Summary_option with id {id} was not found.");
        return Ok(Summary_option);
    }

    // POST: api/Summary_options
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Summary_option summary_Option)
    {
        if (summary_Option == null)
            return BadRequest("summary_Option cannot be null.");

        _unitOfWork.Summary_options.Add(summary_Option); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = summary_Option.Id }, summary_Option);
    }

    // PUT: api/Summary_options/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Summary_option summary_Option)
    {
        if (summary_Option == null || id != summary_Option.Id)
            return BadRequest("Invalid summary_Option data.");

        var existingSummary_Option = await _unitOfWork.Summary_options.GetByIdAsync(id);
        if (existingSummary_Option == null)
            return NotFound($"summary_Option with id {id} not found.");

        existingSummary_Option.Id_survey = summary_Option.Id_survey;
        existingSummary_Option.Code_number = summary_Option.Code_number;
        existingSummary_Option.Idquestion = summary_Option.Idquestion;
        existingSummary_Option.Valuerta = summary_Option.Valuerta;

        _unitOfWork.Summary_options.Update(existingSummary_Option); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Summary_options/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var summary_Option = await _unitOfWork.Summary_options.GetByIdAsync(id);
        if (summary_Option == null)
            return NotFound($"summary_Option with id {id} not found.");

        _unitOfWork.Summary_options.Remove(summary_Option); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
