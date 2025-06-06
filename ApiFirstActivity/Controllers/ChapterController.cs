using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class ChaptersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ChaptersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Chapters
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chapter>>> Get()
    {
        var Chapters = await _unitOfWork.Chapters.GetAllAsync();
        return Ok(Chapters);
    }

    // GET: api/Chapters/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var Chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (Chapter == null)
            return NotFound($"Chapter with id {id} was not found.");
        return Ok(Chapter);
    }

    // POST: api/Chapters
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Chapter chapter)
    {
        if (chapter == null)
            return BadRequest("chapter cannot be null.");

        _unitOfWork.Chapters.Add(chapter); 
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(Get), new { id = chapter.Id }, chapter);
    }

    // PUT: api/Chapters/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] Chapter chapter)
    {
        if (chapter == null || id != chapter.Id)
            return BadRequest("Invalid chapter data.");

        var existingChapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existingChapter == null)
            return NotFound($"chapter with id {id} not found.");

        existingChapter.Survey_id = chapter.Survey_id;
        existingChapter.Componenthtml = chapter.Componenthtml;
        existingChapter.Componentreact = chapter.Componentreact;
        existingChapter.Chapter_number = chapter.Chapter_number;
        existingChapter.Chapter_title = chapter.Chapter_title;
        existingChapter.Updated_at = DateTime.UtcNow;

        _unitOfWork.Chapters.Update(existingChapter); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Chapters/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (chapter == null)
            return NotFound($"chapter with id {id} not found.");

        _unitOfWork.Chapters.Remove(chapter); 
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
