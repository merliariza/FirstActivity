namespace Application.DTOs

{
    public class OptionsResponseDto
    {
        public int Id { get; set; }
        public string? OptionText { get; set; }

        public List<CategoryOptionDto>? CategoryOptions { get; set; }
        public List<OptionQuestionDto>? OptionQuestions { get; set; }
    }
}