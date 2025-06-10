namespace Application.DTOs
{
    public class OptionQuestionDto
    {
        public int Id { get; set; }
        public int SubquestionId { get; set; }
        public int OptionquestionId { get; set; }
        public int OptioncatalogId { get; set; }
        public int OptionId { get; set; }
        public string? CommentOptions { get; set; }
        public string? NumberOption { get; set; }

        public SubQuestionDto? SubQuestion { get; set; }
        public QuestionDto? Question { get; set; }
        public CategoriesCatalogDto? CategoriesCatalog { get; set; }
        public OptionsResponseDto? OptionsResponse { get; set; }
    }
}