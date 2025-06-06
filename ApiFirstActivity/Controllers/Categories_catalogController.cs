using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Categories_catalogsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public Categories_catalogsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/categories_catalogs
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Categories_catalog>>> Get()
    {
        var categories_catalogs = await _unitOfWork.Categories_catalogs.GetAllAsync();
        return Ok(categories_catalogs);
    }

    // GET: api/categories_catalogs/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var categories_catalog = await _unitOfWork.Categories_catalogs.GetByIdAsync(id);
        if (categories_catalog == null)
            return NotFound($"Categories_catalog with id {id} was not found.");
        return Ok(categories_catalog);
    }

    // POST: api/categories_catalogs
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Categories_catalog category)
    {
        if (category == null)
            return BadRequest("Category cannot be null.");

        _unitOfWork.Categories_catalogs.Add(category); // Método sincrónico
        await _unitOfWork.SaveAsync(); // Guarda cambios asíncronamente

        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    // PUT: api/categories_catalogs/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Categories_catalog category)
    {
        if (category == null || id != category.Id)
            return BadRequest("Invalid category data.");

        var existingCategory = await _unitOfWork.Categories_catalogs.GetByIdAsync(id);
        if (existingCategory == null)
            return NotFound($"Category with id {id} not found.");

        existingCategory.Name = category.Name;
        existingCategory.Updated_at = DateTime.UtcNow;


        _unitOfWork.Categories_catalogs.Update(existingCategory); // Método sincrónico
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/categories_catalogs/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _unitOfWork.Categories_catalogs.GetByIdAsync(id);
        if (category == null)
            return NotFound($"Category with id {id} not found.");

        _unitOfWork.Categories_catalogs.Remove(category); // Método sincrónico
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
