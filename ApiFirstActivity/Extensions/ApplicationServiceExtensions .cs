using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.Interfaces; 
using Infrastructure.UnitOfWork;
using System.Threading.RateLimiting;
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
    public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
{
    services.AddRateLimiter(options =>
    {   
        options.OnRejected = async (context, token) =>
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";
            context.HttpContext.Response.StatusCode = 429;
            context.HttpContext.Response.ContentType = "application/json";
            var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta más tarde.\"}}";
            await context.HttpContext.Response.WriteAsync(mensaje, token);
        };

        // Aquí no se define GlobalLimiter
        options.AddPolicy("ipLimiter", httpContext =>
        {
            var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(10),
                QueueLimit = 0,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
            });
        });
        // Fixed Window Limiter
        // options.AddFixedWindowLimiter("fixed", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.PermitLimit = 5;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        // });

        // Sliding Window Limiter
        // options.AddSlidingWindowLimiter("sliding", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.SegmentsPerWindow = 3;
        //     opt.PermitLimit = 6;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.NewestFirst;
        //     // Aquí se personaliza la respuesta cuando se excede el límite
        // });

        // Token Bucket Limiter
        // options.AddTokenBucketLimiter("token", opt =>
        // {
        //     opt.TokenLimit = 20;
        //     opt.TokensPerPeriod = 4;
        //     opt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        //     opt.QueueLimit = 2;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //     opt.AutoReplenishment = true;
        // });

    });

    return services;
}
}