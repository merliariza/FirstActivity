namespace Application.DTOs
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<MemberDto>? Members { get; set; }
    }
}
