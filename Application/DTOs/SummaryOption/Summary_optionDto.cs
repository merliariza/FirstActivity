namespace Application.DTOs
{
    public class SummaryOptionDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string? CodeNumber { get; set; }
        public int QuestionId { get; set; }
        public string? ValueRta { get; set; }

        public SurveyDto? Survey { get; set; }
        public QuestionDto? Question { get; set; }
    }
}