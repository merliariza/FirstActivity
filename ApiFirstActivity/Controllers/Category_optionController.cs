using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Category_optionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Category_optionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Category_options
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Category_option>>> Get()
    {
        var Category_options = await _unitOfWork.Category_options.GetAllAsync();
        return Ok(Category_options);
    }

    // GET: api/Category_options/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Category_option = await _unitOfWork.Category_options.GetByIdAsync(id);
        if (Category_option == null)
            return NotFound($"Category_option with id {id} was not found.");
        return Ok(Category_option);
    }

    // POST: api/Category_options
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Category_option category)
    {
        if (category == null)
            return BadRequest("Category cannot be null.");

        _unitOfWork.Category_options.Add(category); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    // PUT: api/Category_options/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Category_option category)
    {
        if (category == null || id != category.Id)
            return BadRequest("Invalid category data.");

        var existingCategory_options = await _unitOfWork.Category_options.GetByIdAsync(id);
        if (existingCategory_options == null)
            return NotFound($"Category with id {id} not found.");

        existingCategory_options.Catalogoptions_id = category.Catalogoptions_id;
        existingCategory_options.Categoriesoptions_id = category.Categoriesoptions_id;
        existingCategory_options.Updated_at = DateTime.UtcNow;

        _unitOfWork.Category_options.Update(existingCategory_options); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Category_options/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _unitOfWork.Category_options.GetByIdAsync(id);
        if (category == null)
            return NotFound($"Category with id {id} not found.");

        _unitOfWork.Category_options.Remove(category); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
