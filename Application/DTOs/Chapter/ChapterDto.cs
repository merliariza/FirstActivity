namespace Application.DTOs
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string? ComponentHtml { get; set; }
        public string? ComponentReact { get; set; }
        public string? ChapterNumber { get; set; }
        public string? ChapterTitle { get; set; }
        public SurveyDto? Survey { get; set; }
        public List<QuestionDto>? Questions { get; set; }
}
}