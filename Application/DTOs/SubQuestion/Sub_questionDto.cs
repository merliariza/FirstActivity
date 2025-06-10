namespace Application.DTOs
{
    public class SubQuestionDto
    {
        public int Id { get; set; }
        public int SubquestionId { get; set; }
        public string? SubquestionNumber { get; set; }
        public string? CommentSubquestion { get; set; }
        public string? SubquestionText { get; set; }

        public QuestionDto? Question { get; set; }
        public List<OptionQuestionDto>? OptionQuestions { get; set; }
    }
}