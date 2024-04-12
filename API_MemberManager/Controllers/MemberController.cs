using API_MemberManager.Models;
using API_MemberManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MemberManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController: ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public IActionResult GetMembers()
        {
            var members = _memberService.GetMembers();
            return Ok(members);
        }
        [HttpPost]
        public IActionResult CreateMember([FromBody] MemberRequestModel member)
        {
            var createdMember = _memberService.CreateMember(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = createdMember.Id }, createdMember);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMember(Guid id, [FromBody] MemberRequestModel member)
        {
            var updatedMember = _memberService.UpdateMember(id, member);
            return Ok(updatedMember);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMember(Guid id)
        {
            _memberService.DeleteMember(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetMemberById(Guid id)
        {
            var member = _memberService.GetMemberById(id);
            return Ok(member);
        }
        [HttpGet("name/{name}")]
        public IActionResult GetMemberByName(string name)
        {
            var member = _memberService.GetMemberByName(name);
            return Ok(member);
        }
    }
}
