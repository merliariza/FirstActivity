namespace Application.DTOs
{
    public class CategoryOptionDto
    {
        public int Id { get; set; }
        public int CatalogoptionsId { get; set; }
        public int CategoriesoptionsId { get; set; }

        public OptionsResponseDto? OptionsResponse { get; set; }
        public CategoriesCatalogDto? CategoriesCatalog { get; set; }
    }
}