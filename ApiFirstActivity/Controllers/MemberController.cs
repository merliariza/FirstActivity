using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstActivity.Controllers;

public class MembersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MembersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/members
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MemberDto>>> Get()
    {
        var member = await _unitOfWork.Members.GetAllAsync();
        return _mapper.Map<List<MemberDto>>(member);
    }

    // GET: api/members/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MemberDto>> Get(int id)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id);
        if (member == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }

        return _mapper.Map<MemberDto>(member);
    }

    // POST: api/members
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Member>> Post(MemberDto MemberDto)
    {
        var member = _mapper.Map<Member>(MemberDto);
        _unitOfWork.Members.Add(member);
        await _unitOfWork.SaveAsync();
        if (MemberDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = MemberDto.Id }, MemberDto);
    }

    // PUT: api/members/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] MemberDto MemberDto)
    {
        if (MemberDto == null)
            return NotFound();

        var member = _mapper.Map<Member>(MemberDto);
        //member.Chapter_id = member.Chapter_id;
        //member.member_number = member.member_number;
        //member.Response_type = member.Response_type;
        //member.Comment_member = member.Comment_member;
        //member.member_text = member.member_text;
        //member.Updated_at = DateTime.UtcNow;

        _unitOfWork.Members.Update(member);
        await _unitOfWork.SaveAsync();

        return Ok(MemberDto);
    }

    // DELETE: api/members/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id);
        if (member == null)
            return NotFound();

        _unitOfWork.Members.Remove(member);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}