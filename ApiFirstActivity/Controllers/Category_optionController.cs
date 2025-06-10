using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class Category_optionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Category_optionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/Category_options
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryOptionDto>>> Get()
    {
        var category_option = await _unitOfWork.Category_options.GetAllAsync();
        return _mapper.Map<List<CategoryOptionDto>>(category_option);
    }

    // GET: api/Category_options/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryOptionDto>> Get(int id)
    {
        var category_option = await _unitOfWork.Category_options.GetByIdAsync(id);
        if (category_option == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<CategoryOptionDto>(category_option);
    }

    // POST: api/Category_options
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Category_option>> Post(CategoryOptionDto CategoryOptionDto)
    {
        var category_option = _mapper.Map<Category_option>(CategoryOptionDto);
        _unitOfWork.Category_options.Add(category_option);
        await _unitOfWork.SaveAsync();
        if (CategoryOptionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = CategoryOptionDto.Id }, CategoryOptionDto);
    }

    // PUT: api/Category_options/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryOptionDto CategoryOptionDto)
    {
        if (CategoryOptionDto == null)
            return NotFound();

        var Category_option = _mapper.Map<Category_option>(CategoryOptionDto);

        //Category_option.Catalogoptions_id = Category_option.Catalogoptions_id;
        //Category_option.Categoriesoptions_id = Category_option.Categoriesoptions_id;
        Category_option.Updated_at = DateTime.UtcNow;

        _unitOfWork.Category_options.Update(Category_option);
        await _unitOfWork.SaveAsync();

        return Ok(CategoryOptionDto);
    }

    // DELETE: api/Category_options/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Category_option = await _unitOfWork.Category_options.GetByIdAsync(id);
        if (Category_option == null)
            return NotFound();

        _unitOfWork.Category_options.Remove(Category_option);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}