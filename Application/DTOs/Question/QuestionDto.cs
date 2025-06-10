namespace Application.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public string? QuestionNumber { get; set; }
        public string? ResponseType { get; set; }
        public string? CommentQuestion { get; set; }
        public string? QuestionText { get; set; }

        public ChapterDto? Chapter { get; set; }
        public List<SummaryOptionDto>? SummaryOptions { get; set; }
        public List<SubQuestionDto>? SubQuestions { get; set; }
        public List<OptionQuestionDto>? OptionQuestions { get; set; }
    }
}