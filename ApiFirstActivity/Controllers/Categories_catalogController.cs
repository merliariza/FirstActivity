using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ApiFirstActivity.Controllers;

public class Categories_catalogsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Categories_catalogsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/categories_catalogs
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriesCatalogDto>>> Get()
    {
        var categories_catalog = await _unitOfWork.Categories_catalogs.GetAllAsync();
        return _mapper.Map<List<CategoriesCatalogDto>>(categories_catalog);
    }

    // GET: api/categories_catalogs/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriesCatalogDto>> Get(int id)
    {
        var categories_catalog = await _unitOfWork.Categories_catalogs.GetByIdAsync(id);
        if (categories_catalog == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<CategoriesCatalogDto>(categories_catalog);
    }

    // POST: api/categories_catalogs
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Categories_catalog>> Post(CategoriesCatalogDto categoriesCatalogDto)
    {
        var categories_catalog = _mapper.Map<Categories_catalog>(categoriesCatalogDto);
        _unitOfWork.Categories_catalogs.Add(categories_catalog);
        await _unitOfWork.SaveAsync();
        if (categoriesCatalogDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoriesCatalogDto.Id }, categoriesCatalogDto);
    }

    // PUT: api/categories_catalogs/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoriesCatalogDto categoriesCatalogDto)
    {
        if (categoriesCatalogDto == null)
            return NotFound();

        var categories_catalog = _mapper.Map<Categories_catalog>(categoriesCatalogDto);
        //categories_catalog.Name = categories_catalog.Name;
        categories_catalog.Updated_at = DateTime.UtcNow;

        _unitOfWork.Categories_catalogs.Update(categories_catalog);
        await _unitOfWork.SaveAsync();

        return Ok(categoriesCatalogDto);
    }

    // DELETE: api/categories_catalogs/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var categories_catalog = await _unitOfWork.Categories_catalogs.GetByIdAsync(id);
        if (categories_catalog == null)
            return NotFound();

        _unitOfWork.Categories_catalogs.Remove(categories_catalog);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}