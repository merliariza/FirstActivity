using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class ChaptersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChaptersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

  // GET: api/Chapters
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ChapterDto>>> Get()
    {
        var Chapter = await _unitOfWork.Chapters.GetAllAsync();
        return _mapper.Map<List<ChapterDto>>(Chapter);
    }

    // GET: api/Chapters/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ChapterDto>> Get(int id)
    {
        var Chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (Chapter == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<ChapterDto>(Chapter);
    }

    // POST: api/Chapters
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Chapter>> Post(ChapterDto ChapterDto)
    {
        var Chapter = _mapper.Map<Chapter>(ChapterDto);
        _unitOfWork.Chapters.Add(Chapter);
        await _unitOfWork.SaveAsync();
        if (ChapterDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = ChapterDto.Id }, ChapterDto);
    }

    // PUT: api/Chapters/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] ChapterDto ChapterDto)
    {
        if (ChapterDto == null)
            return NotFound();

        var chapter = _mapper.Map<Chapter>(ChapterDto);
        //chapter.Survey_id = chapter.Survey_id;
        //chapter.Componenthtml = chapter.Componenthtml;
        //chapter.Componentreact = chapter.Componentreact;
        //chapter.Chapter_number = chapter.Chapter_number;
        //chapter.Chapter_title = chapter.Chapter_title;
        //chapter.Updated_at = DateTime.UtcNow;

        _unitOfWork.Chapters.Update(chapter);
        await _unitOfWork.SaveAsync();

        return Ok(ChapterDto);
    }

    // DELETE: api/Chapters/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (chapter == null)
            return NotFound();

        _unitOfWork.Chapters.Remove(chapter);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}