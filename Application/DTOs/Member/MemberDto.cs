namespace Application.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<RolDto> Roles { get; set; } = new();
    }
}
