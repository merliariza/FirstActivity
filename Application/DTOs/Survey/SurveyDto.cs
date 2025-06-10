namespace Application.DTOs
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string? ComponentHtml { get; set; }
        public string? ComponentReact { get; set; }
        public string? Description { get; set; }
        public string? Instruction { get; set; }
        public string? Name { get; set; }
        public List<ChapterDto>? Chapters { get; set; }
        public List<SummaryOptionDto>? SummaryOptions { get; set; }
    }

}