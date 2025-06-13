using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApiFirstActivity.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Categories_catalog, CategoriesCatalogDto>().ReverseMap();
        CreateMap<Category_option, CategoryOptionDto>().ReverseMap();
        CreateMap<Chapter, ChapterDto>().ReverseMap();
        CreateMap<Option_question, OptionQuestionDto>().ReverseMap();
        CreateMap<Options_response, OptionsResponseDto>().ReverseMap();
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Sub_question, SubQuestionDto>().ReverseMap();
        CreateMap<Summary_option, SummaryOptionDto>().ReverseMap();
        CreateMap<Survey, SurveyDto>().ReverseMap();
    }
}
