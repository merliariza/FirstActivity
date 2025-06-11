using System;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategories_catalogRepository Categories_catalogs { get; }
        ICategory_optionRepository Category_options { get; }
        IChapterRepository Chapters { get; }
        IOption_questionRepository Option_questions { get; }
        IOptions_responseRepository Options_responses { get; }
        IQuestionRepository Questions { get; }
        ISub_questionRepository Sub_questions { get; }
        ISummary_optionRepository Summary_options { get; }
        ISurveyRepository Surveys { get; }
        IMemberRepository Members { get; }
        IRolRepository Roles { get; }
        
        Task<int> SaveAsync();
    }
}