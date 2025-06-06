using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.Interfaces; 
using Infrastructure.UnitOfWork; 
namespace ApiFirstActivity.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
                .AllowAnyMethod()          //WithMethods("GET","POST")
                .AllowAnyHeader());        //WithHeaders("accept","content-type")
        });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        /*services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICategories_catalogRepository, Categories_catalogRepository>();
        services.AddScoped<ICategory_optionRepository, Category_optionRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<IOption_questionRepository, Option_questionRepository>();
        services.AddScoped<IOptions_responseRepository, Options_responseRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ISub_questionRepository, Sub_questionRepository>();
        services.AddScoped<ISummary_optionRepository, Summary_optionRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();*/
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}