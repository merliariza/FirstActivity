namespace Application.DTOs
{
    public class CategoriesCatalogDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<OptionQuestionDto>? OptionQuestions { get; set; }
        public List<CategoryOptionDto>? CategoryOptions { get; set; }
    }
}