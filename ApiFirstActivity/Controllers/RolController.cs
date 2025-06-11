using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class RolsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/rols
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolDto>>> Get()
    {
        var rol = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RolDto>>(rol);
    }

    // GET: api/rols/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> Get(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<RolDto>(rol);
    }

    // POST: api/rols
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(RolDto RolDto)
    {
        var rol = _mapper.Map<Rol>(RolDto);
        _unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        if (RolDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = RolDto.Id }, RolDto);
    }

    // PUT: api/rols/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] RolDto RolDto)
    {
        if (RolDto == null)
            return NotFound();

        var rol = _mapper.Map<Rol>(RolDto);
        //rol.Updated_at = DateTime.UtcNow;

        _unitOfWork.Roles.Update(rol);
        await _unitOfWork.SaveAsync();

        return Ok(RolDto);
    }

    // DELETE: api/rols/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
            return NotFound();

        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}