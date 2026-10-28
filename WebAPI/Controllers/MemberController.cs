using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip.Models;

namespace Trip.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly TripDbContext _context;

    public MemberController(TripDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDTO>>> GetMembers()
    {
        return await _context.Members
            .Select(member => new MemberDTO
            {
                Id = member.Id,
                UserName = member.UserName,
                DateOfBirth = member.DateOfBirth
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MemberDTO>> GetMember(long id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member is null)
        {
            return NotFound();
        }

        return new MemberDTO
        {
            Id = member.Id,
            UserName = member.UserName,
            DateOfBirth = member.DateOfBirth
        };
    }

    [HttpPost]
    public async Task<ActionResult<MemberDTO>> PostMember(MemberDTO memberDTO)
    {
        var member = new Member
        {
            UserName = memberDTO.UserName,
            DateOfBirth = memberDTO.DateOfBirth
        };

        _context.Members.Add(member);
        int entityID = await _context.SaveChangesAsync();

        var createdMemberDto = new MemberDTO
        {
            Id = entityID,
            UserName = member.UserName,
            DateOfBirth = member.DateOfBirth
        };

        return CreatedAtAction(nameof(GetMember), new { id = member.Id }, createdMemberDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMember(long id, MemberDTO memberDTO)
    {
        if (id != memberDTO.Id)
        {
            return BadRequest();
        }

        var member = await _context.Members.FindAsync(id);
        if (member is null)
        {
            return NotFound();
        }

        member.UserName = memberDTO.UserName;
        member.DateOfBirth = memberDTO.DateOfBirth;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(long id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member is null)
        {
            return NotFound();
        }

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
